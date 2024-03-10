using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    public class Global  
    {
        /// <summary>
        /// 默认从第一天开始算
        /// </summary>
        public static BindableProperty<int> Days = new BindableProperty<int>();

        /// <summary>
        /// 结果数量
        /// </summary>
        public static BindableProperty<int> FruitCount = new BindableProperty<int>();
    }
}