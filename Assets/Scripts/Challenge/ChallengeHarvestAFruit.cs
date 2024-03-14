using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestAFruit : Challenge
    {
        public override string Name => "�ջ��һ�Ź�ʵ";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Days .Value != StartDate &&
                Global.HarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {

        }

   

    
    }
}