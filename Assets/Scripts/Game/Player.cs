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
			if (Input.GetMouseButtonDown(0))
			{
				var cellPosition = Grid.WorldToCell(transform.position);
				//Tilemap.SetTile(cellPosition, null);

				var grid = FindObjectOfType<GridController>().ShowGrid;
				if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
				{
					if (grid[cellPosition.x, cellPosition.y] == null)
					{
						//耕地
						Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
						grid[cellPosition.x, cellPosition.y] = new SoilData();
					}
					else if (grid[cellPosition.x,cellPosition.y].HasPlant != true)
					{
					  var tileWorldPos =	Grid.CellToWorld(cellPosition);
						tileWorldPos.x += Grid.cellSize.x * 0.5f;
						tileWorldPos.y += Grid.cellSize.y * 0.5f;

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
				var cellPosition = Grid.WorldToCell(transform.position);
				//Tilemap.SetTile(cellPosition, null);

				var grid = FindObjectOfType<GridController>().ShowGrid;
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
