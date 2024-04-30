using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestChineseCabbage : Challenge
    {
        public override string Name => "收获一个白菜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate &&
                        ChallengeController.ChineseCabbageHarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {

        }




    }
}