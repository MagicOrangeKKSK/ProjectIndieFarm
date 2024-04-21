using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolSeedRadish : ITool
    {
        public string Name { get; set; } = "seed_radish";

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].HasPlant != true &&
                        Global.RadishSeedCount.Value > 0;
        }


        public void Use(ToolData toolData)
        {
            Global.RadishSeedCount.Value--;

            var plantGameObject = ResController.Instance.PlantRadishPrefab
              .Instantiate()
              .Position(toolData.GridCenterPos);

            var plant = plantGameObject.GetComponent<PlantRadish>();
            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;
            PlantController.Instance.Plants[toolData.CellPos] = plant;
            plant.SetState(PlantStates.Seed);
            toolData.ShowGrid[toolData.CellPos].HasPlant = true;
            AudioController.Instance.SfxSeed.Play();
        }
    }
}