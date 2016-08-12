﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class T12004 : TextScript
    {
        public T12004(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps):base(gVars, lVars, root, ps) { }
        public override void Init()
        {
            base.Init();
            pieces = new List<Piece>()
            {
                //——背景 走廊——
                f.t("【李云萧】", "（能够调查的地方已经全部看过了。）"),
                f.t("【李云萧】", "（接下来就是，这个女生了。）"),
                f.t("【李云萧】", "想必你就是第一目击者了？我叫李云萧，请问你叫什么？"),
                f.t("【女生】", "想不到，居然有人连我也不认识！"),
                f.t("【李云萧】", "抱歉，我刚转校过来……"),
                f.t("【李云萧】", "（话说回来，我为什么要认识你……）"),
                f.t("【苏梦忆】", "李云萧，她叫……"),
                f.t("【女生】", "哼！整个年级没有不知道我的人，你是第一个！"),
                f.t("【叶枫婷】", "我就是从进入高中开始，语文成绩一直年级第一的，叶枫婷！"),
                f.t("【李云萧】", "（好厉害……那么其他科目呢？）"),
                f.t("【叶枫婷】", "现在，担任全年级的语文课总代表！"),
                f.t("【李云萧】", "苏梦忆，总代表是？"),
                f.t("【苏梦忆】", "是从每个班级的课代表中选出来的，类似老师助理的职位。"),
                f.t("【叶枫婷】", "你们的考试成绩，有时候就是我给的分，明白吗？"),
                f.t("【叶枫婷】", "如果你们不交作业，被我知道的话……"),
                f.t("【李云萧】", "……（你想怎么样？）"),
                f.t("【叶枫婷】", "总而言之，来偷试卷的就是他，我亲眼看到的。"),
                f.t("【李云萧】", "叶枫婷，这可不是开玩笑……"),
                f.t("【李云萧】", "又或者说你有证据？那么能不能请你说下你的理由。"),
                //——开始证言：背景变黑 立绘 叶枫婷——
                //～看到了什么 1～
                //——BGM 询问——
                f.t("【叶枫婷】", "上午的课结束后，我就留在教室里休息。"),
                f.t("【叶枫婷】", "11点50分左右，从办公室里传出了奇怪的声音。"),
                f.t("【叶枫婷】", "我赶紧用钥匙打开办公室，就发现他站在办公桌旁边。"),
                f.t("【叶枫婷】", "仔细一看，他的手里居然拿着开着的试卷袋。"),
                f.t("【叶枫婷】", "一定就是他潜入了办公室，偷走了试卷！"),
                //——证言完毕：背景变黑 BGM淡出——
                f.t("【李云萧】", "嗯……"),
                f.t("【叶枫婷】", "我的怀疑并不是没有根据吧？人证物证俱在！"),
                f.t("【苏梦忆】", "但是，喵星人只是拿起了桌上的袋子而已。"),
                f.t("【叶枫婷】", "那你告诉我，地上已经被拿出来的试卷是怎么回事？"),
                f.t("【苏梦忆】", "这个……"),
                f.t("【叶枫婷】", "他又为什么选择在办公室没有人的时候来？"),
                f.t("【叶枫婷】", "这种时候进办公室，而且又拿着密封袋，不是很可疑吗？"),
                f.t("【苏梦忆】", "李云萧，怎么办？"),
                f.t("【李云萧】", "的确，喵星人的一系列动作非常可疑。眼下也没有可以证明他没拿的证据。"),
                f.t("【李云萧】", "但是她怀疑的理由，还有些细节得问清楚。"),
                f.t("【李云萧】", "（她说的话，乍看之下没有问题，但不可能滴水不漏的。）"),
                f.t("【李云萧】", "（刚才的理由中，也有些令我在意的部分……）"),
                f.t("【李云萧】", "（先尝试着威慑看看，试着询问更加详细的情况，套取些情报吧。）",() => pieces.Count),
                /*
                这里跳转【询问】
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
