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

        /// <summary>
        /// �������
        /// </summary>
        public static BindableProperty<int> FruitCount = new BindableProperty<int>();
    }
}