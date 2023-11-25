using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVClub.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Vector3 lastSavePoint;

        private void Start()
        {
            //Singleton.
            if (instance != null && instance != this)
                Destroy(this);
            else
                instance = this;
        }

        //Called from SavePoint.
        public void SetSavePoint(Player player, Vector3 savePoint)
        {
            player.ClearEffects();
            player.RestoreHealth();
            lastSavePoint = savePoint;

            Debug.Log("GAME SAVED!");
        }
    }
}
