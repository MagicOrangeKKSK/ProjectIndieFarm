using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstTwoFruitsInOneDay : Challenge
    {
        public List<IUnRegister> UnregisterList => new List<IUnRegister>();

        public override void OnStart()
        {
       

        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvesCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {
        
        }
 
    }
}