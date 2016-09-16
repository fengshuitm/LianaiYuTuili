﻿using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using Assets.Script.GameStruct.Model;

namespace Assets.Script.GameStruct
{
    public class DetectManager
    {
        private static DetectManager instance;
        private static readonly string DETECT_PATH = "Text/Detect/";
        private static readonly string DETECT_DEBUG_PATH = "Text/DetectDebug/";

        private DataManager manager;
        private Dictionary<string, DetectEvent> detectEvents;

        private DetectEvent currentEvent
        {
            set { manager.SetInTurnVar("当前侦探事件", value); }
            get { return manager.GetInTurnVar<DetectEvent>("当前侦探事件"); }
        }

        private List<string> knownInfo
        {
            set { manager.SetInTurnVar("侦探事件已知信息", value); }
            get { return manager.GetInTurnVar<List<string>>("侦探事件已知信息"); }
        }


        private Dictionary<string, bool> placeStatus
        {
            set { manager.SetGameVar("侦探事件位置状态", value); }

            get { return manager.GetGameVar<Dictionary<string, bool>>("侦探事件位置状态"); }
        }
        public static DetectManager GetInstance()
        {
            if (instance == null) instance = new DetectManager();
            return instance;
        }

        internal bool IsEntered(string place)
        {
            return placeStatus[place];
        }

        public void EnterPlace(string place)
        {
            placeStatus[place] = true;
        }

        private DetectManager() { }

        public void Init(Dictionary<string, DetectEvent> detectEvents, DataManager manager)
        {
            this.manager = manager;
            this.detectEvents = detectEvents;

            if (!manager.ContainsInTurnVar("侦探事件已知信息"))
            {
                knownInfo = new List<string>();
            }

            if (!manager.ContainsInTurnVar("侦探事件位置状态"))
            {
                placeStatus = new Dictionary<string, bool>();
            }
        }

        public DetectEvent GetCurrentEvent() { return currentEvent; }

        public bool IsVisible(DetectInvest invest)
        {
            if (invest.condition != null && invest.condition.Count > 0)
            {
                foreach (string condition in invest.condition)
                {
                    if (!knownInfo.Contains(condition)) return false;
                }
            }
            return true;
        }

        public bool IsVisible(DetectDialog dialog)
        {
            if (dialog.condition != null && dialog.condition.Count > 0)
            {
                foreach (string condition in dialog.condition)
                {
                    if (!knownInfo.Contains(condition)) return false;
                }
            }
            return true;
        }


        public void LoadEvent(string key)
        {
            currentEvent = detectEvents[key];
            foreach (KeyValuePair<string, DetectPlaceSection> kv in currentEvent.sections)
            {
                if (placeStatus.ContainsKey(kv.Value.place))
                {
                    placeStatus[kv.Value.place] = false;
                }
                else
                {
                    placeStatus.Add(kv.Value.place, false);
                }

            }


            //if (!detectEvents.ContainsKey(key)) throw new Exception();

            // 将数据存入local variable,并且根据其状态复写数据
            //if (lVars.ContainsKey("当前侦探事件"))
            //{
            //    lVars["当前侦探事件"] = currentEvent;
            //}
            //else
            //{
            //    lVars.Add("当前侦探事件", currentEvent);
            //}

            //if (lVars.ContainsKey("侦探事件已知信息"))
            //{
            //    knownInfo = (List<string>)lVars["侦探事件已知信息"];
            //}
            //else
            //{
            //    knownInfo = new List<string>();
            //    lVars.Add("侦探事件已知信息", knownInfo);
            //}

            //if (lVars.ContainsKey("侦探事件位置状态"))
            //{
            //    placeStatus = (Dictionary<string, bool>)lVars["侦探事件位置状态"];
            //    foreach (KeyValuePair<string, DetectPlaceSection> kv in currentEvent.sections)
            //    {
            //        if (placeStatus.ContainsKey(kv.Value.place))
            //        {
            //            placeStatus[kv.Value.place] = false;
            //        }
            //        else
            //        {
            //            placeStatus.Add(kv.Value.place, false);
            //        }
            //    }
            //}
            //else
            //{
            //    placeStatus = new Dictionary<string, bool>();
            //    foreach (KeyValuePair<string, DetectPlaceSection> kv in currentEvent.sections)
            //    {
            //        placeStatus.Add(kv.Value.place, false);
            //    }

            //    lVars.Add("侦探事件位置状态", placeStatus);
            //}
        }

        private static DetectEvent LoadSingleDetectEvent(TextAsset text)
        {
            JsonData jsondata = JsonMapper.ToObject(text.text);

            return new DetectEvent(jsondata);
        }

        public static Dictionary<string, DetectEvent> GetStaticDetectEvents()
        {
            Dictionary<string, DetectEvent> events = new Dictionary<string, DetectEvent>();
            string path = Constants.DEBUG ? DETECT_DEBUG_PATH : DETECT_PATH;
            Debug.Log("读取侦探表");
            foreach (TextAsset text in Resources.LoadAll<TextAsset>(path))
            {
                Debug.Log("读取：" + text.name);
                events.Add(text.name, LoadSingleDetectEvent(text));
            }

            return events;
        }

        public bool IsCurrentEventFinished()
        {
            foreach (string s in knownInfo) Debug.Log(s);
            foreach (string s in currentEvent.conditions) Debug.Log(s);
            return currentEvent.conditions.Except(knownInfo).ToArray().Length == 0;
        }
    }
}
