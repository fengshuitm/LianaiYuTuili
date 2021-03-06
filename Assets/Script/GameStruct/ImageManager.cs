﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.UIScript;
using System;
using Assets.Script.GameStruct;

/**
 * ImageManager: 
 * 整个游戏只允许一个，作为GameManager的组件，不能删除
 * 图像处理的方法集合，供其他Manager调用
 * 控制 立绘 与 背景 的切换等等
 */

public delegate void MyEffect(UIAnimationCallback callback);

public class SpriteState
{
    public string spriteName;
    public float spritePosition_x, spritePosition_y;
    public float spriteAlpha;

    public SpriteState() { }

    public SpriteState(string name, Vector3 pos, float alpha)
    {
        spriteName = name;
        SetPosition(pos);
        spriteAlpha = alpha;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(spritePosition_x, spritePosition_y);
    }

    public void SetPosition(Vector3 pos)
    {
        spritePosition_x = pos.x;
        spritePosition_y = pos.y;
    }
}

public class ImageManager : MonoBehaviour
{
    public const string BG_PATH = "Background/";
    public const string CHARA_PATH = "Character/";

    public static readonly Vector3 LEFT = new Vector3(-300, 0, 0);
    public static readonly Vector3 MIDDLE = new Vector3(0, 0, 0);
    public static readonly Vector3 RIGHT = new Vector3(300, 0, 0);

    public UIPanel bgPanel, fgPanel, eviPanel;
    public DialogBoxUIManager dUiManager;

    [HideInInspector]
    public UI2DSprite bgSprite;

    private Dictionary<string, UI2DSprite> fgSprites;
    private bool isFast = false;

    void Awake()
    {
        bgSprite = bgPanel.transform.Find("BackGround_Sprite").gameObject.GetComponent<UI2DSprite>();
        fgSprites = new Dictionary<string, UI2DSprite>();
    }

    public void SetFast(bool fast) { isFast = fast; }

    public Sprite LoadImage(string path, string name)
    {
        return Resources.Load<Sprite>(path + name);
    }

    public Sprite LoadBackground(string name) { return LoadImage(BG_PATH, name); }
    public Sprite LoadCharacter(string name) { return LoadImage(CHARA_PATH, name); }


    public void MoveInit(Sprite nextSprite)
    {
        if (bgSprite.sprite2D != nextSprite) StartCoroutine(ChangeBackground(nextSprite));
    }

    private UI2DSprite GetSpriteByDepth(int depth)
    {
        UI2DSprite ui;
        if (fgPanel.transform.Find("sprite" + depth) != null)
        {
            ui = fgPanel.transform.Find("sprite" + depth).GetComponent<UI2DSprite>();
        }
        else
        {
            GameObject go = Resources.Load("Prefab/Character") as GameObject;
            go = NGUITools.AddChild(fgPanel.gameObject, go);
            go.transform.name = "sprite" + depth;
            ui = go.GetComponent<UI2DSprite>();
            ui.depth = depth;
        }
        return ui;
    }

    private void RemoveSpriteByDepth(int depth)
    {
        if (fgPanel.transform.Find("sprite" + depth) != null)
        {
            GameObject.Destroy(fgPanel.transform.Find("sprite" + depth).gameObject);
        }
    }

    private void SetDefaultPos(UI2DSprite ui, string pstr)
    {
        int x;
        switch (pstr)
        {
            case "left":
                x = -320;
                break;
            case "middle":
                x = 0;
                break;
            case "right":
                x = 320;
                break;
            default:
                x = 0;
                break;
        }
        int y = -360 + ui.height / 2;
        ui.transform.localPosition = new Vector3(x, y);
    }

    public void RunEffect(NewImageEffect effect, Action callback)
    {
        //决定操作对象
        UI2DSprite ui = bgSprite;
        bool isback = true;
        switch (effect.target)
        {
            case NewImageEffect.ImageType.Back:
                ui = bgSprite;
                break;
            case NewImageEffect.ImageType.Fore:
                ui = GetSpriteByDepth(effect.depth);
                isback = false;
                break;
            default:
                break;
        }
        //操作模式
        switch (effect.operate)
        {
            case NewImageEffect.OperateMode.SetSprite:
                ui.sprite2D = isback ? LoadBackground(effect.state.spriteName) : LoadCharacter(effect.state.spriteName);
                if (!isback) ui.MakePixelPerfect();
                callback();
                break;
            case NewImageEffect.OperateMode.SetAlpha:
                ui.alpha = effect.state.spriteAlpha;
                callback();
                break;
            case NewImageEffect.OperateMode.SetPos:
                if (!string.IsNullOrEmpty(effect.defaultpos))
                {
                    SetDefaultPos(ui, effect.defaultpos);
                }
                else
                {
                    ui.transform.localPosition = effect.state.GetPosition();
                }
                callback();
                break;
            case NewImageEffect.OperateMode.Fade:
                if (effect.target == NewImageEffect.ImageType.All)
                {
                    StartCoroutine(FadeAll(effect, callback, true, true));
                }
                else if (effect.target == NewImageEffect.ImageType.AllChara)
                {
                    StartCoroutine(FadeAll(effect, callback, false, false));
                }
                else if(effect.target == NewImageEffect.ImageType.AllPic)
                {
                    StartCoroutine(FadeAll(effect, callback, true, false));
                }
                else
                {
                    StartCoroutine(Fade(ui, effect, callback));
                }
                break;
            case NewImageEffect.OperateMode.Move:
                StartCoroutine(Move(ui, effect, callback));
                break;
            case NewImageEffect.OperateMode.Remove:
                break;
        }
    }

