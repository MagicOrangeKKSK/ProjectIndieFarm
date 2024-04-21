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
            UISlot.IconLoader = ResController.Instance.LoadSprite;
            UISlot.OnItemSelect = slot => ChangeTool(slot);

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
                    Debug.Log((item == null)+"  "+Config.Items.Count);
                    slot.SetData(item, (i + 1).ToString()) ;
                }
            }

            HideAllSelect();
            UISlot.OnItemSelect(ToolbarSlots[0]);
        }

        private void ChangeTool(UISlot slot)
        {
            if (slot != null && slot.Data != null)
            {
                ChangeTool(slot.Data.Tool, slot.Select, slot.Icon.sprite);
            }
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
            if (Input.GetKeyDown(KeyCode.Alpha1)) UISlot.OnItemSelect(ToolbarSlots[0]);
            if (Input.GetKeyDown(KeyCode.Alpha2)) UISlot.OnItemSelect(ToolbarSlots[1]);
            if (Input.GetKeyDown(KeyCode.Alpha3)) UISlot.OnItemSelect(ToolbarSlots[2]);
            if (Input.GetKeyDown(KeyCode.Alpha4)) UISlot.OnItemSelect(ToolbarSlots[3]);
            if (Input.GetKeyDown(KeyCode.Alpha5)) UISlot.OnItemSelect(ToolbarSlots[4]);
            if (Input.GetKeyDown(KeyCode.Alpha6)) UISlot.OnItemSelect(ToolbarSlots[5]);
            if (Input.GetKeyDown(KeyCode.Alpha7)) UISlot.OnItemSelect(ToolbarSlots[6]);
            if (Input.GetKeyDown(KeyCode.Alpha8)) UISlot.OnItemSelect(ToolbarSlots[7]);
            if (Input.GetKeyDown(KeyCode.Alpha9)) UISlot.OnItemSelect(ToolbarSlots[8]);
            if (Input.GetKeyDown(KeyCode.Alpha0)) UISlot.OnItemSelect(ToolbarSlots[9]);
        

       
        }
    }
}
