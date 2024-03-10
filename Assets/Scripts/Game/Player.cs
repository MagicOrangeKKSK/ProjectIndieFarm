using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using HutongGames.PlayMaker.Actions;
using UnityEngine.SceneManagement;
using System.Linq;

namespace ProjectindieFarm
{
	public partial class Player : ViewController
	{
		public Grid Grid;
		public Tilemap Tilemap;

		void Start()
		{
			Global.Days.Register((day) =>
			{
                var soilDatas = FindObjectOfType<GridController>().ShowGrid;

                var smallPlants = SceneManager.GetActiveScene()
				.GetRootGameObjects()
				.Where(gameObject => gameObject.name.StartsWith("SmallPlant"));
                foreach (var smallPlant in smallPlants)
                {
                    var tilePos = Grid.WorldToCell(smallPlant.transform.position);
                    var tileData = soilDatas[tilePos.x, tilePos.y];
                    if (tileData != null && tileData.Watered)
                    {
                        ResController.Instance.RipePrefab.Instantiate().Position(smallPlant.transform.position);
                        smallPlant.DestroySelf();
 
                    }
                }


                var seeds = SceneManager.GetActiveScene()
			   .GetRootGameObjects()
			   .Where(gameObj => gameObj.name.StartsWith("Seed"));

				foreach (var seed in seeds)
				{
					var tilePos = Grid.WorldToCell(seed.transform.position);
					var tileData = soilDatas[tilePos.x, tilePos.y];
					if (tileData != null && tileData.Watered)
					{
						ResController.Instance.SmallPlantPrefab.Instantiate().Position(seed.transform.position);
						seed.DestroySelf();
					}
				}

				soilDatas.ForEach(soilData =>
				{
					if (soilData != null) 
					{
					soilData.Watered = false;
                    }
                });
				SceneManager.GetActiveScene()
			.GetRootGameObjects()
			.Where(gameObj => gameObj.name.StartsWith("Water"))
			.ForEach(water => water.DestroySelf());
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

        public void OnGUI()
        {
			IMGUIHelper.SetDesignResolution(640, 360);
			GUILayout.Space(10);
			GUILayout.BeginHorizontal();
			GUILayout.Space(10);
			GUILayout.Label("天数:" + Global.Days.Value);
			GUILayout.EndHorizontal();
        }

        private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				Global.Days.Value++;
			}

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                   if (grid[cellPosition.x, cellPosition.y] != null && grid[cellPosition.x,cellPosition.y].Watered != true)
                    {
                        grid[cellPosition.x, cellPosition.y].Watered = true;
                        //放种子
                        ResController.Instance.WaterPrefab
                            .Instantiate()
                            .Position(tileWorldPos);
						grid[cellPosition.x, cellPosition.y].Watered = true;
                    }

                }
            }

        }
    }
}