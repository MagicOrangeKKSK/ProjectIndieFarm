using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolWateringCan : ITool
    {
        public string Name { get; set; } = "watering_can";
        public Item Item { get; set; }

        public int Range => Global.WateringCan1Unlock ? 2 : 1;

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].Watered != true;
        }


        public void Use(ToolData toolData)
        {
            ResController.Instance.WaterPrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);
            toolData.ShowGrid[toolData.CellPos].Watered = true;
            AudioController.Instance.SfxWater.Play();
        }
    }
}