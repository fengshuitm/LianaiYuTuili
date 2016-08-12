﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class T11002 : TextScript
    {
        public T11002(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps):base(gVars, lVars, root, ps) { }
        public override void Init()
        {
            base.Init();
            pieces = new List<Piece>()
            {
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "现在，审理喵星人的法庭正式开庭。"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "检事方早已做好了判决的准备。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "………………（汗）"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "…………"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "…………"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "…………"),
                //——背景 助手侧——
                //——立绘 苏梦忆侧面——
                f.t("【苏梦忆】", "赶紧说“辩护方准备完毕”啊！"),
                f.t("【李云萧】", "……为什么？"),
                f.t("【苏梦忆】", "怎么这么多话，先照着念！"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "辩护方准备完毕！"),
                //——背景 助手侧——
                //——立绘 苏梦忆侧面——
                f.t("【苏梦忆】", "这还差不多，终于上法庭了呢，好紧张！"),
                f.t("【李云萧】", "（谁能告诉我，现在这究竟是怎么一回事……）"),
                f.t("【苏梦忆】", "是吧？李云萧，你怎么了？"),
                f.t("【李云萧】", "我脑子里可是一片空白……"),
                f.t("【苏梦忆】", "紧张过头了吧？我们的委托人是谁还记得吗？"),
                f.t("【李云萧】", "委托人？是谁啊？（我可真不记得……）"),
                f.t("【李云萧】", "（等等，这个情形，我好像在哪里见过……）"),
                f.t("【苏梦忆】", "天！看来你离不开我这个助手了。"),
                f.t("【李云萧】", "（而且我也不记得，你是我的助手……）"),
                f.t("【苏梦忆】", "看到屏幕下方的调查记录按钮了么？"),
                f.t("【苏梦忆】", "至今为止所有的有关信息都会记录下来，点击它就可以看到里面的详细信息了。"),
                f.t("【李云萧】", "调查记录，里面就有吗……我看看……"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "李云萧，好像这是你第一次上庭辩护吧？"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "应、应该是的！（在我记忆里，以前应该还没有来过……）"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "律师的辩护事关被告的有罪还是无，身为律师的你这样的紧张可不好办呐。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "这个，我也没有办法……（谁第一次都会紧张的吧……）"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "这样啊……在审理正式开始前，我想先确认一下，你有没有准备好。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "知道了……（只能先这样做了……）"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "只是问你些简单的问题，请认真回答。"),
                f.t("【审判长】", "本次事件的被告人是？……请说说看。",() => pieces.Count)
                /*
                这里要跳到【选项】处
                */
            };
        }

        public override GameNode NextNode()
        {
            //return base.NextNode();
            Finish();
            return nodeFactory.FindTextScript("T11002");
            //return nodeFactory.GetMapNode();
        }

    }
}
