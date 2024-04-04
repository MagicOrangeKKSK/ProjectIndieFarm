using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class Home : ViewController
	{

		void Start()
		{
			// Code Here
		}

        private void OnTriggerEnter2D(Collider2D collision)
        {
			if (collision.name.StartsWith("Player"))
			{
				Global.Days.Value++;
				collision.PositionY(this.PositionY() - 3);
                AudioController.Instance.SfxNextDay.Play();
            }

        }
    }
}
