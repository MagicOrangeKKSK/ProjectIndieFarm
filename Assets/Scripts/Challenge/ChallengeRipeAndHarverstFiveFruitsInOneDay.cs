using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstFiveFruitsInOneDay : Challenge
    {

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