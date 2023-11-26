using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVClub.Bases
{
    public class BaseInteractable : MonoBehaviour
    {
        protected Player _player;

        private void OnTriggerEnter(Collider other) => OnEnter(other);

        private void OnTriggerExit(Collider other) => OnExit();

        public virtual void OnEnter(Collider other)
        {
            if(other.GetComponent<Player>())
                _player = other.GetComponent<Player>();
        }

        public virtual void OnExit()
        {
            if (_player)
                _player = default;
        }
    }
}
