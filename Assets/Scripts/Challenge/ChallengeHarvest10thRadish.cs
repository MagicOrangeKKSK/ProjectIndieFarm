using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    internal class ChallengeHarvest10thRadish : Challenge
    {
        public override string Name => "收获第十个萝卜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return ChallengeController.HarvestedRedishCount >= 10;
        }

        public override void OnFinish()
        {

        }



    }
}
