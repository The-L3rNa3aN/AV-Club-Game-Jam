using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Managers;
using AVClub.Bases;

namespace AVClub
{
    public class SavePoint : BaseInteractable
    {
        public bool isTouching = false;
        public bool isUsed = false;                 //To prevent calling the SetSavePoint method a million times.
        //private Player _player;

        private void Update()
        {
            if(_player != null || _player != default)
            {
                if(isTouching && !isUsed && _player.isInteracting)
                {
                    GameManager.instance.SetSavePoint(_player, transform.position);
                    isUsed = true;
                }
            }
        }

        public override void OnEnter(Collider other)
        {
            if(other.GetComponent<Player>())
            {
                _player = other.GetComponent<Player>();
                isTouching = true;
            }
        }

        public override void OnExit()
        {
            if(_player)
            {
                _player = default;
                isTouching = false;
                isUsed = false;
            }
        }
    }
}
