using System;
using UnityEngine;
using UnityEngine.UI;
namespace ProjectindieFarm
{
    public interface ISlotData
    {
        public Sprite Icon { get; set; }
        public Action OnSelect { get; set; }
    }
}