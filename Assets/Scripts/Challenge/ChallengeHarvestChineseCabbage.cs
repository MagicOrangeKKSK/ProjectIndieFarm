using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeHarvestChineseCabbage : Challenge
    {
        public override string Name => "�ջ�һ���ײ�";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate &&
                        ChallengeController.ChineseCabbageHarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {

        }




    }
}