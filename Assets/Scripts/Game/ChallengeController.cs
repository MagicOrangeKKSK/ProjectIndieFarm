using UnityEngine;
using QFramework;

namespace ProjectindieFarm
{
    public partial class ChallengeController : ViewController
    {
        public Font Font;
        private GUIStyle mLabelStyle;

        private void Start()
        {
            mLabelStyle = new GUIStyle("Label")
            {
                font = this.Font
            };

        }

        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(960, 360);
            GUI.Label(new Rect(960 - 300, 0, 300, 24), "@@ ÃÙ’Ω @@", mLabelStyle);

            for (var i = 0; i < Global.ActiveChallenges.Count; i++)
            {
                var challenge = Global.ActiveChallenges[i];
                GUI.Label(new Rect(960 - 300, 20 + i * 20, 300, 24), challenge.Name, mLabelStyle);
            }

            for (var i = 0; i < Global.FinishedChallenges.Count; i++)
            {
                var challenge = Global.FinishedChallenges[i];
                GUI.Label(new Rect(960 - 300, 20 + (i + Global.ActiveChallenges.Count) * 20, 300, 24), $"<color=green>°Ã {challenge.Name}</color>", mLabelStyle);
            }
        }
    }
}