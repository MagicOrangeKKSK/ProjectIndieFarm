using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectindieFarm
{
    public class UISlot : MonoBehaviour
    {
        public Image Icon;
        public Image Select;
        public TextMeshProUGUI ShortCut;

        public Button Button;

        private ISlotData mData;
        public ISlotData Data => mData;

        private void Awake()
        {
            Icon.sprite = null;
            Select.Hide();
            ShortCut.text = "";
        }

        public void SetData(ISlotData data,string shortCut)
        {
            mData = data;
            Icon.sprite = mData.Icon;
            ShortCut.text = shortCut;
        }
    
    }

    public class SlotData : ISlotData
    {
        public Sprite Icon { get; set; }
        public Action OnSelect { get ; set; }
    }
}
