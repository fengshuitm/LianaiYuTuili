﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class S0001_3 : TextScript
    {
        public S0001_3(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps):base(gVars, lVars, root, ps) { }
        public override void InitText()
        {
            
            pieces = new List<Piece>()
            {
                //——背景：教材领取处——
                f.t("【李云萧】", "（于是，我便回到了学校安排给我的寝室。）"),
                f.t("【喵星人】", "没想到啊，我终于不是一个人了！"),
                f.t("【李云萧】", "……"),
                f.t("【李云萧】", "我也没想到，跟我同住的竟然是你……"),
                f.t("【李云萧】", "不过，为什么之前你是一个人住？"),
                f.t("【喵星人】", "这个嘛，本来是分配好的，两个人一间寝室，我也不例外。"),
                f.t("【喵星人】", "但是，开学的时候，有个男生没有来报道，所以就变成这样了。"),
                f.t("【李云萧】", "后来也没有安排其他人？"),
                f.t("【喵星人】", "没有，就算是下一届，也是正好偶数个人。"),
                f.t("【李云萧】", "应该说你运气好还是运气差呢……"),
                f.t("【李云萧】", "总之，从今以后，请你多指教！"),
                f.t("【喵星人】", "你也是喵。"),
                f.t("【喵星人】", "话说……听你说你喜欢推理？"),
                f.t("【李云萧】", "喜欢是喜欢，怎么了……"),
                f.t("【李云萧】", "（有种不祥的预感……）"),
                f.t("【喵星人】", "告诉你……这个学校里……"),
                f.t("【李云萧】", "你别吓我……"),
                f.t("【喵星人】", "有着七大不可思议！"),
                f.t("【李云萧】", "鬼才信！！(╯‵□′)╯︵┻━┻"),
                f.t("【李云萧】", "全世界都是七大不可思议，就不能是八个九个吗！"),
                f.t("【喵星人】", "你看，动漫里都这么说的。"),
                f.t("【喵星人】", "晚上图书馆会有诡异的灯光，医务室会动的假人……"),
                f.t("【李云萧】", "那都是假的啊！"),
                f.t("【喵星人】", "看来有必要让你亲自去体验一下。"),
                f.t("【旁白】", "然而李云萧完全没有听进去。"),
                f.t("【李云萧】", "还有啊，我只是推理游戏玩得多，我自己没推理能力的。"),
                f.t("【旁白】", "然而喵星人也完全没有听进去。"),
                f.t("【喵星人】", "我们越个时间去看看……刚开学肯定很空……"),
                f.t("【李云萧】", "……"), 
                f.t("【喵星人】", "我饿了，走走走，吃饭去！"),
                f.t("【李云萧】", "额……现在才3点啊……"),
                f.t("【喵星人】", "嗯，刚开学去几楼吃呢？"),
                //——立绘 消失——
                f.t("【李云萧】", "喂！等等我！"),
                //——变黑——
                f.t("【李云萧】", "这便是我第一天进入华欣的情形……"),
                f.t("【李云萧】", "崭新的学期即将开始，新的一页即将开始书写……"),
                f.t("【李云萧】", "而我，李云萧，将在这里留下最深的记忆……"),
                //——可以插入OP了——
                f.t("", "——可以插入OP了——")
            };
        }

        public override GameNode NextNode()
        {
            //return base.NextNode();
            Finish();
            return nodeFactory.FindTextScript("S0002");
        }

    }
}
