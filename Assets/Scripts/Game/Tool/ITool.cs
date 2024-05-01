using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
    public class ToolData
    {
        public EasyGrid<SoilData> ShowGrid { get; set; }
        public Vector3Int CellPos { get; set; }
        public Tilemap SoilTilemap { get; set; }
        public TileBase Pen { get; set; }

        public Vector3 GridCenterPos { get; set; }
    }
    public interface ITool 
    {
        public Item Item { get; set; }
        int Range { get;  }

         public string Name { get; set; }
        //bool Selectable();
        bool Selectable(ToolData toolData);
        void Use(ToolData toolData);
    }
}