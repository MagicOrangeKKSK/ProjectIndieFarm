using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolShovel : ITool
    {
        public string Name { get; set; } = "shovel";

        public bool Selectable(ToolData toolData)
        {
            return  toolData.ShowGrid[toolData.CellPos] == null;
        }

  
        public void Use(ToolData toolData)
        {
            toolData.SoilTilemap.SetTile(toolData.CellPos, toolData.Pen);
            toolData.ShowGrid[toolData.CellPos] = new SoilData();
            AudioController.Instance.SfxShoveDig.Play();
        }
    }
}