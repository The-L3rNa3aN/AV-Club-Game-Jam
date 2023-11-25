using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Bases;

namespace AVClub
{
    public class TestEntity : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var _player = other.GetComponent<BaseEntity>();

            if (_player)
            {
                if (!_player.isBurning)
                    _player.isBurning = true;
                else
                    _player.ResetBurnTimer();
            }

            //_player.isCursed = true;
            //_player.markedForDeath = true;
            //_player.isSlowed = true;

            //_player.isBurning = true;
        }
    }
}
