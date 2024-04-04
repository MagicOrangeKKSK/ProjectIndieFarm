using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    internal class ChallengeRadishCountGreaterOfEqual10 : Challenge
    {
        public override string Name => "拥有十个萝卜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.RadishCount.Value >= 10;
        }

        public override void OnFinish()
        {

        }



    }
}
