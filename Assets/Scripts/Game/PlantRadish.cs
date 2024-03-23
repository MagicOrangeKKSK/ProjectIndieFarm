using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class PlantRadish : ViewController,IPlant
	{
		public int XCell;
		public int YCell;

		private PlantStates mState = PlantStates.Seed;
		public PlantStates State => mState;

		public GameObject GameObject => gameObject;

        public int RipeDay { get; private set; } = -1;
	
		public void SetState(PlantStates newState)
		{
			if(newState != mState)
			{
				if(mState == PlantStates.Small && newState == PlantStates.Ripe)
				{
					RipeDay = Global.Days.Value;
				}

				mState = newState;
				//�л�����
				if(newState == PlantStates.Small)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantRadishSprite;
				}  
				else if(newState == PlantStates.Ripe)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeRadishSprite;
				}
				else if(newState == PlantStates.Seed)
				{
					GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedRadishSprite;
				}
				else if(newState == PlantStates.Old)
				{
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                //ͬ������
                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantStates = newState;
			}
		}
        public int mSmallStateDay = 0;

        public void Grow(SoilData soilData)
        {
			if (State == PlantStates.Seed)
			{
				if (soilData.Watered)
				{
					SetState(PlantStates.Small);
				}
			}
			else if (State == PlantStates.Small)
			{
				if (soilData.Watered)
				{
					mSmallStateDay++;
					if (mSmallStateDay == 2)
					{
						SetState(PlantStates.Ripe);
					}
				}
			}
		}
	}

}
