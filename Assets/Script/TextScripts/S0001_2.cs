﻿using Assets.Script.GameStruct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.TextScripts
{
    public class S0001_2 : TextScript
    {
        public S0001_2(Hashtable gVars, Hashtable lVars, GameObject root, PanelSwitch ps):base(gVars, lVars, root, ps) { }
        public override void InitText()
        {
            
            pieces = new List<Piece>()
            {
                //——背景：教材领取处——
                f.t("【李云萧】", "果然还是男生更容易打成一片……"),
                
                f.t("【李云萧】", "（不过，一路上也被他们问了各种问题……）"),
                f.t("【喵星人】", "我说过我们班的男生很好说话的，没错吧喵？"),
                f.t("【李云萧】", "你什么时候说过这句话……"),
                f.t("【喵星人】", "对了，你这身衣服不会是之前学校的？"),
                f.t("【李云萧】", "校服，和你们穿的完全不是一个次元。"),
                f.t("【喵星人】", "嘿嘿，这就是之前说的第一个“不同”了。"),
                f.t("【喵星人】", "华欣的校服可以说是与众不同，毕竟清了专业设计师。"),
                f.t("【李云萧】", "我穿的校服，真的只是普通的运动服而已。"),
                f.t("【喵星人】", "可就算如此，你还是穿着过来了喵，为什么不丢掉它呢？"),
                f.t("【李云萧】", "因为，这是我的……"),
                f.t("【喵星人】", "好啦不管这个，我们学校女生的校服你看了吗？"),
                f.t("【李云萧】", "没有……谁会一上来就盯着女生看啊……"),
                f.t("【喵星人】", "女生的校服就是学校里最靓丽的风景线了喵！"),
                f.t("【李云萧】", "啥……"),
                f.t("【喵星人】", "你别不信，等明天的开学升旗仪式吧！"),
                f.t("【李云萧】", "我也没说不信啊……"),
                f.t("【男生】", "喵星人，还有两摞书，交给你了！我们几个先撤回基地！"),
                f.t("【喵星人】", "哦！知道了！"),
                f.t("【喵星人】", "我擦咧！那帮人居然留给我最重的书！"),
                f.t("【李云萧】", "算了，搬吧，我也来——哇——好重啊！"),
                f.t("【喵星人】", "别抱怨了——等我回去——看我不弄死他们！"),
                //——背景 后排视角教室——
                f.t("【李云萧】", "（将新的教材搬回教室后，我们把课本分发给了每一位同学。）"),
                f.t("【李云萧】", "喵星人，郭老师呢？"),
                f.t("【喵星人】", "工作做完了，估计已经回家去了。"),
                f.t("【李云萧】", "这么早就回去了？"),
                f.t("【？？？】", "各位！大家都拿到课本了吗？"),
                //——CG 苏梦忆讲台演讲——
                f.t("【？？？】", "剩下的男生都回来了，现在就开始新一轮的班委竞选。"),
                f.t("【？？？】", "每个人都可以参加竞选，上讲台进行简单的宣言……"),
                f.t("【李云萧】", "……"),
                f.t("【喵星人】", "在盯着看什么呢？"),
                f.t("【李云萧】", "没、没什么……"),
                f.t("【喵星人】", "啊~原来是班长啊~"),
                f.t("【李云萧】", "班、班长？"),
                f.t("【喵星人】", "喏，站在讲台上讲话的就是了，怎么，被她迷住了？"),
                f.t("【李云萧】", "哪有……"),
                f.t("【喵星人】", "你都写在脸上了，好喵？"),
                f.t("【李云萧】", "（虽然真的有种令人心静的清秀……）"),
                f.t("【喵星人】", "但不得不承认，班长她确实漂亮，不过，想追她是基本不可能的。"),
                f.t("【李云萧】", "你在乱说……等等，为、为什么？"),
                f.t("【喵星人】", "嗯，你就当我什么也没说吧？"),
                f.t("【李云萧】", "……"),
                f.t("【喵星人】", "现在在进行班委的选举，班长、学习委员、劳动委员、体艺委员，有没有兴趣喵？"),
                f.t("【李云萧】", "嗯……不知道，你呢？"),
                f.t("【喵星人】", "我没什么兴趣，要么，你去试一试？"),
                f.t("【李云萧】", "不用了吧，我和其他同学还不太熟悉，就算去了也选不上吧。"),
                f.t("【喵星人】", "那得赶紧和其他的同学交流交流，尤其是女生。"),
                f.t("【李云萧】", "知道啦……"),
                f.t("【李云萧】", "喵星人，说起来，我旁边的座位是谁的？"),
                f.t("【喵星人】", "就是班长的喵。"),
                f.t("【李云萧】", "噗……不会吧……"),
                //——切换——
                f.t("【李云萧】", "（竞选发言结束了，现在几个女生正在统计票数……）"),
                f.t("【喵星人】", "我们走吧。"),
                f.t("【李云萧】", "走？这不是还没结束吗？"),
                f.t("【喵星人】", "对于我们这些不参选的人来说，已经结束了。"),
                f.t("【喵星人】", "班长她也说可以回去了。"),
                f.t("【李云萧】", "是、是吗，我刚刚没仔细听。"),
                f.t("【喵星人】", "我还要带你逛逛校园喵！"),
                //——背景 校园地图——
                //*这里进入地图说明 人物采用Q版
                f.t("【喵星人】", "先给你介绍一下我们的校园喵，华欣外国语学校是个完全中学。"),
                f.t("【李云萧】", "完全中学？"),
                f.t("【喵星人】", "这里就是我们现在所处的位置，1号教学楼，整个高中部都在这里。"),
                f.t("【喵星人】", "然后与之相连的，则是实验楼了，理科的实验都在这里进行。"),
                f.t("【李云萧】", "哦，那这两个教学楼是？"),
                f.t("【喵星人】", "那是初中部所在的2号楼，以及有很多空教室的3号楼。"),
                f.t("【李云萧】", "你是从初中升上来的吗？"),
                f.t("【喵星人】", "是的，不过我初中的时候，学校还没有搬过来。"),
                f.t("【喵星人】", "再过去来就是操场了，平时的体育课都在那里上。"),
                f.t("【喵星人】", "体育馆的边上就是音乐馆，音乐课美术课，得跑去那边上。"),
                f.t("【李云萧】", "好、好远啊……"),
                f.t("【喵星人】", "所以要跑着过去喵！"),
                f.t("【喵星人】", "这里是我们平时住的地方，我们男生在2号寝室楼。"),
                f.t("【喵星人】", "然后这里是食堂，从寝室出来要走一大段路。"),
                f.t("【喵星人】", "最后，就是我最不喜欢去的图书馆了。"),
                f.t("【喵星人】", "怎么样？记住了吗？"),
                f.t("【李云萧】", "完全记不住……"),
                f.t("【喵星人】", "没关系，只要把鼠标放上去，就能看到这个地点的详细介绍。"),
                f.t("【喵星人】", "讲完了，我们回寝室吧，2号寝室楼，别搞错了。"),
                
                f.t("【李云萧】", "……")
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
