using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using System.Linq;

namespace ProjectindieFarm
{
	public partial class GameController : ViewController
	{
		void Start()
		{
	

			ChallengeController.OnChalengeFinish.Register(challeng =>
			{
				AudioController.Instance.SfxChallengeFinish.Play();
				//���ȫ���������Ϸ����
				if(ChallengeController.Challenges.All(challenge=> challenge.State == Challenge.States.Finished))
				{
					ActionKit.Delay(0.5f, () =>
					{
						SceneManager.LoadScene("GamePass");
					}).Start(this);
				}
			

			}).UnRegisterWhenGameObjectDestroyed(this);

       
        }

		private void Update()
		{
		
		}
	}
}
