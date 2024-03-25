using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarvestFruitAndRadishInADay : Challenge
    {
        public override string Name => "同一天收获当天成熟的果实和萝卜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Days .Value != StartDate &&
                Global.RipeAndHarvesCountInCurrentDay.Value >= 1 &&
                Global.RipeAndHarvesRadishCountInCurrentDay.Value >= 1;
        }

        public override void OnFinish()
        {

        }

   

    
    }
}