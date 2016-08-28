﻿using Assets.Script.GameStruct.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.GameStruct
{
    public class EnquireNode : GameNode
    {
        private EnquireManager enquireManager;
        private EnquireUIManager uiManager;
        private EnquireEvent enquireEvent;
        private GameNode next;
        private NodeFactory factory;
        //private int id;
        //private float x;
        //private float y;

        public EnquireNode(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps, string eventName)
            : base(gVars, lVars, root, ps)
        {
            Init(eventName);
            ps.SwitchTo_VerifyIterative_WithOpenCallback("Enquire_Panel", uiManager.WheelStart);
        }

        //public EnquireNode(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps, string eventName, int id, float x, float y) : this(gVars, lVars, root, ps, eventName)
        //{
        //    this.id = id;
        //    this.x = x;
        //    this.y = y;
        //}

        public void Init(string eventName)
        {
            enquireManager = EnquireManager.GetInstance();
            //获取uimanager
            uiManager = root.transform.Find("Avg_Panel/Enquire_Panel").GetComponent<EnquireUIManager>();
            uiManager.transform.gameObject.SetActive(true);

            factory = NodeFactory.GetInstance();

            this.enquireEvent = enquireManager.LoadEvent(eventName);;

            uiManager.SetEnquireEvent(enquireManager.currentEvent,
                enquireManager.visibleTestimony,
                enquireManager.pressedId,
                enquireManager.currentId);

            uiManager.SetEnquireNode(this);
        }

        public override void Update()
        { }

        public void EnquireExit(string entry)
        {
            next = factory.FindTextScript(entry);
            end = true;
        }

        public override GameNode NextNode()
        {
            return next;
        }
    }
}