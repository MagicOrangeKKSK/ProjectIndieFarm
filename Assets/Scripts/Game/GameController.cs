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
			var randomItem = Global.Challenges.GetRandomItem();
			Global.ActiveChallenges.Add(randomItem);

			Global.OnChalengeFinish.Register(challeng =>
			{
				AudioController.Instance.SfxChallengeFinish.Play();
				//���ȫ���������Ϸ����
				if(Global.Challenges.All(challenge=> challenge.State == Challenge.States.Finished))
				{
					ActionKit.Delay(0.5f, () =>
					{
						SceneManager.LoadScene("GamePass");
					}).Start(this);
				}
			

			}).UnRegisterWhenGameObjectDestroyed(this);

            //���������ֲ���Ƿ�������ҵ����ո��
            Global.OnPlantharvest.Register(plant =>
            {
				if(plant is Plant)
				{
					Global.HarvestCountInCurrentDay.Value++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        Global.RipeAndHarvesCountInCurrentDay.Value++;
                    }
                }
				else if(plant is PlantRadish)
				{
					Global.RadishHarvestCountInCurrentDay.Value++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        Global.RipeAndHarvesRadishCountInCurrentDay.Value++;
                    }
                }

            }).UnRegisterWhenGameObjectDestroyed(this);

        }

		private void Update()
		{
			bool hasFinishChallenge = false;
			foreach (var challenge in Global.ActiveChallenges)
			{
				if (challenge.State == Challenge.States.NotStart)
				{
					challenge.StartDate = Global.Days.Value;
					challenge.OnStart();
					challenge.State = Challenge.States.Started;
                }

                if (challenge.State == Challenge.States.Started)
				{
					if (challenge.CheckFinish())
					{
						challenge.OnFinish();
						challenge.State = Challenge.States.Finished;
						Global.OnChalengeFinish.Trigger(challenge);
						Global.FinishedChallenges.Add(challenge);
						hasFinishChallenge = true;

					}
				}
			}

			if (hasFinishChallenge)
			{
				Global.ActiveChallenges.RemoveAll(challenge => challenge.State == Challenge.States.Finished);
			}

			if (Global.ActiveChallenges.Count == 0 &&
				Global.FinishedChallenges.Count != Global.Challenges.Count)
			{
				//�������ѡ��һ��δ��ʼ����ս����
				var randomItem = Global.Challenges.Where(c => c.State == Challenge.States.NotStart).ToList().GetRandomItem();
				Global.ActiveChallenges.Add(randomItem);
			}
		}
	}
}
