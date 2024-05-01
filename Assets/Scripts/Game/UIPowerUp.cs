using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
	public partial class UIPowerUp : ViewController
	{
        private void Start()
        {
            UIShop.SetupBtnShowCheck(Global.Coin, BtnHandRange1, coin => coin >= 20 && !Global.HandRange1Unlock, gameObject);
            UIShop.SetupBtnShowCheck(Global.Coin, BtnShovelRange1, coin => coin >= 20 && !Global.ShovelRange1Unlock, gameObject);
            UIShop.SetupBtnShowCheck(Global.Coin, BtnWateringCan1, coin => coin >= 30 && !Global.WateringCan1Unlock, gameObject);


            BtnHandRange1.onClick.AddListener(() =>
            {
                Global.Coin.Value -= 20;
                Global.HandRange1Unlock = true;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnShovelRange1.onClick.AddListener(() =>
            {
                Global.Coin.Value -= 20;
                Global.ShovelRange1Unlock = true;
                AudioController.Instance.SfxBuy.Play();
            });

            BtnWateringCan1.onClick.AddListener(() =>
            {
                Global.Coin.Value -= 30;
                Global.WateringCan1Unlock = true;
                AudioController.Instance.SfxBuy.Play();
            });
        }
    }
}
