using UnityEngine;
using QFramework;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace ProjectindieFarm
{
	public partial class UIToolBar : ViewController
	{
        private List<UISlot> ToolbarSlots = new List<UISlot>();


        void Start()
        {

            ToolbarSlots.Add(ToolbarSlot1);
            ToolbarSlots.Add(ToolbarSlot2);
            ToolbarSlots.Add(ToolbarSlot3);
            ToolbarSlots.Add(ToolbarSlot4);
            ToolbarSlots.Add(ToolbarSlot5);
            ToolbarSlots.Add(ToolbarSlot6);
            ToolbarSlots.Add(ToolbarSlot7);
            ToolbarSlots.Add(ToolbarSlot8);
            ToolbarSlots.Add(ToolbarSlot9);
            ToolbarSlots.Add(ToolbarSlot10);

            for (int i = 0; i < ToolbarSlots.Count; i++)
            {
                var slot = ToolbarSlots[i];
                if(i < Config.Items.Count)
                {
                    var item = Config.Items[i];
                    var index = i;
                    slot.SetData(new SlotData()
                    {
                        Icon = ResController.Instance.LoadSprite(item.IconName),
                       OnSelect = () => ChangeTool(index, item.Tool)
                    }, (index + 1).ToString()) ;
                }
            }


            for (int i = ToolbarSlots.Count; i-- > 0;)
            {
                int j = i;
                ToolbarSlots[j].Button.onClick.AddListener(() =>
                {
                    ToolbarSlots[j].Data?.OnSelect?.Invoke();
                });
            }
            HideAllSelect();
            ChangeTool(0,Constant.ToolHand);
        }

        private void ChangeTool(int index,ITool tool)
        {
            ChangeTool(tool, ToolbarSlots[index].Select, ToolbarSlots[index].Icon.sprite);
        }


        void HideAllSelect()
        {
            for(int i = ToolbarSlots.Count;i-->0;)
                ToolbarSlots[i].Select.Hide(); 
        }

        void ChangeTool(ITool tool,Image selectImage,Sprite icon)
        {
            Global.CurrentTool.Value = tool;
            AudioController.Instance.SfxTake.Play();

            HideAllSelect();
            selectImage.Show();
            Global.Player.ToolIcon.sprite = icon;
            Global.Mouse.Icon.sprite = icon;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ToolbarSlots[0].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ToolbarSlots[1].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ToolbarSlots[2].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ToolbarSlots[3].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ToolbarSlots[4].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                ToolbarSlots[5].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                ToolbarSlots[6].Data?.OnSelect?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                ToolbarSlots[7].Data?.OnSelect?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                ToolbarSlots[8].Data?.OnSelect?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                ToolbarSlots[9].Data?.OnSelect?.Invoke();
            }
        }
    }
}
