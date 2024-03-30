using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstTwoFruitsInADay : Challenge
    {
        public List<IUnRegister> UnregisterList => new List<IUnRegister>();

        public override string Name => "ͬһ���ջ������������Ĺ�ʵ";

        public override void OnStart()
        {
        }

        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && 
                ChallengeController.RipeAndHarvesCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {
        
        }
 
    }
}