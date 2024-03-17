using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    public class Global
    {
        /// <summary>
        /// Ĭ�ϴӵ�һ�쿪ʼ��
        /// </summary>
        public static BindableProperty<int> Days = new BindableProperty<int>();

        /// <summary>
        /// �������
        /// </summary>
        public static BindableProperty<int> FruitCount = new BindableProperty<int>();

        /// <summary>
        /// ��ǰ�Ĺ���
        /// </summary>
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>("��");

        /// <summary>
        /// ������������
        /// </summary>
        public static BindableProperty<int> RipeAndHarvesCountInCurrentDay = new BindableProperty<int>(0);

        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        public static List<Challenge> Challenges = new List<Challenge>()
        {
            new ChallengeHarvestAFruit(),
            new ChallengeRipeAndHarverstTwoFruitsInADay(),
            new ChallengeRipeAndHarverstFiveFruitsInADay(),
        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };


        /// <summary>
        /// ��ֲ���ո�
        /// </summary>
        public static EasyEvent<Plant> OnPlantharvest = new EasyEvent<Plant>();
        
        /// <summary>
        /// ����ս���
        /// </summary>
        public static EasyEvent<Challenge> OnChalengeFinish = new EasyEvent<Challenge>();


        public static Player Player;
    }

    /// <summary>
    /// ����
    /// </summary>
    public class Constant
    {
        public const string TOOL_HAND = "hand";
        public const string TOOL_SHOVEL = "shovel";
        public const string TOOL_SEED = "seed";
        public const string TOOL_WATERING_SCAN = "watering_scan";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "��";
                case TOOL_SHOVEL:
                    return "����";
                case TOOL_SEED:
                    return "����";
                case TOOL_WATERING_SCAN:
                    return "ˮ��";
            }
            return string.Empty;
        }
    }
}