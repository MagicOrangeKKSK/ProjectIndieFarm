using UnityEngine;
using QFramework;
using System.Linq;

namespace ProjectindieFarm
{
	public partial class UIShop : ViewController
	{
		void Start()
		{
			Global.FruitCount.RegisterWithInitValue(fruitCount =>
			{
				if(fruitCount >=1)
				{
					BtnBuyFruitSeed.Show();
				}
				else
				{
					BtnBuyFruitSeed.Hide();
				}

				if(fruitCount >= 2)
				{
                    BtnBuyRadish.Show();
				}
				else
				{
                    BtnBuyRadish.Hide();
				}



			}).UnRegisterWhenGameObjectDestroyed(gameObject);


			Global.RadishCount.RegisterWithInitValue(radishCount =>
			{
				if(radishCount >=1)
				{
					BtnBuyRadishSeed.Show();
				}
				else
				{
					BtnBuyRadishSeed.Hide();
				}

				if(radishCount >= 2)
				{
					BtnBuyFruit.Show();
				}
				else
				{
                    BtnBuyFruit.Hide();
				}

			}).UnRegisterWhenGameObjectDestroyed(gameObject);


			BtnBuyFruitSeed.onClick.AddListener(() =>
			{
				var seedItem = Config.Items.Single(i => i.Name == "seed");
				seedItem.Count.Value += 2;

				Global.FruitCount.Value -= 1;
				AudioController.Instance.SfxBuy.Play();
			});

			BtnBuyRadishSeed.onClick.AddListener(() =>
			{
				var seedItem = Config.Items.Single(i => i.Name == "seed_radish");
                seedItem.Count.Value += 2;

                Global.RadishCount.Value -= 1;
				AudioController.Instance.SfxBuy.Play();
			});

            BtnBuyFruit.onClick.AddListener(() => 
			{
				Global.RadishCount.Value -= 2;
				Global.FruitCount.Value += 1;
				AudioController.Instance.SfxBuy.Play();
			});

            BtnBuyRadish.onClick.AddListener(() =>
			{
				Global.FruitCount.Value -= 2;
				Global.RadishCount.Value += 1;
				AudioController.Instance.SfxBuy.Play();
			});

        }


	}
}
