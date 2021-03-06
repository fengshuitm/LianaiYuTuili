﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class T11006 : TextScript
    {
        public T11006(DataManager manager, GameObject root, PanelSwitch ps):base(manager, root, ps) { }
        public override void InitText()
        {
            
            pieces = new List<Piece>()
            {
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "证人，姓名和职业。"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "张傲，本案的刑警，现在在本地派出所工作。"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "那么，就请你来说下案件的经过。"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "好的，交给我吧。"),
                f.t("【张傲】", "这是现场的示意图，请看。"),
                //——示意图——
                f.t("【张傲】", "盗窃事件发生于前天的中午，案发地点则是4楼的办公室。"),
                f.t("【张傲】", "上午，老师将试卷收在试卷袋中，放在了窗边的办公桌上。"),
                f.t("【张傲】", "之后，老师用钥匙锁好门后，离开了办公室。"),
                f.t("【张傲】", "但是，当老师回来的时候，试卷袋已经被人打开了。"),
                f.t("【张傲】", "也就是说，这期间，有人偷偷进入了办公室，打开了密封的试卷袋，将里面的试卷偷了出来。"),
                f.t("【张傲】", "这是当时的平面示意图，现在作为证据提交。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "受理。"),
                //——证据提交——
                f.t("【审判长】", "那么，被偷走的试卷找回来了没有？"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "其实试卷并没有被偷走，所有的试卷都留在了现场。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "哦？没有被偷走的试卷，这是怎么一回事？"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "审判长，先请您看下案发现场的照片。"),
                //——照片示意图——
                f.t("【审判长】", "嗯？这些碎了一地的玻璃是怎么一回事？"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "试卷之所以没有被偷走，是因为期间发生了点意外。"),
                f.t("【张傲】", "据调查，午休的时候，办公室的窗户被人打碎了。"),
                f.t("【张傲】", "窗户破碎时发出巨大的响声，一定会引起其他人的注意。"),
                f.t("【张傲】", "当时在现场的人，一定非常慌张，所以立即逃离了现场。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "但是就算偷窃过程中有巨响，也可以带着试卷逃走啊。"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "唔……也有这个可能。"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "审判长，我来解释一下。"),
                f.t("【沈尘业】", "这是掉落在现场的试卷，现在作为证据提交。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "受理。"),
                //——证据提交——
                f.t("【审判长】", "嗯？这个试卷好像已经填好答案了……"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "没错，袋子中放的是当天上午结束的语文考试试卷。"),
                f.t("【沈尘业】", "被告人真正的目的，并不是将试卷偷出办公室。"),
                f.t("【沈尘业】", "而是从试卷袋中偷出自己的试卷，修改答案。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "原来如此。"),
                f.t("【审判长】", "不过，你为什么逮捕了本案的被告人？"),
                f.t("【审判长】", "章傲刑警，请你证言。"),
                //——开始证言：背景变黑 立绘 张傲——
                //～逮捕的理由～
                //——BGM 询问——
                f.t("【张傲】", "案发时，4楼的办公室处于完全封闭的状态。"),
                f.t("【张傲】", "办公室的门没有发现被破坏的痕迹，只能用钥匙打开。"),
                f.t("【张傲】", "办公室又位于教学楼的4楼，也不可能从窗外进入。"),
                f.t("【张傲】", "而当时持有钥匙的，除了老师以外，就只有身为学习委员的被告人。"),
                f.t("【张傲】", "所以，只有被告能进入这密室般的办公室。"),
                //——证言完毕：背景变黑 BGM淡出——
                f.t("【张傲】", "因此，我们逮捕了被告。"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "肃静！肃静！肃静！"),
                f.t("【审判长】", "嗯，原来如此……"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "辩护律师，你有什么看法吗？"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "……（槽点太多，完全不知道该说什么。）"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "看来，辩护律师是没有话讲了。"),
                //——背景 助手侧——
                //——立绘 苏梦忆侧面——
                f.t("【苏梦忆】", "李云萧，你怎么不说话呀？对面这么小瞧我们，赶紧反击啊！"),
                f.t("【李云萧】", "就算你这么说，我也不知道该怎么反击啊……"),
                f.t("【苏梦忆】", "你、你骗我，你之前明明说能解决的！呜……"),
                //——立绘 苏梦忆 含泪——
                f.t("【李云萧】", "你别哭啊……"),
                //——背景变黑——
                f.t("【李云萧】", "虽然还是记不起来，也许是我真的失忆了……"),
                f.t("【李云萧】", "……"),
                f.t("【李云萧】", "但是，失忆前的我一定和现在的我一样，见不得她哭吧。"),
                f.t("【李云萧】", "大致了解事情的经过了，既然如此，我就认真地考虑下。"),
                //——背景恢复——
                f.t("【李云萧】", "赶紧想想，有什么可以反驳的……"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "办公室的钥匙难道只有一把吗？"),
                //——背景 证人台侧——
                //——立绘 张傲——
                f.t("【张傲】", "不，办公室里的老师，每人有一把钥匙。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "那么，他们其中任意一个都有嫌疑！"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "呵呵呵，那是不可能的。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "为、为什么？"),
                //——背景 法庭-检察方侧——
                //——立绘 检察官——
                f.t("【沈尘业】", "很简单，因为老师们有不在场证明。"),
                f.t("【沈尘业】", "中午这段时间，老师们全部在餐厅里用餐，这一点，餐厅的服务员可以证明。"),
                //——背景 辩护方侧——
                //——立绘 李云萧侧面——
                f.t("【李云萧】", "唔……"),
                f.t("【李云萧】", "（原来所有的老师都不在现场）"),
                //——背景 法庭-审判长侧——
                //——立绘 审判长——
                f.t("【审判长】", "那么，辩护律师，请你询问。"),
                //——背景 助手侧——
                //——立绘 苏梦忆侧面——
                f.t("【苏梦忆】", "果然这样发展了呢！"),
                f.t("【李云萧】", "什么意思？"),
                f.t("【苏梦忆】", "检察官提出的不在场证明，和你昨天说的一模一样！"),
                f.t("【李云萧】", "完全不记得……（话说，你怎么不哭了？）"),
                f.t("【李云萧】", "对了，昨天我跟你还说了些什么？"),
                f.t("【苏梦忆】", "昨天我们去现场调查的时候，你很肯定地跟我说，真凶是别的人！"),
                f.t("【李云萧】", "……（为什么偏偏在这个时候记不起来……）"),
                f.t("【苏梦忆】", "而且，我们发现了一些有用的线索，现在就在调查记录里呢。"),
                f.t("【李云萧】", "是吗，我还没有仔细看。"),
                f.t("【李云萧】", "（说起来，要不要问下她，怎么进行询问？）"),
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
