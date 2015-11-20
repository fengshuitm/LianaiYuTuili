﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/**
 * PanelSwitch: 
 * 整个游戏只允许一个，作为GameManager的组件，不能删除
 * 保存其他模块间切换函数，供其他Manager调用
 * 修改相应参数即修改显示效果
 */
public class PanelSwitch : MonoBehaviour
{

    private GameObject root;

    public readonly string[] PANEL_NAMES =
    {
        "Avg",
		"Title",
		"Invest",
		"Detect",
		//"SysMenu",
        "System",
		"Enquire",
		"Negotiate",
		"Map",
		"Edu",
		"Phone"
    };
    //private GameObject avgpanel;
    //private GameObject syspanel;
    //private GameObject investpanel;
    //private GameObject detectpanel;
    //private GameObject titlepanel;
    //private GameObject enquirepanel;
    //private GameObject negotiatepanel;
    //private GameObject mappanel;
    //private GameObject edupanel;
    //private GameObject phonepanel;

    Dictionary<string, GameObject> panels;
    private string current;
    //private UIPanel panel;

    // Use this for initialization
    void Start()
    {
        root = GameObject.Find("UI Root");
        panels = new Dictionary<string, GameObject>();
        for(int i = 0; i < PANEL_NAMES.Length; i++)
        {
            Debug.Log("panel = " + PANEL_NAMES[i]);
            panels.Add(PANEL_NAMES[i], root.transform.Find(PANEL_NAMES[i] + "_Panel").gameObject);
        }
        current = "Title";
        
        StartCoroutine(Fadein(1, panels[current]));

    }
    //开启关闭系统菜单
    public void OpenMenu()
    {
        if (!panels["Title"].activeSelf)//标题除外
        {
            //if (panels["SysMenu"].activeSelf)//已经开启的情况
            if (panels["System"].activeSelf)
            {
                //StartCoroutine(Fadeout(0.5f, panels["SysMenu"]));
                StartCoroutine(Fadeout(0.5f, panels["System"]));
                Debug.Log("Close Menu!");
            }
            else//关闭的情况
            {
                StartCoroutine(Fadein(0.5f, panels["SysMenu"]));
                Debug.Log("Open Menu!");
            }
        }
    }
    public void SwitchTo(string panel, float fadein = 0.5f, float fadeout = 0.5f)
    {
        for (int i = 0; i < PANEL_NAMES.Length; i++)
        {
            if (panel == PANEL_NAMES[i])
            {
                StartCoroutine(Fadeout(fadeout, panels[current]));
                current = panel;
                StartCoroutine(Fadein(fadein, panels[current]));
                return;
            }
        }
        Debug.Log("Can't find panel: " + panel);

    }
    //进入调查（只与avg交互）
    //public void OpenInvest()
    //{
    //    StartCoroutine(Fadein(0, investpanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //}
    //public void CloseInvest()
    //{
    //    StartCoroutine(Fadein(0, avgpanel));
    //    StartCoroutine(Fadeout(0, investpanel));
    //}
    ////进入推理（只与avg交互）
    //public void OpenDetect()
    //{
    //    StartCoroutine(Fadein(0, detectpanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //}
    //public void CloseDetect()
    //{
    //    StartCoroutine(Fadein(0, avgpanel));
    //    StartCoroutine(Fadeout(0, detectpanel));
    //}
    ////进入询问（只与avg交互）
    //public void OpenEnquire()
    //{
    //    StartCoroutine(Fadein(0, enquirepanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //}
    //public void CloseEnquire()
    //{
    //    StartCoroutine(Fadeout(0, enquirepanel));
    //    StartCoroutine(Fadein(0, avgpanel));
    //}
    ////进入谈判（只与avg交互）
    //public void OpenNegotiate()
    //{
    //    StartCoroutine(Fadein(0, negotiatepanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //}
    //public void CloseNegotate()
    //{
    //    StartCoroutine(Fadeout(0, negotiatepanel));
    //    StartCoroutine(Fadein(0, avgpanel));
    //}
    ////养成进大地图
    //public void EduToMap()
    //{
    //    StartCoroutine(Fadein(0.5f, mappanel));
    //    StartCoroutine(Fadeout(0, edupanel));
    //}
    ////文字进大地图（例：周六大地图事件结束后）
    //public void AvgToMap()
    //{
    //    StartCoroutine(Fadein(0.5f, mappanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //    mappanel.GetComponent<MapManager>().UIFresh();
    //}
    ////大地图进文字（大地图事件）
    //public void MapToAvg()
    //{
    //    StartCoroutine(Fadein(0.5f, avgpanel));
    //    StartCoroutine(Fadeout(0, mappanel));
    //}
    ////文字进养成（例：平日随机事件结束后）
    //public void AvgToEdu()
    //{
    //    StartCoroutine(Fadein(0.5f, edupanel));
    //    StartCoroutine(Fadeout(0, avgpanel));
    //    edupanel.GetComponent<EduManager>().UIFresh();
    //}
    ////养成进文字（平日随机事件）
    //public void EduToAvg()
    //{
    //    StartCoroutine(Fadein(0.5f, avgpanel));
    //    StartCoroutine(Fadeout(0, edupanel));
    //}
    ////打开手机
    public void OpenPhone()
    {
        StartCoroutine(Fadein(0.2f, panels["Phone"]));
    }
    public void ClosePhone()
    {
        StartCoroutine(Fadeout(0.2f, panels["Phone"]));
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