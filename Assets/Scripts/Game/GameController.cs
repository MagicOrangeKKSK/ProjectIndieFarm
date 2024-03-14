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
			Global.OnChalengeFinish.Register(challengs =>
			{
				Debug.Log("ÌôÕ½Íê³É");
			}).UnRegisterWhenGameObjectDestroyed(this);


		}

		private void Update()
		{
			foreach (var challenge in Global.Challenges.Where(challenge => challenge.State != Challenge.States.Finished)) 
			{
				if(challenge.State == Challenge.States.NotStart)
				{
					challenge.State = Challenge.States.Started;
					challenge.OnStart();
				}

				if(challenge.State == Challenge.States.Started)
				{
					if (challenge.CheckFinish())
					{
						challenge.OnFinish();
						challenge.State = Challenge.States.Finished;
						Global.OnChalengeFinish.Trigger(challenge);
					}
				}
			}
		}
	}
}
