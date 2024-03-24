using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace ProjectindieFarm
{
	public partial class ToolController : ViewController
	{
        private GridController mGridController;
        private Grid mGrid;
        private EasyGrid<SoilData> mShowGrid;
        private Camera mMainCamera;
        private SpriteRenderer mSprite;

        private Tilemap mTilemap;
        private void Awake()
        {
            Global.Mouse = this;
        }

        private void OnDestroy()
        {
            Global.Mouse = null;
        }

        private void Start()
        {
            mGridController = FindObjectOfType<GridController>();
            mTilemap = mGridController.Tilemap;
             mGrid= mGridController.GetComponent<Grid>();
            mMainCamera = Camera.main; 
            mSprite = GetComponent<SpriteRenderer>();
            mShowGrid = mGridController.ShowGrid;

            mSprite.enabled = false;
        }

        private void Update()
        {
            var playerCellPos = mGrid.WorldToCell(Global.Player.Position());
            var worldMousePos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldMousePos.z = 0;
            var cellPos = mGrid.WorldToCell(worldMousePos + new Vector3(0.25f,-0.25f));

            Icon.Position(worldMousePos);
            mSprite.enabled = false;

            if (Mathf.Max(Mathf.Abs(cellPos.x - playerCellPos.x) , Mathf.Abs(cellPos.y - playerCellPos.y)) == 1)
            {
                if (cellPos.x < 10 && cellPos.x >= 0 && cellPos.y < 10 && cellPos.y >= 0)
                {
                    //耕地
                    if (Global.CurrentTool.Value == Constant.TOOL_SHOVEL &&
                            mShowGrid[cellPos] == null)
                    {
                        ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            mTilemap.SetTile(cellPos, mGridController.Pen);
                            mShowGrid[cellPos] = new SoilData();
                            AudioController.Instance.SfxShoveDig.Play();
                        }
                    }
                    //播种
                    else if (mShowGrid[cellPos] != null &&
                                 mShowGrid[cellPos].HasPlant != true &&
                    Global.CurrentTool.Value == Constant.TOOL_SEED)
                    {
                        Vector3 tileCenterPos = ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            var plantGameObject = ResController.Instance.PlantPrefab
                              .Instantiate()
                              .Position(tileCenterPos);

                            var plant = plantGameObject.GetComponent<Plant>();
                            plant.XCell = cellPos.x;
                            plant.YCell = cellPos.y;
                            PlantController.Instance.Plants[cellPos] = plant;
                            plant.SetState(PlantStates.Seed);
                            mShowGrid[cellPos].HasPlant = true;
                            AudioController.Instance.SfxSeed.Play();
                        }
                    }
                    else if (mShowGrid[cellPos] != null &&
                                mShowGrid[cellPos].HasPlant != true &&
                   Global.CurrentTool.Value == Constant.TOOL_SEED_RADISH)
                    {
                        Vector3 tileCenterPos = ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            var plantGameObject = ResController.Instance.PlantRadishPrefab
                              .Instantiate()
                              .Position(tileCenterPos);

                            var plant = plantGameObject.GetComponent<PlantRadish>();
                            plant.XCell = cellPos.x;
                            plant.YCell = cellPos.y;
                            PlantController.Instance.Plants[cellPos] = plant;
                            plant.SetState(PlantStates.Seed);
                            mShowGrid[cellPos].HasPlant = true;
                            AudioController.Instance.SfxSeed.Play();
                        }
                    }
                    //浇水
                    else if (mShowGrid[cellPos] != null &&
                                mShowGrid[cellPos].Watered != true &&
                                Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
                    {
                        Vector3 tileCenterPos = ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            mShowGrid[cellPos].Watered = true;
                            ResController.Instance.WaterPrefab
                                .Instantiate()
                                .Position(tileCenterPos);
                            mShowGrid[cellPos].Watered = true;
                            AudioController.Instance.SfxWater.Play();
                        }
                    }
                    //手
                    else if (mShowGrid[cellPos] != null &&
                    mShowGrid[cellPos].HasPlant == true &&
                    mShowGrid[cellPos].PlantStates == PlantStates.Ripe &&
                    Global.CurrentTool.Value == Constant.TOOL_HAND)
                    {
                         ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            Global.OnPlantharvest.Trigger(PlantController.Instance.Plants[cellPos]);
                            Global.HarvestCountInCurrentDay.Value++;

                            if (PlantController.Instance.Plants[cellPos] as Plant)
                            {
                                Global.FruitCount.Value++;
                            }
                            else if (PlantController.Instance.Plants[cellPos] as PlantRadish)
                            {
                                Global.RadishCount.Value++;
                            }

                            Destroy(PlantController.Instance.Plants[cellPos].GameObject);//.SetState(PlantStates.Old);
                            mShowGrid[cellPos].HasPlant = false;
                            //PlantController.Instance.Plants[cellPos].SetState(PlantStates.Old);
                            AudioController.Instance.SfxHarvest.Play();
                        }
                    }
                }
            }
        }

        private Vector3 ShowSelect(Vector3Int cellPos)
        {
            var gridOriginPos = mGrid.CellToWorld(cellPos);
            var gridCenterPos = gridOriginPos + mGrid.cellSize * 0.5f;
            transform.Position(gridCenterPos);
            mSprite.enabled = true;
            return gridCenterPos;
        }
    }
}
