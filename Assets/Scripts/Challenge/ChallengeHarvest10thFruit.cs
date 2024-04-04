using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvest10thFruit : Challenge
    {
        public override string Name => "收获第十个果实";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return ChallengeController.HarvestedFruitCount >= 10;
        }

        public override void OnFinish()
        {

        }




    }
}