﻿using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using Assets.Script.UIScript;
using Assets.Script.GameStruct;

/**
 * PanelSwitch: 
 * 整个游戏只允许一个，作为GameManager的组件，不能删除
 * 保存其他模块间切换函数，供其他Manager调用
 * 组件示意：
 * Avg_Panel 文字模式大块
 * Title_Panel 开始界面大块
 * System_Panel 系统大块
 * Map_Panel 地图模式大块
 * Edu_Panel 养成模式大块
 * Phone_Panel 电子手册大块
 */
public class PanelSwitch : MonoBehaviour
{

    private GameObject root;

    /// <summary>
    /// 存储面板名称
    /// </summary>
    public readonly List<String> PANEL_NAMES = new List<String>()
    {
        "Avg",
        "Title",
        "System",
        "Map",
        "Edu",
        "Phone",
        "Fin"
    };

    Dictionary<string, GameObject> panels;
    private string current;
    private List<string> currentPanelPath;
    private FadeTreeIterator iterator;

    public void HidePanel(string name)
    {
        panels[name].GetComponent<UIPanel>().alpha = 0;
    }

    /// <summary>
    ///  用于验证新的PanelSwitch想法的函数
    /// </summary>
    /// <param name="next"></param>
    public void SwitchTo_IdeaVerify(string next)
    {
        // TODO 想办法直接获取相应的符合接口的component
        PanelTreeInterface currentFade = panels[current].GetComponent<PanelTreeInterface>(),
            nextFade = panels[next].GetComponent<PanelTreeInterface>();

        panels[current].GetComponent<UIPanel>().alpha = 1;
        currentFade.Close(() =>
        {
            panels[current].SetActive(false);
            panels[next].GetComponent<UIPanel>().alpha = 0;
            panels[next].SetActive(true);
            nextFade.Open();
        });
    }

    public void SwitchTo_VerifyIterative(string next)
    {
        SwitchTo_VerifyIterative(next, () => { }, () => { });
    }

    public void SwitchTo_VerifyIterative(string next, UIAnimationCallback closeCallback)
    {
        SwitchTo_VerifyIterative(next, closeCallback, () => { });
    }
    
    public void SwitchTo_VerifyIterative_WithOpenCallback(string next, UIAnimationCallback openCallback)
    {
        SwitchTo_VerifyIterative(next, () => { }, openCallback);
    }

    public void SwitchTo_VerifyIterative(string next, UIAnimationCallback closeCallback,
        UIAnimationCallback openCallback)
    {
        //计算板块链：共有链，关闭链，开启链
        //例：Avg切换到Enqurie：关闭DialogBox 打开Enquire 共有Avg
        List<string>[] result = GetListIntersectAndDifference(currentPanelPath, iterator.pathTable[next]);
        List<string> sameChain = result[0], closeChain = result[1], openChain = result[2];

        //自己切换自己的情形
        if (openChain.Count == 0 && closeChain.Count == 0)
        {
            closeChain = sameChain.GetRange(sameChain.Count - 1, 1);
            openChain = sameChain.GetRange(sameChain.Count - 1, 1);
        }

        //Debug.Log("currentPath:" + ConvertToStringPath(currentPanelPath));
        //Debug.Log("sameChain:" + ConvertToStringPath(sameChain));
        //Debug.Log("closeChain:" + ConvertToStringPath(closeChain));
        //Debug.Log("openChain:" + ConvertToStringPath(openChain));

        CloseChain(new Stack<string>(closeChain), () =>
        {
            SetActiveChain(false, closeChain);
            SetActiveChain(true, openChain); //可能需要设置打开时初始条件
            closeCallback();
            OpenChain(new Queue<string>(openChain), openCallback);
        });
    }

    private void SetActiveChain(bool isOpne, List<string> chain)
    {
        //按照开启链，打开/关闭GameObject，开启时设置alpha为0
        foreach (string s in chain)
        {
            GameObject go = iterator.satellightTable[s].gameObject;
            if (isOpne)
            {
                UIRect up = go.GetComponent<UIRect>();
                if (up != null) up.alpha = 0;
            }
            go.SetActive(isOpne);
        }
    }

