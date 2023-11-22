using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVClub
{
    public class SavePoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var _player = other.GetComponent<Player>();
        }
    }
}
