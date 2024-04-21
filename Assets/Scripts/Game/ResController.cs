using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class ResController : ViewController,ISingleton
	{
        public GameObject WaterPrefab;
        public GameObject PlantPrefab;
        public GameObject PlantRadishPrefab;
        public GameObject PlantChineseCabbagePrefab;

        public GameObject SeedPrefab;
		public GameObject SmallPlantPrefab;
		public GameObject RipePrefab;

		public Sprite SeedSprite;
		public Sprite SmallPlantSprite;
		public Sprite RipeSprite;
		public Sprite OldSprite;

		public Sprite SeedRadishSprite;
		public Sprite SmallPlantRadishSprite;
		public Sprite RipeRadishSprite;

        public Sprite SeedChineseCabbageSprite;
        public Sprite SmallPlantChineseCabbageSprite;
        public Sprite RipeChineseCabbageSprite;

        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
          
        }
	}
}
