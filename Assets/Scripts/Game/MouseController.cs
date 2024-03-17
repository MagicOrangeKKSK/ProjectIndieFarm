using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class MouseController : ViewController
	{
        private Grid mGrid;
        private Camera mMainCamera;
        private SpriteRenderer mSprite;
        private void Start()
        {
             mGrid= FindObjectOfType<GridController>().GetComponent<Grid>();
            mMainCamera = Camera.main; 
            mSprite = GetComponent<SpriteRenderer>();

            mSprite.enabled = false;
        }

        private void Update()
        {
            var playerCellPos = mGrid.WorldToCell(Global.Player.Position());
            var worldMousePos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
            var cellPos = mGrid.WorldToCell(worldMousePos);

            if(Mathf.Max(Mathf.Abs(cellPos.x - playerCellPos.x) , Mathf.Abs(cellPos.y - playerCellPos.y)) == 1)
            {
                var gridOriginPos = mGrid.CellToWorld(cellPos);
                gridOriginPos += mGrid.cellSize * 0.5f;
                transform.Position(gridOriginPos);
                mSprite.enabled = true;
            }
            else
            {
                mSprite.enabled = false;
            }
        
        }
    }
}
