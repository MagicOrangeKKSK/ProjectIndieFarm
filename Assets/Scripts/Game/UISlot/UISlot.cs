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
        public static Func<string, Sprite> IconLoader;
        public static Action<UISlot> OnItemSelect;

        public Image Icon;
        public Image Select;
        public TextMeshProUGUI ShortCut;
        public TextMeshProUGUI Count;

        public Button Button;

        private Item mData;
        public Item Data => mData;

        private void Awake()
        {
            Icon.sprite = null;
            Select.Hide();
            ShortCut.text = "";
            Count.Hide();

            Button.onClick.AddListener(() =>
            {
                OnItemSelect?.Invoke(this);
            });

        }

#if UNITY_EDITOR

        private void OnValidate()
        {
           if(transform.Find("Count"))
                Count = transform.Find("Count").GetComponent<TextMeshProUGUI>();
        }
#endif

        public void SetData(Item data, string shortCut)
        {
            mData = data;
            Debug.Log(shortCut);
            //Icon.sprite = ResController.Instance.LoadSprite(mData.IconName);
            Icon.sprite = IconLoader?.Invoke(mData.IconName);
            ShortCut.text = shortCut;
            if (data.Countable)
            {
                Count.text = data.Count.ToString();
                Count.Show();
            }
        }
    
    }


}
