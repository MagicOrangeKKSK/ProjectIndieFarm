using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{
    [System.Serializable]
    public class Item 
    {
        public string Name;
        public string IconName;
        public BindableProperty<int> Count;

        public bool Countable = false;

        public ITool Tool;
        public bool IsPlant;
        public string PlantPrefabName;
        
        //public Item Self(Action<Item> onSelf)
        //{
        //    onSelf.Invoke(this);
        //    return this;
        //}
    }




}
