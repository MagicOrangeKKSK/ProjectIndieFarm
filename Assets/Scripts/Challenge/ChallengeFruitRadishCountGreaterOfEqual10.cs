﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    internal class ChallengeFruitChineseCabbageCountGreaterOfEqual10 : Challenge
    {
        public override string Name => "拥有十个白菜";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.ChineseCabbageCount.Value >= 10;
        }

        public override void OnFinish()
        {

        }



    }
}
