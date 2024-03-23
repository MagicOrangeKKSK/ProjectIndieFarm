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
					if (plant != null)
					{
						plant.Grow(soilDatas[x, y]);
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
            GUILayout.Label("下一天:F");
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