using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectindieFarm
{
    public class ChallengeCoin100 : Challenge
    {
        public override string Name => "×¬È¡100½ð±Ò";

        public override void OnStart()
        {

        }

        public override bool CheckFinish()
        {
            return Global.Coin.Value >= 100;
        }

        public override void OnFinish()
        {

        }

   

    
    }
}