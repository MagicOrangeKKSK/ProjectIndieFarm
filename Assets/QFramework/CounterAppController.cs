using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example
{
    public class CounterAppModel : AbstractModel
    {
        public int Count;
        protected override void OnInit()
        {
            Count = 0;
        }
    }


    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterModel(new CounterAppModel());
        }
    }

    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<CounterAppModel>().Count++;
            this.SendEvent<CountChangeEvent>();
        }
    }

    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<CounterAppModel>().Count--;
            this.SendEvent<CountChangeEvent>();
        }
    }

    public struct CountChangeEvent 
    {
    
    }


    public class CounterAppController : MonoBehaviour,IController
    {
        //View
        private Button mBtnAdd;
        private Button mBtnSub;
        private TextMeshProUGUI mCountText;

        //Model
        private CounterAppModel mModel;

        private void Start()
        {
            mModel = this.GetModel<CounterAppModel>();

            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();  
            mBtnSub = transform.Find("BtnSub").GetComponent<Button>();
            mCountText = transform.Find("CountText").GetComponent<TextMeshProUGUI>();

            mBtnAdd.onClick.AddListener(() =>
            {
                this.SendCommand<AddCountCommand>();
            });

            mBtnSub.onClick.AddListener(() =>
            {
                this.SendCommand<SubCountCommand>();
            });

            UpdateView();

            this.RegisterEvent<CountChangeEvent>(e =>
            {
                UpdateView();
            });
        }

        private void UpdateView()
        {
            mCountText.text = mModel.Count.ToString();
        }

       public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

        private void OnDestroy()
        {
            mModel = null;
        }

    }
}