using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    public class Global
    {
        /// <summary>
        /// Ĭ�ϴӵ�һ�쿪ʼ��
        /// </summary>
        public static BindableProperty<int> Days = new BindableProperty<int>();

        public static BindableProperty<int> Coin = new BindableProperty<int>(0);

        /// <summary>
        /// �������
        /// </summary>
        public static BindableProperty<int> FruitCount = new BindableProperty<int>();
        public static BindableProperty<int> RadishCount = new BindableProperty<int>();
        public static BindableProperty<int> ChineseCabbageCount = new BindableProperty<int>();
        

        public static BindableProperty<int> ChineseCabbageSeedCount = new BindableProperty<int>(6);
             

        /// <summary>
        /// ��ǰ�Ĺ���
        /// </summary>
        public static BindableProperty<ITool> CurrentTool = new BindableProperty<ITool>(Config.Items[0].Tool);

        /// <summary>
        /// ��ֲ���ո�
        /// </summary>
        public static EasyEvent<IPlant> OnPlantharvest = new EasyEvent<IPlant>();

        public static Player Player;
        public static ToolController Mouse;

        public static bool HandRange1Unlock = false;
        public static bool ShovelRange1Unlock = false;
        public static bool WateringCan1Unlock = false;
    }

    /// <summary>
    /// ����
    /// </summary>

  

}