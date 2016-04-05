using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public static class Config
    {
        public const int ValueFalse = 0;
        public const int ValueUnknown = 50;
        public const int ValueTrue = 100;

        public const string TokenUnknown = "??";
        public const string TokenTrue = "是";
        public const string TokenFalse = "不";
        public const string TokenSpace = " ";
        public const string TokenName = "名称";
        public const string TokenMe = "你";
        public const string TokenYou = "我";
        public const string TokenOwnership = "所属";
        public const string TokenInnate = "与生俱来";
        public const string TokenMood = "头脑";
        public const string TokenBody = "身体";
        public const string TokenBe1 = "是";
        public const string TokenBe2 = "是";
        public const string TokenBe3 = "是";
        public const string TokenDefineMyself = "类人";
        public const string TokenDefine = "定义";
        public const string TokenWho = "谁";

        public const string TokenNoun = "名词";
        public const string TokenPronoun = "代词";
        public const string TokenQueryPronoun = "疑问代词";
        public const string TokenVerb = "动词";
        public const string TokenCopula = "系动词";
        public const string TokenPassivity = "被动词";
        public const string TokenAdjitive = "形容词";
        public const string TokenPreposition = "介词";
        public const string TokenAdverb = "副词";
        public const string TokenNumber = "量词";
        public const string TokenHas = "有";
        public const string TokenEverything = "--";
        public const string TokenCommand = "--";

        public const string TokenPunction_WenHao = "？";
        public const string TokenPunction_JuHao = "。";
        public const string TokenPunction_DouHao = "，";
        public const string TokenPunction_GanTanHao = "！";


        public const string TokenPhrase_Cmd = "cmd";
        public const string TokenPhrase_ZhuXiBiao = "主系表";
        public const string TokenPhrase_ZhuWeiBing = "主谓宾";
        public const string TokenPhrase_ZhuXiBiaoQuery = "疑问主系表";

    }
}
