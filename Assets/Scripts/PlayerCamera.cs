using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVClub
{
    public class PlayerCamera : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        public float smooth = 0.125f;
        public static PlayerCamera instance;

        private void Start()
        {
            //Singleton
            if (instance != null && instance != this)
                Destroy(this);
            else
                instance = this;

            transform.LookAt(target);
        }

        private void LateUpdate()
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smooth);
            transform.position = smoothPos;
        }
    }
}
