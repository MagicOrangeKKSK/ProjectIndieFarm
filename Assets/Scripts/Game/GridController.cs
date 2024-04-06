using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
	public partial class GridController : ViewController
	{
		private EasyGrid<SoilData> mShowGrid = new EasyGrid<SoilData>(10, 10);
		public EasyGrid<SoilData> ShowGrid => mShowGrid;
		
		public TileBase Pen;
		public TileBase PlantablePen;

		void Start()
		{
			Soil.ClearAllTiles();

			mShowGrid[0, 0] = new SoilData();
			mShowGrid[2, 2] = new SoilData();

			for(int i = 0; i < 10; i++)
			{
				for(int j = 0; j < 10; j++)
				{
                    Ground.SetTile(new Vector3Int(i,j),PlantablePen);
                }
            }

			mShowGrid.ForEach((x, y, show) =>
			{
				if (show != null)
                    Soil.SetTile(new Vector3Int(x, y), Pen);
			});
		}

		private void OnGUI()
		{
			var grid = FindObjectOfType<Grid>();
			mShowGrid.ForEach((x, y, _) =>
			{
				var tileWorldPos = grid.CellToWorld(new Vector3Int(x, y));
				var tl = tileWorldPos;
				var tr = tileWorldPos + new Vector3(grid.cellSize.x, 0);
				var bl = tileWorldPos + new Vector3(0, grid.cellSize.y, 0);
				var br = tileWorldPos + new Vector3(grid.cellSize.x, grid.cellSize.y, 0);

				Debug.DrawLine(tl, tr, Color.red,5);
				Debug.DrawLine(tl, bl, Color.red,5);
				Debug.DrawLine(tr, br, Color.red,5);
				Debug.DrawLine(bl, br, Color.red,5);
			});
		}
	}
}
