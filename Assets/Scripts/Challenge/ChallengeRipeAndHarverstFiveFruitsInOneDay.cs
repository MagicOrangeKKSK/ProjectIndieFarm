using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstFiveFruitsInOneDay : Challenge
    {
        public override string Name => "同一天收获五个当天成熟的果实";

        public override void OnStart()
        {
        
        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvesCountInCurrentDay.Value >= 5;
        }

        public override void OnFinish()
        {
        
        }
 
    }
}