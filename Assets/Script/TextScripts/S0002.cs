﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class S0002 : TextScript
    {
        public S0002(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps):base(gVars, lVars, root, ps) { }
        public override void InitText()
        {
            
            pieces = new List<Piece>()
            {
                //——背景 后排视角的教室——
                f.t("【李云萧】", "（今天是开学的第一天……）"),
                f.t("【李云萧】", "（现在是早上的7点15分，还没有到上课的时间……）"),
                f.t("【喵星人】", "哈——"),
                f.t("【李云萧】", "怎么了，昨晚没睡好？"),
                f.t("【喵星人】", "你这不是废话喵？昨晚12点才睡的，今早6点多就被你吵醒了！"),
                f.t("【李云萧】", "是你自己睡得太晚了……"),
                f.t("【喵星人】", "哟，看不出来，你换了我们的校服，还挺不错啊。"),
                f.t("【李云萧】", "挺合身的。"),
                f.t("【喵星人】", "对了，等会广播一响，就可以去操场参加升旗仪式了。"),
                //——SE 广播——
                f.t("【李云萧】", "你指的就是这个广播么？来得还真快啊。"),
                f.t("【李云萧】", "我们走吧。"),
                f.t("【喵星人】", "走咯，升旗去咯喵！"),
                //——背景 足球场——
                f.t("【李云萧】", "（排在了队伍的最后，身后不时有老师走过……）"),
                f.t("【李云萧】", "（升旗仪式也是件令人提心吊胆的事。）"),
                f.t("【李云萧】", "（在升国旗，唱国歌后，由学生代表上台讲话。）"),
                f.t("【李云萧】", "……"),
                f.t("【？？？】", "各位同学，各位老师，大家早上好……"),
                f.t("【李云萧】", "喵星人，上面讲话的男人是？"),
                f.t("【喵星人】", "他是我们的校长，叶校。"),
                f.t("【李云萧】", "原来是校长……等等他是校长！？"),
                f.t("【李云萧】", "他看过去好年轻啊。"),
                f.t("【喵星人】", "对啊，他可是全市最年轻的校长了，了不起吧？"),
                f.t("【喵星人】", "忘记告诉你了，他负责教我们化学课。"),
                f.t("【李云萧】", "不会吧，校长直接教我们？"),
                f.t("【喵星人】", "虽然他是高高在上的校长，但他也是一名老师。"),
                f.t("【叶校长】", "在这秋高气爽的九月，我希望同学们能够在新的学期里……"),
                f.t("【李云萧】", "果然，新学期的致辞都是差不多的……"),
                f.t("【李云萧】", "从小到大，领导上台讲话都是这么长。"),
                f.t("【喵星人】", "是啊，这么多年了，都已经习惯了。"),
                f.t("【李云萧】", "……"),
                //——背景 后排视角的教室——
                f.t("【李云萧】", "终于回到教室了，操场好远啊。"),
                f.t("【李云萧】", "马上就要开始在这里学习了，也不知道老师上得怎么样。"),
                f.t("【李云萧】", "喵星人，第一节是什么课？"),
                f.t("【喵星人】", "你没有看课表吗？"),
                f.t("【李云萧】", "课表？"),
                //显示EDU界面
                f.t("【喵星人】", "看到右侧的课表了吗？这张表上会显示今天将要上的课。"),
                f.t("【喵星人】", "左边就是指令面板，点击就可以执行相应操作，如果不明白其意思，下方会有行动的简介。"),
                f.t("【喵星人】", "你要根据自身的学习状况，制定合适的学习计划。"),
                f.t("【李云萧】", "哦，明白了，只要选择就行了是吗……"),
                f.t("【喵星人】", "另外，华欣是相当自由的学习氛围，你完全可以选择自己想做的事情。"),
                f.t("【李云萧】", "诶？我可以不按照课表上课？"),
                f.t("【喵星人】", "需要注意的是，如果你选择的行动和当天的课表相符，那么学习的效率将会大幅提高。"),
                f.t("【喵星人】", "然而今天能做的事明天不一定能做，每天能做的事情会发生改变。"),
                f.t("【喵星人】", "尽可能地选择效果相近的活动，这样才能保证自我能力的提升。"),
                f.t("【李云萧】", "那下面的几个成绩，是什么意思？"),
                f.t("【喵星人】", "数值越大意味着对应能力越高，而你的考试排名则是综合了多科的成绩。"),
                f.t("【喵星人】", "需要注意的是“体力值”，体力不足会导致身心疲惫，严重时就会生病。"),
                f.t("【喵星人】", "而且，体力越低，行动失败的可能性就越大。"),
                f.t("【李云萧】", "还会失败，真是麻烦的设定……"),
                f.t("【李云萧】", "那我该怎么恢复体力值呢？"),
                f.t("【喵星人】", "平时的教学安排十分紧凑，对我们来说分秒必争。"),
                f.t("【喵星人】", "但是放假的时候，就没有教学上的压力，一定要注意休息回复。"),
                f.t("【李云萧】", "除了双休日以外，还有什么时候是放假的？"),
                f.t("【喵星人】", "具体我也不太记得，需要时可以查看“电子学生手册”。"),
                f.t("【喵星人】", "你应该已经从教务处那边领了吧，打开后点击“日历”，就可以看到学校的教学安排。"),
                f.t("【喵星人】", "除此以外，电子手册里面还有一系列资料，当你不知道该做什么时，都可以在里面查到。"),
                f.t("【李云萧】", "哦，没想到还有这么方便的功能……"),
                f.t("【喵星人】", "人的时间精力有限，你要合理安排好。"),
                f.t("【喵星人】", "以上这些，就是“能力提升”界面的介绍了。"),
                f.t("【李云萧】", "我明白了……"),
                f.t("【喵星人】", "好了喵，我的任务结束了，想想该学点什么吧。"),
                f.t("【李云萧】", "诶？容我想想……"),
                f.t("【李云萧】", "（那么，今天要做些什么呢？）",() => pieces.Count),
                //——背景 消失——
            };
        }

        public override GameNode NextNode()
        {
            //return base.NextNode();
            Finish();
            return nodeFactory.GetEndTurnNode();
            //return nodeFactory.GetMapNode();
        }

    }
}
