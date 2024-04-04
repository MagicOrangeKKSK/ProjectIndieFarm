using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class TimeController : ViewController
	{
		public static float Seconds = 0;

        private void Start()
        {
			Seconds = 0;
        }

        private void Update()
        {
			Seconds += Time.deltaTime;
        }

        private void OnGUI()
		{
			IMGUIHelper.SetDesignResolution(640, 360);
			GUI.Label(new Rect(640 - 50, 360 - 20, 640 - 100, 360 - 40), $"{(int)Seconds}s");
			

		}


        private void OnDestroy()
        {
            Debug.Log($"总共通关花费：{Seconds}s");
        }
    }
}
