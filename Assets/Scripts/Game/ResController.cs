using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System.Linq;

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

        public List<Sprite> Sprites = new List<Sprite>();

        public Sprite LoadSprite(string spriteName)
        {
            return Sprites.Single(spr => spr.name == spriteName);
        }

        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
          
        }
	}
}
