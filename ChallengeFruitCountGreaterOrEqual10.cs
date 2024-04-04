using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    internal class ChallengeFruitCountGreaterOrEqual10 : Challenge
    {
        public override string Name => "拥有十个果实";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.FruitCount.Value >= 10;
        }

        public override void OnFinish()
        {

        }



    }
}
