using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using HutongGames.PlayMaker.Actions;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.Burst.CompilerServices;

namespace ProjectindieFarm
{
	public partial class Player : ViewController
	{
		public Grid Grid;
		public Tilemap Tilemap;

        private void Awake()
        {
			Global.Player = this;
        }

        private void OnDestroy()
        {
			Global.Player = null;
        }

        void Start()
		{
			Global.Days.Register((day) =>
			{
		 
				Global.RipeAndHarvesCountInCurrentDay.Value = 0;
				Global.HarvestCountInCurrentDay.Value = 0;

				var soilDatas = FindObjectOfType<GridController>().ShowGrid;

				PlantController.Instance.Plants.ForEach((x, y, plant) =>
				{
					if (plant)
					{

						if (plant.State == PlantStates.Seed)
						{
							if (soilDatas[x, y].Watered)
							{
								plant.SetState(PlantStates.Small);
							}
						}
						else if (plant.State == PlantStates.Small)
						{
							if (soilDatas[x, y].Watered)
							{
								plant.SetState(PlantStates.Ripe);
							}
						}
					}
				});

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
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
			GUILayout.BeginVertical();
			GUILayout.Label("天数:" + Global.Days.Value);
            GUILayout.Label("果子:" + Global.FruitCount.Value);
            GUILayout.Label("收割的果子:" + Global.RipeAndHarvesCountInCurrentDay);
            GUILayout.Label("下一天:F");
            GUILayout.Label("鼠标左键:摘果");
            GUILayout.Label("鼠标右键:移除");
			GUILayout.EndVertical();
            GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
            //GUI.Label(new Rect(10,360-20,200,24), $"[1]手  [2]锄头 [3]种子 [4]水壶");


        }

        private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				Global.Days.Value++;
				AudioController.Instance.SfxNextDay.Play();
			}

			var cellPosition = Grid.WorldToCell(transform.position);
			var grid = FindObjectOfType<GridController>().ShowGrid;
			var tileWorldPos = Grid.CellToWorld(cellPosition);
			tileWorldPos.x += Grid.cellSize.x * 0.5f;
			tileWorldPos.y += Grid.cellSize.y * 0.5f;
			if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
			{
				if (Global.CurrentTool.Value == Constant.TOOL_SHOVEL &&
					grid[cellPosition.x, cellPosition.y] == null)
				{
					TileSelectController.Instance.Position(tileWorldPos);
					TileSelectController.Instance.Show();
				}
				else if (grid[cellPosition] != null &&
					grid[cellPosition].HasPlant != true &&
					Global.CurrentTool.Value == Constant.TOOL_SEED)
				{
					TileSelectController.Instance.Position(tileWorldPos);
					TileSelectController.Instance.Show();
				}
				else if (grid[cellPosition] != null &&
				grid[cellPosition].Watered != true &&
				Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
				{
					TileSelectController.Instance.Position(tileWorldPos);
					TileSelectController.Instance.Show();
				}
				else if (grid[cellPosition] != null &&
					grid[cellPosition].HasPlant == true &&
					grid[cellPosition].PlantStates == PlantStates.Ripe &&
					Global.CurrentTool.Value == Constant.TOOL_HAND) 
				{
                    TileSelectController.Instance.Position(tileWorldPos);
                    TileSelectController.Instance.Show();
                }
				else
				{
					TileSelectController.Instance.Hide();
				}
            }
			else
			{
				TileSelectController.Instance.Hide();
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
				{
					if (grid[cellPosition.x, cellPosition.y] == null && Global.CurrentTool.Value == Constant.TOOL_SHOVEL)
					{
						//耕地
						Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
						grid[cellPosition] = new SoilData();
				    	AudioController.Instance.SfxShoveDig.Play();
                    }
                    else if (grid[cellPosition] != null &&
						grid[cellPosition].HasPlant != true &&
						Global.CurrentTool.Value == Constant.TOOL_SEED)
					{

						var plantGameObject = ResController.Instance.PlantPrefab
								.Instantiate()
								.Position(tileWorldPos);

						var plant = plantGameObject.GetComponent<Plant>();
						plant.XCell = cellPosition.x;
						plant.YCell = cellPosition.y;
						PlantController.Instance.Plants[cellPosition] = plant;
                        plant.SetState(PlantStates.Seed);
                        grid[cellPosition].HasPlant = true;
                        AudioController.Instance.SfxSeed.Play();

                    }
                    else if (grid[cellPosition] != null &&
					   grid[cellPosition].Watered != true &&
					   Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
					{
						grid[cellPosition].Watered = true;
						ResController.Instance.WaterPrefab
							.Instantiate()
							.Position(tileWorldPos);
						grid[cellPosition].Watered = true;
					AudioController.Instance.SfxWater.Play();
                    }
                    else if (grid[cellPosition] != null &&
						grid[cellPosition].HasPlant == true &&
						grid[cellPosition].PlantStates == PlantStates.Ripe &&
						Global.CurrentTool.Value == Constant.TOOL_HAND)
					{
						Global.OnPlantharvest.Trigger(PlantController.Instance.Plants[cellPosition]);
						Global.HarvestCountInCurrentDay.Value++;

						Destroy(PlantController.Instance.Plants[cellPosition].gameObject);//.SetState(PlantStates.Old);
						grid[cellPosition].HasPlant = false;
						PlantController.Instance.Plants[cellPosition].SetState(PlantStates.Old);
						Global.FruitCount.Value++;
                        AudioController.Instance.SfxHarvest.Play();
					}

				}
			}


            if (Input.GetMouseButtonDown(1))
			{

				if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
				{
					if (grid[cellPosition] != null)
					{
						Tilemap.SetTile(cellPosition, null);
						grid[cellPosition] = null;
					}
				}
			}

            if (Input.GetKeyDown(KeyCode.E))
            {
           
            }

			if (Input.GetKeyDown(KeyCode.Return))
			{
				SceneManager.LoadScene("GamePass");
			}

	
        }
    }
}