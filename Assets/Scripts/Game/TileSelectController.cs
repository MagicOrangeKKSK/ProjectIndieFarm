using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class TileSelectController : ViewController,ISingleton
	{
        public static TileSelectController Instance => MonoSingletonProperty<TileSelectController>.Instance;

        public void OnSingletonInit()
        {
        }
 
	}
}