    private void CloseChain(Stack<string> closeStack, UIAnimationCallback closeFinishCallback)
    {
        if (closeStack.Count == 0 || closeStack.Peek() == null)
        {
            //已将所有面板关闭
            closeFinishCallback();
            return;
        }
        else
        {
            string close = closeStack.Pop();
            currentPanelPath.Remove(close);
            //Debug.Log("path update:" + ConvertToStringPath(currentPanelPath));
            iterator.satellightTable[close].Close(() =>
            {
                CloseChain(closeStack, closeFinishCallback);
            });
        }

    }

    private void OpenChain(Queue<string> openQueue, UIAnimationCallback openFinishCallback)
    {
        if (openQueue.Count == 0 || openQueue.Peek() == null)
        {
            //已将所有面板开启
            openFinishCallback();
            return;
        }
        else
        {
            string open = openQueue.Dequeue();
            currentPanelPath.Add(open);
            //Debug.Log("path update:" + ConvertToStringPath(currentPanelPath));
            iterator.satellightTable[open].Open(() =>
            {
                OpenChain(openQueue, openFinishCallback);
            });
        }
    }

    private string ConvertToStringPath(List<string> strs)
    {
        string path = "";
        foreach (string str in strs)
        {
            path += str + ">";
        }
        return path;
    }

    private List<string>[] GetListIntersectAndDifference(List<string> fst, List<string> snd)
    {
        List<string>[] difference = new List<string>[3];

        difference[0] = fst.Intersect(snd).ToList();
        difference[1] = fst.Except(snd).ToList();
        difference[2] = snd.Except(fst).ToList();

        return difference;
    }


    // Use this for initialization
    public void Init()
    {
        root = GameObject.Find("UI Root");
        //搜索到所有的Panel原件
        panels = new Dictionary<string, GameObject>();
        for (int i = 0; i < PANEL_NAMES.Count; i++)
        {
            GameObject panelObj = root.transform.Find(PANEL_NAMES[i] + "_Panel").gameObject;
            panels.Add(PANEL_NAMES[i], panelObj);
        }
        //游戏初始界面打开情况
        current = "Title";
        currentPanelPath = new List<string>()
        {
            //"UI Root", "Title_Panel"
            "UI Root"
        };

        iterator = new FadeTreeIterator(root.GetComponent<PanelTreeInterface>());
        iterator.Init();
        //iterator.PrintTree();
    }

    //右键界面操作 全局函数
    public void RightClick()
    {
        if (panels["Title"].activeSelf)
        {
            //标题画面被打开时
            TitleUIManager tm = panels["Title"].GetComponent<TitleUIManager>();
            switch (tm.status)
            {
                case Constants.TITLE_STATUS.EXTRA:
                    tm.RightClickReturn();
                    break;
                case Constants.TITLE_STATUS.GALLERY:
                    if (GameObject.Find("Large_Container") != null && GameObject.Find("Large_Container").activeSelf)
                    {
                        //tm.ClosePic();
                    }
                    else
                    {
                        tm.CloseGallery();
                    }
                    break;
                case Constants.TITLE_STATUS.MUSIC:
                    tm.CloseMusic();
                    break;
                case Constants.TITLE_STATUS.RECOLL:
                    tm.CloseRecollection();
                    break;
                case Constants.TITLE_STATUS.ENDING:
                    tm.CloseEnding();
                    break;
                default:
                    break;
            }
        }

        if (panels["System"].activeSelf)
        {
            //系统菜单打开时
            GameObject wc = panels["System"].transform.Find("Warning_Container").gameObject;
            if (wc != null && wc.activeSelf)
            {
                //警告窗口开启 则关闭
                wc.SetActive(false);
            }
            else
            {
                //否则关闭菜单
                panels["System"].GetComponent<SystemUIManager>().Close();
            }
        }
        else
        {
            //其他情形
            if (panels["Avg"].activeSelf || panels["Map"].activeSelf || panels["Edu"].activeSelf)
            {
                if (panels["Phone"].activeSelf)
                {
                    panels["Phone"].GetComponent<NoteUIManager>().ReturnIndex();
                }
                else
                {
                    //Debug.Log("Open Menu!");
                    panels["System"].SetActive(true);
                    panels["System"].GetComponent<SystemUIManager>().Open();
                }
            }
        }

    }

