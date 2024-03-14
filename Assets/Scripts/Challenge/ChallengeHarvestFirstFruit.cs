using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestFirstFruit : Challenge
    {
        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.FruitCount.Value > 0;
        }

        public override void OnFinish()
        {

        }

   

    
    }
}