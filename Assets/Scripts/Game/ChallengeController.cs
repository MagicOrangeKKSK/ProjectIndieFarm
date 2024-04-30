using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace ProjectindieFarm
{
    public partial class ChallengeController : ViewController
    {
        /// <summary>
        /// 当天成熟的数量
        /// </summary>
        public static BindableProperty<int> RipeAndHarvesCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> RipeAndHarvesRadishCountInCurrentDay = new BindableProperty<int>(0);

        /// <summary>
        /// 当天收割的数量
        /// </summary>
        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        /// <summary>
        /// 当天萝卜收割的数量
        /// </summary>
        public static BindableProperty<int> RadishHarvestCountInCurrentDay = new BindableProperty<int>(0);
        /// <summary>
        /// 当天白菜收割的数量
        /// </summary>
        public static BindableProperty<int> ChineseCabbageHarvestCountInCurrentDay = new BindableProperty<int>(0);


        public static List<Challenge> Challenges = new List<Challenge>()
        {
            new ChallengeHarvestAFruit(),
            new ChallengeHarvestARadish(),
            new ChallengeRipeAndHarverstTwoFruitsInADay(),
            new ChallengeRipeAndHarverstFiveFruitsInADay(),
            new ChallengeRipeAndHarvestFruitAndRadishInADay(),
            new ChallengeHarvest10thFruit(),
            new ChallengeHarvest10thRadish(),
            new ChallengeHarvest10thChineseCabbage(),
            new ChallengeRadishCountGreaterOfEqual10(),
            new ChallengeFruitRadishCountGreaterOfEqual10(),
            new ChallengeHarvestChineseCabbage(),
            new ChallengeCoin100(),

        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };

        /// <summary>
        /// 收获过的果实数量
        /// </summary>
        public static int HarvestedFruitCount = 0;
        /// <summary>
        /// 收获过的萝卜数量
        /// </summary>
        public static int HarvestedRedishCount = 0;
        /// <summary>
        /// 收获过的白菜数量
        /// </summary>
        public static int HarvestedChineseCabbageCount = 0;

        /// <summary>
        /// 当挑战完成
        /// </summary>
        public static EasyEvent<Challenge> OnChalengeFinish = new EasyEvent<Challenge>();



        public Font Font;
        private GUIStyle mLabelStyle;

        private void Start()
        {
            mLabelStyle = new GUIStyle("Label")
            {
                font = this.Font
            };

            //随机一个Challenge
            var randomItem = Challenges.GetRandomItem();
            ActiveChallenges.Add(randomItem);
            //监听成熟的植物是否当天成熟且当天收割的
            Global.OnPlantharvest.Register(plant =>
            {
                if (plant is Plant)
                {
                    HarvestCountInCurrentDay.Value++;
                    HarvestedFruitCount++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        RipeAndHarvesCountInCurrentDay.Value++;
                    }
                }
                else if (plant is PlantRadish)
                {
                    RadishHarvestCountInCurrentDay.Value++;
                    HarvestedRedishCount++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        RipeAndHarvesRadishCountInCurrentDay.Value++;
                    }
                }
                else if(plant is PlantChineseCabbage)
                {
                    ChineseCabbageHarvestCountInCurrentDay.Value++;
                    HarvestedChineseCabbageCount++;
                }

            }).UnRegisterWhenGameObjectDestroyed(this);


        }

        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(960, 360);
            GUI.Label(new Rect(960 - 300, 0, 300, 24), "@@ 挑战 @@", mLabelStyle);

            for (var i = 0; i < ActiveChallenges.Count; i++)
            {
                var challenge = ActiveChallenges[i];
                GUI.Label(new Rect(960 - 300, 20 + i * 20, 300, 24), challenge.Name, mLabelStyle);
            }

            for (var i = 0; i < FinishedChallenges.Count; i++)
            {
                var challenge = FinishedChallenges[i];
                GUI.Label(new Rect(960 - 300, 20 + (i + ActiveChallenges.Count) * 20, 300, 24), $"<color=green>√ {challenge.Name}</color>", mLabelStyle);
            }
        }

        private void Update()
        {
            bool hasFinishChallenge = false;
            foreach (var challenge in ActiveChallenges)
            {
                if (challenge.State == Challenge.States.NotStart)
                {
                    challenge.StartDate = Global.Days.Value;
                    challenge.OnStart();
                    challenge.State = Challenge.States.Started;
                }

                if (challenge.State == Challenge.States.Started)
                {
                    if (challenge.CheckFinish())
                    {
                        challenge.OnFinish();
                        challenge.State = Challenge.States.Finished;
                        OnChalengeFinish.Trigger(challenge);
                        FinishedChallenges.Add(challenge);
                        hasFinishChallenge = true;

                    }
                }
            }

            if (hasFinishChallenge)
            {
                ActiveChallenges.RemoveAll(challenge => challenge.State == Challenge.States.Finished);
            }

            if (ActiveChallenges.Count == 0 &&
                FinishedChallenges.Count != Challenges.Count)
            {
                //否则随机选择一个未开始的挑战加入
                var randomItem = Challenges.Where(c => c.State == Challenge.States.NotStart).ToList().GetRandomItem();
                ActiveChallenges.Add(randomItem);
            }
        }

    }
}