    //滚轮向上操作
    public void MouseUpScroll(float delta)
    {
        //仅纯avg状态下可以打开BackLog
        if (panels["Avg"].activeSelf && !panels["Phone"].activeSelf)
        {
            GameObject backCon = panels["System"].transform.Find("Backlog_Container").gameObject;
            //Backlog关闭 才能打开
            if (!backCon.activeSelf && !DataManager.GetInstance().blockBacklog)
            {
                panels["System"].SetActive(true);
                panels["System"].GetComponent<UIPanel>().alpha = 1;
                panels["System"].GetComponent<SystemUIManager>().OpenBacklog();
            }
            else
            {
                //如果已经打开了Backlog 则向上滚动条
                if (backCon.GetComponent<BacklogUIManager>().IsEnoughRow())
                {
                    UIScrollView scroll = backCon.transform.Find("Scroll View").GetComponent<UIScrollView>();
                    scroll.Scroll(delta * 10);
                }
               
            }
        }
    }

    //滚轮朝下操作
    public void MouseDownScroll(float delta)
    {
        //仅当avg开启时有效
        if (panels["Avg"].activeSelf && !panels["Phone"].activeSelf)
        {
            GameObject backCon = panels["System"].transform.Find("Backlog_Container").gameObject;
            //当Backlog打开 则滚动条向下
            if (backCon.activeSelf)
            {
                BacklogUIManager uim = backCon.GetComponent<BacklogUIManager>();
                float value = backCon.transform.Find("ScrollBar").GetComponent<UIScrollBar>().value;
                if(!uim.IsEnoughRow() || value >= 1)
                {
                    //当文本不足 或 滚动条到底时 关闭backlog
                    panels["System"].GetComponent<SystemUIManager>().Close();
                }
                else
                {
                    backCon.transform.Find("Scroll View").GetComponent<UIScrollView>().Scroll(delta * 10);
                }
            }
            else
            {
                //否则 相当于左键
                GameObject clickCon = panels["Avg"].transform.Find("DialogBox_Panel/Click_Container").gameObject;
                clickCon.GetComponent<Click_Next>().ClickE();
            }

        }
    }

    ///--------------------以下是旧函数----------------------------------
    /// <summary>
    /// 切换面板,TODO:可能需要对每个Panel做一个切换特效？
    /// </summary>
    /// <param name="panel">切换目标面板</param>
    /// <param name="fadein">淡入时间，默认0.3s</param>
    /// <param name="fadeout">淡出时间，默认0.3s</param>
    public void SwitchTo(string panel, float fadein = 0.3f, float fadeout = 0.3f)
    {
        Debug.Log("从：" + current + "切换:" + panel);

        if (panels.ContainsKey(panel))
        {
            GameObject currentPanel = panels[current];
            GameObject nextPanel = panels[panel];
            //Debug.Log(panel);
            //nextPanel.SetActive(true);
            //nextPanel.GetComponent<UIPanel>().alpha = 0;
            //yield return new WaitForSeconds(1);

            StartCoroutine(Switch(currentPanel, nextPanel, fadein, fadeout));
            current = panel;
        }
        else
        {
            Debug.Log("Can't find panel: " + panel);
        }
    }

    private IEnumerator Switch(GameObject currentPanel, GameObject nextPanel, float fadein, float fadeout)
    {
        PanelFade2 current = currentPanel.GetComponent<PanelFade2>(),
                   next = nextPanel.GetComponent<PanelFade2>();
        current.Close(fadeout);
        yield return new WaitForSeconds(fadeout + 1f);
        nextPanel.SetActive(true);
        next.Open(fadein);

    }

    IEnumerator Fadein(float time, GameObject target)
    {
        UIPanel panel = target.GetComponent<UIPanel>();
        float f = time == 0 ? 1 : 0;
        panel.alpha = f;
        target.SetActive(true);
        while (f < 1f)
        {
            f = Mathf.MoveTowards(f, 1f, Time.deltaTime / time);
            panel.alpha = f;
            yield return null;
        }
    }

    IEnumerator DelaySec(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
    IEnumerator Fadeout(float time, GameObject target)
    {
        UIPanel panel = target.GetComponent<UIPanel>();
        float f = time == 0 ? 0 : 1;
        panel.alpha = f;
        while (f > 0)
        {
            f = Mathf.MoveTowards(f, 0, Time.deltaTime / time);
            panel.alpha = f;
            yield return null;
        }
        target.SetActive(false);
    }

}
