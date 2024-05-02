using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class UIPowerUp : ViewController
	{
        private void Start()
        {
            //解锁顺序
            //花洒
            //手
            //种子
            //铁锹
            UIShop.SetupBtnShowCheck(Global.Coin, BtnWateringCan1, coin => coin >= 30 
            && !Global.WateringCanRange1Unlock, gameObject);

            UIShop.SetupBtnShowCheck(Global.Coin, BtnHandRange1, coin => coin >= 20 
            && !Global.HandRange1Unlock 
            && Global.WateringCanRange1Unlock, gameObject);

            UIShop.SetupBtnShowCheck(Global.Coin, BtnSeedRange1, coin => coin >= 25 
            && !Global.SeedRange1Unlock
            && Global.HandRange1Unlock, gameObject);

            UIShop.SetupBtnShowCheck(Global.Coin, BtnShovelRange1, coin => coin >= 20 
            && !Global.ShovelRange1Unlock
            && Global.SeedRange1Unlock, gameObject);




            BtnHandRange1.onClick.AddListener(() =>
            {
                Global.HandRange1Unlock = true;
                Global.Coin.Value -= 20;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnShovelRange1.onClick.AddListener(() =>
            {
                Global.ShovelRange1Unlock = true;
                Global.Coin.Value -= 20;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnWateringCan1.onClick.AddListener(() =>
            {
                Global.WateringCanRange1Unlock = true;
                Global.Coin.Value -= 30;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnSeedRange1.onClick.AddListener(() =>
            {
                Global.SeedRange1Unlock = true;
                Global.Coin.Value -= 25;
                AudioController.Instance.SfxBuy.Play();
            });
        }
    }
}
