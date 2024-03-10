using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
	public partial class Player : ViewController
	{
		public Grid Grid;
		public Tilemap Tilemap;

		void Start()
		{
			// Code Here
		}

		private void Update()
		{
			var cellPosition = Grid.WorldToCell(transform.position);
			var grid = FindObjectOfType<GridController>().ShowGrid;
			var tileWorldPos = Grid.CellToWorld(cellPosition);
			tileWorldPos.x += Grid.cellSize.x * 0.5f;
			tileWorldPos.y += Grid.cellSize.y * 0.5f;
			if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
			{
				TileSelectController.Instance.Position(tileWorldPos);
				TileSelectController.Instance.Show();
			}
			else
			{
				TileSelectController.Instance.Hide();
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
				{
					if (grid[cellPosition.x, cellPosition.y] == null)
					{
						//耕地
						Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
						grid[cellPosition.x, cellPosition.y] = new SoilData();
					}
					else if (grid[cellPosition.x, cellPosition.y].HasPlant != true)
					{
						grid[cellPosition.x, cellPosition.y].HasPlant = true;
						//放种子
						ResController.Instance.SeedPrefab
							.Instantiate()
							.Position(tileWorldPos);
					}
					else
					{
					}
				}
			}


			if (Input.GetMouseButtonDown(1))
			{

				if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
				{
					if (grid[cellPosition.x, cellPosition.y] != null)
					{
						Tilemap.SetTile(cellPosition, null);
						grid[cellPosition.x, cellPosition.y] = null;
					}
				}
			}
		}
	}
}