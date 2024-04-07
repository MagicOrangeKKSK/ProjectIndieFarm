using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolHand : ITool
    {
        public string Name { get;  set; } = "hand";

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].HasPlant &&
                        toolData.ShowGrid[toolData.CellPos].PlantStates == PlantStates.Ripe;
        }


        public void Use(ToolData toolData)
        {
            Global.OnPlantharvest.Trigger(PlantController.Instance.Plants[toolData.CellPos]);

            if (PlantController.Instance.Plants[toolData.CellPos] as Plant)
            {
                Global.FruitCount.Value++;
            }
            else if (PlantController.Instance.Plants[toolData.CellPos] as PlantRadish)
            {
                Global.RadishCount.Value++;
            }

            Object.Destroy(PlantController.Instance.Plants[toolData.CellPos].GameObject);//.SetState(PlantStates.Old);
            toolData.ShowGrid[toolData.CellPos].HasPlant = false;
            AudioController.Instance.SfxHarvest.Play();
        }
    }
}