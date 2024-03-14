using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectindieFarm
{
    public class ChallengeRipeAndHarverstTwoFruitsInOneDay : Challenge,IUnRegisterList
    {
        public List<IUnRegister> UnregisterList => new List<IUnRegister>();

        public override void OnStart()
        {
            //���������ֲ���Ƿ�������ҵ����ո��
            Global.OnPlantharvest.Register(plant =>
            {
                if (plant.RipeDay == Global.Days.Value)
                {
                    Global.RipeAndHarvesCountInCurrentDay.Value++;
                }
            }).AddToUnregisterList(this);

        }

        public override bool CheckFinish()
        {
            return Global.RipeAndHarvesCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {
            this.UnRegisterAll();
            //ActionKit.Delay(1.0f, () =>
            //{
            //    SceneManager.LoadScene("GamePass");
            //}).StartGlobal();
        }
 
    }
}