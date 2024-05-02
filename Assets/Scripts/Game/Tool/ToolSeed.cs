using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolSeed : ITool
    {
        public string Name { get; set; } = "seed";
        public Item Item { get; set; }

        public int Range => Global.SeedRange1Unlock ? 2 : 1;

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos] != null &&
                        toolData.ShowGrid[toolData.CellPos].HasPlant != true &&
                        Item.Count.Value > 0 ;
        }


        public void Use(ToolData toolData)
        {
            Item.Count.Value--;

            var plantGameObject = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
      .Instantiate()
      .Position(toolData.GridCenterPos);
            var plant = plantGameObject.GetComponent<IPlant>();
            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;
            PlantController.Instance.Plants[toolData.CellPos] = plant;
            plant.SetState(PlantStates.Seed);
            toolData.ShowGrid[toolData.CellPos].HasPlant = true;
            AudioController.Instance.SfxSeed.Play();
 
        }
    }
}