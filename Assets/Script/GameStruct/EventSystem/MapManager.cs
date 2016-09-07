﻿using UnityEngine;
using System.Collections;
using Assets.Script.GameStruct.Model;
using System;

/**
 * MapManager: 
 * 整个游戏只允许一个，作为MapPanel的组件，不能被删除
 * 控制MapPanel下面的各部分与之交互
 * 提供方法供旗下按钮调用，并修改游戏数据
 * 实现与AVG模块的互动，推动游戏进程
 */



namespace Assets.Script.GameStruct.EventSystem
{
    public class MapManager : MonoBehaviour, IPanelManager
    {

        private GameManager gm;
        private GameObject mapObject;
        private UIPanel mapPanel;
        private UILabel daylabel, datelabel;
        private UILabel wenlabel, lilabel, tilabel, yilabel, zhailabel;
        private UILabel energylabel, moneylabel, ranklabel;

        void Awake()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            mapObject = transform.parent.gameObject;
            daylabel = transform.Find("Time_Container/Day_Label").gameObject.GetComponent<UILabel>();
            datelabel = transform.Find("Time_Container/Date_Label").gameObject.GetComponent<UILabel>();
            moneylabel = transform.Find("CharaInfo_Container/Number_Container/Money_Label").gameObject.GetComponent<UILabel>();
            wenlabel = transform.Find("CharaInfo_Container/Number_Container/Wen_Label").gameObject.GetComponent<UILabel>();
            lilabel = transform.Find("CharaInfo_Container/Number_Container/Li_Label").gameObject.GetComponent<UILabel>();
            tilabel = transform.Find("CharaInfo_Container/Number_Container/Ti_Label").gameObject.GetComponent<UILabel>();
            yilabel = transform.Find("CharaInfo_Container/Number_Container/Yi_Label").gameObject.GetComponent<UILabel>();
            zhailabel = transform.Find("CharaInfo_Container/Number_Container/Zhai_Label").gameObject.GetComponent<UILabel>();
            energylabel = transform.Find("CharaInfo_Container/Number_Container/Energy_Label").gameObject.GetComponent<UILabel>();
            ranklabel = transform.Find("CharaInfo_Container/Number_Container/Rank_Label").gameObject.GetComponent<UILabel>();
        }

        void OnEnable()
        {
            UIFresh();
        }

        void Update()
        {

        }

        public IEnumerator Open()
        {
            mapPanel.alpha = 0;
            yield return StartCoroutine(FadeIn());
        }

        public IEnumerator Close()
        {
            yield return StartCoroutine(FadeOut());
        }

        IEnumerator FadeIn()
        {
            mapObject.SetActive(true);
            float x = 0;
            while (x < 1)
            {
                x = Mathf.MoveTowards(x, 1, Time.deltaTime);
                mapPanel.alpha = x;
                yield return null;
            }
        }

        IEnumerator FadeOut()
        {
            float x = 1;
            while (x > 0)
            {
                x = Mathf.MoveTowards(x, 0, Time.deltaTime);
                mapPanel.alpha = x;
                yield return null;
            }
            mapObject.SetActive(false);
        }

        public void UIFresh()
        {
            //Debug.Log("MapManager UIFresh");
            Player player = Player.GetInstance();

            Hashtable gVars = DataManager.GetInstance().GetGameVars();
            DateTime date = (DateTime)gVars["日期"];
            daylabel.text = date.Month + "月" + date.Day + "日";
            datelabel.text = Constants.WEEK_DAYS[Convert.ToInt16(date.DayOfWeek)];

            moneylabel.text = player.GetBasicStatus("金钱").ToString();
            wenlabel.text = player.GetBasicStatus("文科").ToString();
            lilabel.text = player.GetBasicStatus("理科").ToString();
            yilabel.text = player.GetBasicStatus("艺术").ToString();
            tilabel.text = player.GetBasicStatus("体育").ToString();
            zhailabel.text = player.GetBasicStatus("宅力").ToString();
            energylabel.text = player.EnergyPoint.ToString();

            ranklabel.text = "-";
        }

        //public void GoPlace(int placeid)
        //{
        //    //gm.placeid = placeid.ToString();
        //    //gm.MapEvent();
        //    //UIFresh();
        //}
    }
}
