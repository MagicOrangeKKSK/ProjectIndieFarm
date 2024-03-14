using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{

    public abstract class Challenge  
    {
        public enum States
        {
            NotStart,
            Started,
            Finished,
        }
        public States State = States.NotStart;

        public abstract string Name { get; }

        public abstract void OnStart();
        public abstract bool CheckFinish();
        public abstract void OnFinish();
    }
}