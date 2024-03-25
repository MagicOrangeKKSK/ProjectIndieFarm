using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    public class Global
    {
        /// <summary>
        /// 默认从第一天开始算
        /// </summary>
        public static BindableProperty<int> Days = new BindableProperty<int>();

        /// <summary>
        /// 结果数量
        /// </summary>
        public static BindableProperty<int> FruitCount = new BindableProperty<int>();
        public static BindableProperty<int> RadishCount = new BindableProperty<int>();

        /// <summary>
        /// 当前的工具
        /// </summary>
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>("手");

        /// <summary>
        /// 当天成熟的数量
        /// </summary>
        public static BindableProperty<int> RipeAndHarvesCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> RipeAndHarvesRadishCountInCurrentDay = new BindableProperty<int>(0);


        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        /// <summary>
        /// 当天萝卜收割的数量
        /// </summary>
        public static BindableProperty<int> RadishHarvestCountInCurrentDay = new BindableProperty<int>(0);


        public static List<Challenge> Challenges = new List<Challenge>()
        {
            new ChallengeHarvestAFruit(),
            new ChallengeRipeAndHarverstTwoFruitsInADay(),
            new ChallengeRipeAndHarverstFiveFruitsInADay(),
            new ChallengeHarvestARadish(),
            new ChallengeRipeAndHarvestFruitAndRadishInADay(),
        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };


        /// <summary>
        /// 当植物收割
        /// </summary>
        public static EasyEvent<IPlant> OnPlantharvest = new EasyEvent<IPlant>();
        
        /// <summary>
        /// 当挑战完成
        /// </summary>
        public static EasyEvent<Challenge> OnChalengeFinish = new EasyEvent<Challenge>();


        public static Player Player;
        public static ToolController Mouse;
    }

    /// <summary>
    /// 常量
    /// </summary>
    public class Constant
    {
        public const string TOOL_HAND = "hand";
        public const string TOOL_SHOVEL = "shovel";
        public const string TOOL_WATERING_SCAN = "watering_scan";


        public const string TOOL_SEED_RADISH = "seed_radish";
        public const string TOOL_SEED = "seed";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "手";
                case TOOL_SHOVEL:
                    return "铁锹";
                case TOOL_SEED:
                    return "种子";
                case TOOL_WATERING_SCAN:
                    return "水壶";
                case TOOL_SEED_RADISH:
                    return "萝卜";
            }
            return string.Empty;
        }
    }
}