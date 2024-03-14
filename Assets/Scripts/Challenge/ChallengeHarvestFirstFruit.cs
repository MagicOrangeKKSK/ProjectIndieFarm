using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestFirstFruit : Challenge
    {
        public override string Name => "收获第一颗果实";

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