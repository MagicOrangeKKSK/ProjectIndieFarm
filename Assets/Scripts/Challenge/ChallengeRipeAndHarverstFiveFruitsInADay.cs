using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstFiveFruitsInADay : Challenge
    {
        public override string Name => "ͬһ���ջ�����������Ĺ�ʵ";

        public override void OnStart()
        {
        
        }

        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && 
                Global.RipeAndHarvesCountInCurrentDay.Value >= 5;
        }

        public override void OnFinish()
        {
        
        }
 
    }
}