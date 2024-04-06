using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolWateringScan : ITool
    {


        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].Watered != true &&
                        Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN;
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