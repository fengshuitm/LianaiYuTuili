﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class S3004 : TextScript
    {
        public S3004(DataManager manager, GameObject root, PanelSwitch ps):base(manager, root, ps) { }
        public override void InitText()
        {
            
            pieces = new List<Piece>()
            {
                //——背景 夕大校园——
                f.t("【李云萧】", "又一次来到了夕云大学。"),
                f.t("【李云萧】", "相比于高中，大学的校园多了一丝自由与活力。"),
                //——立绘 喵星人——
                f.t("【喵星人】", "哟！"),
                f.t("【李云萧】", "你怎么也来了？喵星人？"),
                f.t("【喵星人】", "嘿嘿，我不能来么喵？"),
                f.t("【李云萧】", "不是，我只是好奇。"),
                f.t("【喵星人】", "我嘛过来看看，说不定高考后，就来这里读了。"),
                f.t("【李云萧】", "哦……"),
                f.t("【喵星人】", "夕大是市里唯一的大学，每年都有大批学生报考。"),
                f.t("【喵星人】", "不光本地的学生，就连省外的学生都会过来。"),
                f.t("【李云萧】", "这么说，高考的分数线应该不低。"),
                f.t("【李云萧】", "那你呢，打算怎么办？"),
                f.t("【喵星人】", "虽然我的家人想让我读夕大，但我更想出国留学。"),
                f.t("【喵星人】", "对了，你知不知道今天是夕大的开放日。"),
                f.t("【李云萧】", "开放日？是什么？"),
                f.t("【喵星人】", "简单来讲说，就是校园对外开放的一天，虽然平时也能进来。"),
                f.t("【李云萧】", "还有这么一回事。"),
                f.t("【喵星人】", "我们华欣也有开放日的哦，到那个时候，会有很多家长进校参观。"),
                f.t("【喵星人】", "主要还是为了吸引新一届的学生报考。"),
                f.t("【喵星人】", "今天能看到各种各样的大学社团喵，比高中的社团要多得多了。"),
                f.t("【李云萧】", "听起来很有趣的样子……"),
                f.t("【喵星人】", "走！去看看！"),
                //——背景 广场（很多摊位）——
                f.t("【李云萧】", "唔，还真是热闹啊……"),
                f.t("【喵星人】", "那是自然，你想想一个大学有多少人。"),
                //——CG 晓芸女仆发传单——
                f.t("【喵星人】", "看到没，猫儿女仆！真是可爱喵！"),
                f.t("【喵星人】", "我赌五毛，肯定是动漫社的。"),
                f.t("【李云萧】", "你对此还真了解啊。"),
                f.t("【喵星人】", "你还别不信，装作自己是大学生，走过去看看。"),
                f.t("【李云萧】", "（为什么要装作……）"),
                f.t("【学生】", "欢迎加入Sprit动漫社！"),
                f.t("【喵星人】", "喵！看到没！我说的没错吧！"),
                f.t("【李云萧】", "好好，听到啦……五毛拿去……"),
                //——立绘 猫耳女仆晓芸——
                f.t("【？？？】", "来Sprit动漫咖啡店品尝吧！"),
                f.t("【？？？】", "凭此宣传单，能享受8折优惠。"),
                f.t("【喵星人】", "请问咖啡店在哪？"),
                f.t("【？？？】", "就在对面的楼内。"),
                f.t("【李云萧】", "喵星人，我们不是夕大的学生，收下不太好吧？"),
                f.t("【喵星人】", "怕什么，收着去店里看看！"),
                f.t("【李云萧】", "好吧。（真的没问题么）"),
                f.t("【？？？】", "李云萧，你又来啦！"),
                f.t("【李云萧】", "诶？你是？"),
                f.t("【？？？】", "你不记得我了吗，我好伤心……"),
                f.t("【喵星人】", "李——云——萧，她是谁？"),
                f.t("【喵星人】", "难不成是你的女朋友？FFFFF……"),
                f.t("【李云萧】", "怎么可能！"),
                f.t("【李云萧】", "唔，我们俩在哪里见过吗？"),
                f.t("【喵星人】", "要么是你的姐姐？"),
                f.t("【李云萧】", "是我姐姐的话，我怎么可能会认不出来？"),
                f.t("【李云萧】", "再说我也没有姐姐啊……"),
                f.t("【？？？】", "哈哈哈哈，是我啦。"),
                //——立绘 女仆装晓芸——
                f.t("【李云萧】", "啊！欧阳晓芸！"),
                f.t("【李云萧】", "你戴了猫儿朵和假发，都认不出来了。"),
                f.t("【欧阳晓芸】", "今天特意来看我的吗？好开心！"),
                f.t("【李云萧】", "我刚好碰到夕大的开放日，就来逛逛……"),
                f.t("【喵星人】", "为什么我的手中多了火把？"),
                f.t("【李云萧】", "等等，喵星人，你想干什么？"),
                f.t("【喵星人】", "快说，是什么时候认识这么可爱的妹子的？"),
                f.t("【李云萧】", "这个，说来话长……大概是……"),
                f.t("【喵星人】", "哼，我们中出了个叛徒！"),
                f.t("【李云萧】", "好歹让我讲完……"),
                f.t("【欧阳晓芸】", "你们在讲什么？"),
                f.t("【李云萧】", "对了，忘记介绍，这位是我同学，叫苗星任。"),
                f.t("【欧阳晓芸】", "你好，我叫欧阳晓芸。"),
                f.t("【喵星人】", "こんにちは！"),
                f.t("【欧阳晓芸】", "你也学过日语吗？"),
                f.t("【喵星人】", "是啊！我是自学的。"),
                f.t("【李云萧】", "怎么可能……"),
                f.t("【喵星人】", "你也太小瞧我了！听着……（清嗓子）"),
                f.t("【李云萧】", "好了好了，我信你总行了吧。"),
                f.t("【欧阳晓芸】", "哈哈哈，要不要来我们社的咖啡厅？"),
                f.t("【李云萧】", "可以啊，那是你开的吗？"),
                f.t("【欧阳晓芸】", "嗯，其实是社团里的同学租的店。"),
                f.t("【喵星人】", "我问一句，难不成是女仆咖啡？"),
                f.t("【李云萧】", "什么咖啡？"),
                f.t("【欧阳晓芸】", "你过去看看就知道啦，我带你去吧。"),
                f.t("【李云萧】", "你不用留在这里吗？"),
                f.t("【欧阳晓芸】", "没事的。"),
                //——背景 咖啡店——
                //——立绘 猫耳女仆晓芸——
                f.t("【喵星人】", "哦哦哦，猫耳。"),
                f.t("【欧阳晓芸】", "请慢用。"),
                f.t("【喵星人】", "谢谢喵！"),
                f.t("【李云萧】", "（好像……意外地可爱……）"),
                f.t("【店员】", "晓芸！过来帮下忙！"),
                f.t("【欧阳晓芸】", "哦！马上来。"),
                //——立绘结束——
                f.t("【喵星人】", "果然都是女仆装啊，不愧是动漫社的。"),
                f.t("【李云萧】", "哦……"),
                f.t("【喵星人】", "别发呆了，人都走了。"),
                f.t("【李云萧】", "啊？"),
                f.t("【喵星人】", "那不成你看上她了？"),
                f.t("【李云萧】", "没、没有。"),
                f.t("【喵星人】", "别妄想啦，她可是大学生，你和她没有交集的。"),
                f.t("【李云萧】", "我知道……（我在想什么啊……）"),
                f.t("【喵星人】", "喝完再去别的社团看看。"),

                f.t("【李云萧】", "（之后的一段时间，一直陪着喵星人逛完了整个校园……）"),
                f.t("【李云萧】", "（当我们回到原点的时候，她已经不在了……）"),
                f.t("【李云萧】", "（不知何时才能再见你一面……）",() => pieces.Count)
                //——背景 消失——
            };
        }

        public override GameNode NextNode()
        {
            //return base.NextNode();
            Finish();
            //return nodeFactory.GetEduNode("");
            return nodeFactory.GetMapNode();
        }

    }
}
