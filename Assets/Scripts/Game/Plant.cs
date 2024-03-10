using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class Plant : ViewController
	{
		public int XCell;
		public int YCell;

		private PlantStates mState = PlantStates.Seed;
		public PlantStates State => mState;
	
		public void SetState(PlantStates newState)
		{
			if(newState != mState)
			{
				mState = newState;
				//切换表现
				if(newState == PlantStates.Small)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantSprite;
				}  
				else if(newState == PlantStates.Ripe)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeSprite;
				}
				else if(newState == PlantStates.Seed)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedSprite;
				}
				else if(newState == PlantStates.Old)
				{
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                //同步数据
                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantStates = newState;
			}
		}
	
	}

}
