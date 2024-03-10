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

		public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        public void OnSingletonInit()
        {
          
        }
	}
}
