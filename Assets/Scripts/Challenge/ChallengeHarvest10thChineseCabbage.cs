using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    internal class ChallengeHarvest10thChineseCabbage : Challenge
    {
        public override string Name => "收获第十个白菜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return ChallengeController.HarvestedChineseCabbageCount >= 10;
        }

        public override void OnFinish()
        {

        }
    }
}
