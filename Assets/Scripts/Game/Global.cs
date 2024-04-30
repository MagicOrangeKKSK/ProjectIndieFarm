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
        public static BindableProperty<int> RadishCount = new BindableProperty<int>();
        public static BindableProperty<int> ChineseCabbageCount = new BindableProperty<int>();
        

        public static BindableProperty<int> ChineseCabbageSeedCount = new BindableProperty<int>(6);
             

        /// <summary>
        /// 当前的工具
        /// </summary>
        public static BindableProperty<ITool> CurrentTool = new BindableProperty<ITool>(Config.Items[0].Tool);

        /// <summary>
        /// 当植物收割
        /// </summary>
        public static EasyEvent<IPlant> OnPlantharvest = new EasyEvent<IPlant>();

        public static Player Player;
        public static ToolController Mouse;
    }

    /// <summary>
    /// 常量
    /// </summary>
    
}