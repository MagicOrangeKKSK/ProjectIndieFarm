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
						Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
						grid[cellPosition.x, cellPosition.y] = new SoilData();
					}
				}

				//x,y 值
				//拿tilemap具体块
				//拿到具体块
			}

		}
	}
}
