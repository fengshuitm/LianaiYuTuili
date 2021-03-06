﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Assets.Script.GameStruct;
using Assets.Script.GameStruct.Model;
using Assets.Script.UIScript;
using System.Linq;

/// <summary>
/// 
/// 
/// 操作顺序：
/// 1. 读取调查，对话，移动信息
/// 2. 根据当前状态切换panel
/// 3. 点击按钮切换当前状态
/// 4. 切换状态后根据状态切换panel（->2）
/// 5. 确定目标后更新数据，转换node
/// </summary>
public class DetectUIManager : MonoBehaviour
{
    //private GameObject investObject;
    //private UIPanel investPanel;

    private int eventID;
    private string currentPlace;
    private DetectPlaceSection section;
    private DetectManager detectManager;
    private DetectNode currentDetectNode;

    public GameObject charaContainer;
    private GameObject functionContainer, investContainer, dialogContainer, moveContainer, cancelButton;
    private UILabel hintinfoLabel;

    public Constants.DETECT_STATUS status
    {
        get { return DataManager.GetInstance().GetInTurnVar<Constants.DETECT_STATUS>("侦探模式"); }
        set { DataManager.GetInstance().SetInTurnVar("侦探模式", value); }
    }

    public PanelSwitch ps;
    public ImageManager im;

    void Awake()
    {
        //investObject = transform.parent.gameObject;
        //investPanel = investObject.GetComponent<UIPanel>();

        dialogContainer = this.transform.Find("Dialog_Container").gameObject;
        functionContainer = this.transform.Find("Function_Container").gameObject;
        investContainer = this.transform.Find("InvestButton_Container").gameObject;
        moveContainer = this.transform.Find("Move_Container").gameObject;
        cancelButton = this.transform.Find("But_Cancel").gameObject;

        hintinfoLabel = this.transform.Find("ButtomHelp_Container/Info_Label").GetComponent<UILabel>();
        detectManager = DetectManager.GetInstance();

        //status = Constants.DETECT_STATUS.FREE;
        eventID = -1;

    }

    private void LoadSection(DetectPlaceSection section)
    {
        this.section = section;
        //TODO: 更换背景
        ChangeBackground(section.imagename);
        SetInvest();
        SetDialog();
        SetMove();
    }

    private void ChangeBackground(string name)
    {
        im.MoveInit(im.LoadBackground(name));
    }

    #region 数据绑定
    public void SetDetectNode(DetectNode node, Dictionary<string,DetectPlaceSection> sections, string place ,int id)
    {
        currentDetectNode = node;
        if (eventID != id)
        {
            //调查大Node不同
            Debug.Log("node不同：载入 "+node.ToString());
            LoadSection(sections.FirstOrDefault().Value);
            currentPlace = section.place;
            SwitchStatus(Constants.DETECT_STATUS.FREE);
            eventID = id;
        }
        else if (currentPlace != place)
        {
            //地点不同
            Debug.Log("地点不同！当前：" + currentPlace + "即将进入 " + place);
            currentPlace = place;
            LoadSection(sections[currentPlace]);
            SwitchStatus(Constants.DETECT_STATUS.FREE);
        }
        else
        {
            LoadSection(sections[currentPlace]);
            SwitchStatus(status);
        }
    }

    private void SetInvest()
    {
        investContainer.transform.DestroyChildren();
        if(section.invests == null || section.invests.Count == 0)
        {
            functionContainer.transform.Find("But_Invest").gameObject.SetActive(false);
            return;
        }
        functionContainer.transform.Find("But_Invest").gameObject.SetActive(true);
        foreach (DetectInvest invest in section.invests)
        {
            //载入调查点
            if (!detectManager.IsVisible(invest)) return;
            GameObject investBtn = Resources.Load("Prefab/Invest_Choice") as GameObject;
            investBtn = NGUITools.AddChild(investContainer, investBtn);
            investBtn.transform.localPosition = invest.coordinate;
            
            UIButton btn = investBtn.GetComponent<UIButton>();
            /*
             * 测试用删除
             * btn.normalSprite2D = invest.icon;
             * btn.hoverSprite2D = invest.iconHover;
             * btn.pressedSprite2D = invest.iconHover;
            */

            InvestButton script = investBtn.GetComponent<InvestButton>();
            script.invest = invest;
            script.AssignDetectNode(currentDetectNode);
        }
    }

    private void SetDialog()
    {
        dialogContainer.transform.DestroyChildren();
        if (section.dialogs == null || section.dialogs.Count == 0)
        {
            functionContainer.transform.Find("But_Dialog").gameObject.SetActive(false);
            return;
        }
        functionContainer.transform.Find("But_Dialog").gameObject.SetActive(true);
        foreach (DetectDialog dialog in section.dialogs)
        {
            if (!detectManager.IsVisible(dialog)) return;
            GameObject dialogBtn = Resources.Load("Prefab/Dialog_Choice") as GameObject;
            dialogBtn = NGUITools.AddChild(dialogContainer, dialogBtn);

            dialogBtn.transform.Find("Label").GetComponent<UILabel>().text = dialog.dialog;
            //如果已经阅读过则标识
            dialogBtn.transform.Find("Readed_Label").gameObject.SetActive(detectManager.IsReaded(dialog));

            DialogButton script = dialogBtn.GetComponent<DialogButton>();
            script.dialog = dialog;
            script.AssignDetectNode(currentDetectNode);
        }
    }

    private void SetMove()
    {
        moveContainer.transform.DestroyChildren();
        if (section.moves == null || section.moves.Count == 0)
        {
            functionContainer.transform.Find("But_Move").gameObject.SetActive(false);
            return;
        }

        functionContainer.transform.Find("But_Move").gameObject.SetActive(true);
        foreach (string move in section.moves)
        {
            GameObject moveBtn = Resources.Load("Prefab/Move_Choice") as GameObject;
            moveBtn = NGUITools.AddChild(moveContainer, moveBtn);

            moveBtn.transform.Find("Label").GetComponent<UILabel>().text = move;
            moveBtn.GetComponent<MoveButton>().AssignUIManager(this);
            moveBtn.GetComponent<MoveButton>().place = move;
        }
    }
    #endregion

    public void SwitchStatus(Constants.DETECT_STATUS nextStatus)
    {
        Debug.Log("next status:" + nextStatus);
        switch (nextStatus)
        {
            case Constants.DETECT_STATUS.FREE:
                ps.SwitchTo_VerifyIterative("Function_Container");
                charaContainer.SetActive(true);
                cancelButton.SetActive(false);
                break;
            case Constants.DETECT_STATUS.DIALOG:
                ps.SwitchTo_VerifyIterative("Dialog_Container");
                charaContainer.SetActive(false);
                cancelButton.SetActive(true);
                break;
            case Constants.DETECT_STATUS.INVEST:
                ps.SwitchTo_VerifyIterative("InvestButton_Container");
                charaContainer.SetActive(false);
                cancelButton.SetActive(true);
                break;
            case Constants.DETECT_STATUS.MOVE:
                ps.SwitchTo_VerifyIterative("Move_Container");
                charaContainer.SetActive(false);
                cancelButton.SetActive(true);
                break;
            default:
                break;
        }
        this.status = nextStatus;
        DataManager.GetInstance().SetInTurnVar("侦探模式", nextStatus);
    }

    public void ShowCharaContainer()
    {
        charaContainer.SetActive(true);
    }

    public void SetHint(string str)
    {
        hintinfoLabel.text = str;
    }

    public void MovePlace(string place)
    {
        Debug.Log("移动至地点：" + place);
        currentDetectNode.MoveTo(place);
    }

}