    private IEnumerator ChangeBackground(Sprite sprite, float time = 0.5f)
    {
        bgSprite.alpha = 1;
        while (bgSprite.alpha > 0)
        {
            bgSprite.alpha = Mathf.MoveTowards(bgSprite.alpha, 0, 1 / time * Time.fixedDeltaTime);
            yield return null;
        }
        bgSprite.alpha = 0;
        bgSprite.sprite2D = sprite;
        while (bgSprite.alpha < 1)
        {
            bgSprite.alpha = Mathf.MoveTowards(bgSprite.alpha, 1, 1 / time * Time.fixedDeltaTime);
            yield return null;
        }
    }

    #region 存储 读取 前背景画面
    public void SaveImageInfo()
    {
        //储存当前的背景
        Dictionary<int, SpriteState> charaDic = new Dictionary<int, SpriteState>();
        //和立绘信息
        foreach(Transform child in fgPanel.transform)
        {
            //int depth = Convert.ToInt32(child.name.Substring(6, child.name.Length - 6));
            int depth = Convert.ToInt32(child.name.Substring(6));
            UI2DSprite ui = child.GetComponent<UI2DSprite>();
            string sprite = ui.sprite2D == null ? "" : ui.sprite2D.name;
            charaDic.Add(depth, new SpriteState(sprite, child.localPosition, ui.alpha));
        }
        DataManager.GetInstance().SetGameVar("背景图片", bgSprite.sprite2D.name);
        DataManager.GetInstance().SetGameVar("立绘信息", charaDic);
    }

    public void LoadImageInfo()
    {
        string bgname = DataManager.GetInstance().GetGameVar<string>("背景图片");
        bgSprite.sprite2D = LoadBackground(bgname);
        Dictionary<int, SpriteState> fgdic = DataManager.GetInstance().GetGameVar<Dictionary<int, SpriteState>>("立绘信息");

        //遍历当前的前景图 不在字典内的删除
        foreach(Transform  child in fgPanel.transform)
        {
            int depth = Convert.ToInt32(child.name.Substring(6));
            if (!fgdic.ContainsKey(depth))
            {
                RemoveSpriteByDepth(depth);
            }
        }
        //遍历存储字典 替换内容
        foreach (KeyValuePair<int,SpriteState> child in fgdic)
        {
            UI2DSprite ui;
            if(fgPanel.transform.Find("sprite" + child.Key) == null)
            {
                GameObject go = Resources.Load("Prefab/Character") as GameObject;
                go = NGUITools.AddChild(fgPanel.gameObject, go);
                go.transform.name = "sprite" + child.Key;
                ui = go.GetComponent<UI2DSprite>();
            }
            else
            {
                ui = fgPanel.transform.Find("sprite" + child.Key).GetComponent<UI2DSprite>();
            }
            //设置位置等
            ui.sprite2D = LoadCharacter(child.Value.spriteName);
            ui.transform.localPosition = child.Value.GetPosition();
            ui.alpha = child.Value.spriteAlpha;
            ui.MakePixelPerfect();
        }
    }
    #endregion

    private IEnumerator Fade(UI2DSprite ui, NewImageEffect effect, Action callback)
    {
        float t = 0;
        float origin = ui.alpha;
            //1 - effect.state.spriteAlpha;
        float final = effect.state.spriteAlpha;
        while (t < 1)
        {
            t = Mathf.MoveTowards(t, 1, 1 / effect.time * Time.fixedDeltaTime);
            ui.alpha = origin + t * (final - origin);
            yield return null;
        }
        callback();
    }

    private IEnumerator Move(UI2DSprite ui, NewImageEffect effect, Action callback)
    {
        float t = 0;
        Vector3 origin = ui.transform.localPosition;
        Vector3 final = effect.state.GetPosition();
        while (t < 1)
        {
            t = Mathf.MoveTowards(t, 1, 1 / effect.time * Time.fixedDeltaTime);
            ui.transform.localPosition = origin + t * (final - origin);
            yield return null;
        }
        callback();
    }

    private IEnumerator FadeAll(NewImageEffect effect, Action callback, bool includeBack, bool includeDiabox)
    {
        float t = 0;
        float origin = 1 - effect.state.spriteAlpha;
        float final = effect.state.spriteAlpha;
        if (includeDiabox) dUiManager.clickContainer.SetActive(false);
        while (t < 1)
        {
            t = Mathf.MoveTowards(t, 1, 1 / effect.time * Time.fixedDeltaTime);
            float alpha = origin + t * (final - origin);
            foreach (int i in GetDepthNum())
            {
                UI2DSprite ui = GetSpriteByDepth(i);
                ui.GetComponent<UIRect>().alpha = alpha;
            }
            if (includeBack) bgSprite.alpha = alpha;
            if (includeDiabox) dUiManager.mainContainer.GetComponent<UIWidget>().alpha = alpha;
            yield return null;
        }
        //删除
        foreach (int i in GetDepthNum())
        {
            RemoveSpriteByDepth(i);
        }
        if (includeBack) bgSprite.sprite2D = null;
        if (includeDiabox)dUiManager.mainContainer.SetActive(false);
        callback();
    }

    private List<int> GetDepthNum()
    {
        List<int> nums = new List<int>();
        foreach (Transform child in fgPanel.transform)
        {
            int x = Convert.ToInt32(child.name.Remove(0, 6));
            nums.Add(x);
        }
        return nums;
    }
}
