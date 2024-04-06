using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectindieFarm
{

    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private void LateUpdate()
        {
            Vector3 pos = transform.Position();
            pos.x = target.PositionX();
            pos.y = target.PositionY();
            transform.Position(pos);
        }

    }
}