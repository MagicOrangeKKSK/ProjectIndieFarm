using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestARadish : Challenge
    {
        public override string Name => "收获第一根萝卜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Days .Value != StartDate &&
                ChallengeController.RadishHarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {

        }

   

    
    }
}