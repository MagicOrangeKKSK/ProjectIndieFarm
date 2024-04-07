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
            mTilemap = mGridController.Soil;
             mGrid= mGridController.GetComponent<Grid>();
            mMainCamera = Camera.main; 
            mSprite = GetComponent<SpriteRenderer>();
            mShowGrid = mGridController.ShowGrid;

            mSprite.enabled = false;
        }
        
     
        private ToolData mToolData = new ToolData();

        private void Update()
        {
            var playerCellPos = mGrid.WorldToCell(Global.Player.Position());
            var worldMousePos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldMousePos.z = 0;

            var cellPos = mGrid.WorldToCell(worldMousePos + new Vector3(0.25f,-0.25f));

            mSprite.enabled = false;

            if (Mathf.Max(Mathf.Abs(cellPos.x - playerCellPos.x) , Mathf.Abs(cellPos.y - playerCellPos.y)) == 1 || 
               (cellPos.x - playerCellPos.x == 0 && cellPos.y - playerCellPos.y == 0 ) //目前嗐没有带碰撞的植物 
               )
            {
                if (cellPos.x < 10 && cellPos.x >= 0 && cellPos.y < 10 && cellPos.y >= 0)
                {
                    mToolData.ShowGrid = mShowGrid;
                    mToolData.CellPos = cellPos;
                    mToolData.Pen = mGridController.Pen;
                    mToolData.SoilTilemap = mTilemap;

                    if (Global.CurrentTool.Value.Selectable(mToolData))
                    {
                        mToolData.GridCenterPos = ShowSelect(cellPos);
                        if (Input.GetMouseButton(0))
                        {
                            Global.CurrentTool.Value.Use(mToolData);
                        }
                    }
                }
            }

            Icon.Position(worldMousePos);

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
