using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
    public partial class PlantChineseCabbage : ViewController, IPlant
    {
        public int XCell {  get; set; }
        public int YCell {  get; set; }

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;

        public GameObject GameObject => gameObject;

        public int RipeDay { get; private set; } = -1;

        public void SetState(PlantStates newState)
        {
            if (newState != mState)
            {
                if (mState == PlantStates.Small && newState == PlantStates.Ripe)
                {
                    RipeDay = Global.Days.Value;
                }

                mState = newState;
                //切换表现
                if (newState == PlantStates.Small)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantChineseCabbageSprite;
                }
                else if (newState == PlantStates.Ripe)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeChineseCabbageSprite;
                }
                else if (newState == PlantStates.Seed)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedChineseCabbageSprite;
                }
                else if (newState == PlantStates.Old)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                //同步数据
                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantStates = newState;
            }
        }
        public int mSeedStateDay = 0;
        public int mSmallStateDay = 0;

        public void Grow(SoilData soilData)
        {
            if (State == PlantStates.Seed)
            {
                if (soilData.Watered)
                {
                    mSeedStateDay++;
                    if (mSeedStateDay == 2)
                    {
                        SetState(PlantStates.Small);
                    }
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
