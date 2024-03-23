using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class ResController : ViewController,ISingleton
	{
		public GameObject SeedPrefab;
		public GameObject WaterPrefab;
		public GameObject SmallPlantPrefab;
		public GameObject RipePrefab;
		public GameObject PlantPrefab;
		public GameObject PlantRadishPrefab;

		public Sprite SeedSprite;
		public Sprite SmallPlantSprite;
		public Sprite RipeSprite;
		public Sprite OldSprite;

		public Sprite SeedRadishSprite;

		public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
          
        }
	}
}
