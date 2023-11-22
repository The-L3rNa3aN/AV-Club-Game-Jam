using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVClub
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Start()
        {
            //Singleton.
            if (instance != null && instance != this)
                Destroy(this);
            else
                instance = this;
        }
    }
}
