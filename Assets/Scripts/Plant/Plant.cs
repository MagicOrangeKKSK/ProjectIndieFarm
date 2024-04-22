using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public interface IPlant
	{
		GameObject GameObject { get; }
		PlantStates State { get; }

		void SetState(PlantStates state);
		void Grow(SoilData soilData);
		int RipeDay { get; }
		int XCell { get; set; }
		int YCell { get; set; }
	}

	public partial class Plant : ViewController,IPlant
	{
		public int XCell { get;  set; }
		public int YCell { get;  set; }

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
                    SetState(PlantStates.Ripe);
                }
            }
        }
    }

}
