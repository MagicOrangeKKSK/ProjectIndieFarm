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
            GUILayout.Label("下一天:F");
            GUILayout.Label("浇水:E" );
            GUILayout.Label("鼠标左键:摘果");
            GUILayout.Label("鼠标右键:移除");
            GUILayout.Label($"当前工具：{Global.CurrentToolName.Value}");
			GUILayout.EndVertical();
            GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
            GUI.Label(new Rect(10,360-20,200,24), $"[1] 手  [2]锄头");


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
					if (grid[cellPosition.x, cellPosition.y] == null && Global.CurrentToolName.Value == "锄头")
					{
						//耕地
						Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
						grid[cellPosition] = new SoilData();
					}
					return;
					 if (grid[cellPosition].HasPlant != true)
					{

					var plantGameObject=	ResController.Instance.PlantPrefab
							.Instantiate()
							.Position(tileWorldPos);

					 var plant =	plantGameObject.GetComponent<Plant>();
						plant.XCell = cellPosition.x;
						plant.YCell = cellPosition.y;
						PlantController.Instance.Plants[cellPosition] = plant;

						grid[cellPosition].HasPlant = true;
						
					}
                    else if (grid[cellPosition].HasPlant == true)
                    {
						if (grid[cellPosition].PlantStates == PlantStates.Ripe)
						{
							Destroy(PlantController.Instance.Plants[cellPosition].gameObject);//.SetState(PlantStates.Old);
							grid[cellPosition].HasPlant = false;
							Global.FruitCount.Value++;
						}
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
                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                   if (grid[cellPosition] != null && grid[cellPosition].Watered != true)
                    {
                        grid[cellPosition].Watered = true;
                        //放种子
                        ResController.Instance.WaterPrefab
                            .Instantiate()
                            .Position(tileWorldPos);
						grid[cellPosition].Watered = true;
                    }

                }
            }

			if (Input.GetKeyDown(KeyCode.Return))
			{
				SceneManager.LoadScene("GamePass");
			}

			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				Global.CurrentToolName.Value = "手";
			}

			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				Global.CurrentToolName.Value = "锄头";
			}
        }
    }
}