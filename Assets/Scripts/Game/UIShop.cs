using UnityEngine;
using QFramework;
using System.Linq;
using UnityEngine.UI;
using System;

namespace ProjectindieFarm
{
	public partial class UIShop : ViewController
	{
    	public static void SetupBtnShowCheck(BindableProperty<int> itemCount,Button btn,Func<int,bool> showCondition,GameObject gameObject)
		{
            itemCount.RegisterWithInitValue(count =>
            {
                btn.SetActive(showCondition(count));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        void Start()
		{
			SetupBtnShowCheck(Global.FruitCount,BtnSellFruit,count=>count>=1,gameObject);
			SetupBtnShowCheck(Global.RadishCount, BtnSellRadish, count=>count>=1, gameObject);
			SetupBtnShowCheck(Global.ChineseCabbageCount, BtnSellChineseCabbage, count=>count>=1, gameObject);
			SetupBtnShowCheck(Global.Coin, BtnBuyFruitSeed, c => c >= 5, gameObject);
			SetupBtnShowCheck(Global.Coin, BtnBuyRadishSeed, c => c >= 2, gameObject);
			SetupBtnShowCheck(Global.Coin, BtnBuyChineseCabbageSeed, c => c >= 3, gameObject);


            BtnBuyFruitSeed.onClick.AddListener(() =>
            {
                var seedItem = Config.Items.Single(i => i.Name == "seed");
                seedItem.Count.Value += 1;
                Global.Coin.Value -= 5;
				AudioController.Instance.SfxBuy.Play();
            });

            BtnBuyRadishSeed.onClick.AddListener(() =>
            {
                var seedItem = Config.Items.Single(i => i.Name == "seed_radish");
                seedItem.Count.Value += 1;
                Global.Coin.Value -= 2;
                AudioController.Instance.SfxBuy.Play();
            });
            
            BtnBuyChineseCabbageSeed.onClick.AddListener(() =>
            {
                var seedItem = Config.Items.Single(i => i.Name == "seed_chinese_cabbage");
                seedItem.Count.Value += 1;
                Global.Coin.Value -= 3;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnSellFruit.onClick.AddListener(() =>
            {
                Global.Coin.Value += 3;
                Global.FruitCount.Value -= 1;
                AudioController.Instance.SfxBuy.Play();
            });


            BtnSellRadish.onClick.AddListener(() =>
            {
                Global.Coin.Value += 5;
                Global.RadishCount.Value -= 1;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnSellChineseCabbage.onClick.AddListener(() =>
            {
                Global.Coin.Value += 8;
                Global.ChineseCabbageCount.Value -= 1;
                AudioController.Instance.SfxBuy.Play();
            });

        }


	}
}
