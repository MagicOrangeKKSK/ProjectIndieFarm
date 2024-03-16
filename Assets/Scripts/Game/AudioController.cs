using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class AudioController : ViewController,ISingleton
	{

		public static AudioController Instance => MonoSingletonProperty<AudioController>.Instance;
        public void OnSingletonInit()
        {
         
        }

	}
}
