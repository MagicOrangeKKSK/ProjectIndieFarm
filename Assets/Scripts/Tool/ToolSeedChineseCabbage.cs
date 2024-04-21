using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
    public class ToolSeedChineseCabbage : ITool
    {
        public string Name { get; set; } = "seed_chinese_cabbage";

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].HasPlant != true &&
                        Global.ChineseCabbageSeedCount.Value > 0;
        }

        public void Use(ToolData toolData)
        {
            Global.ChineseCabbageSeedCount.Value--;

            var plantGameObject = ResController.Instance
              .PlantChineseCabbagePrefab
              .Instantiate()
              .Position(toolData.GridCenterPos);

            var plant = plantGameObject.GetComponent<PlantChineseCabbage>();
            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;
            PlantController.Instance.Plants[toolData.CellPos] = plant;
            plant.SetState(PlantStates.Seed);
            toolData.ShowGrid[toolData.CellPos].HasPlant = true;
            AudioController.Instance.SfxSeed.Play();
        }
    }
}