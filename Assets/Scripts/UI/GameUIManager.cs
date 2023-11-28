using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Managers;

namespace AVClub.UI
{
    public class GameUIManager : MonoBehaviour
    {
        public GameObject gameScreen;
        public GameObject pauseScreen;

        public void ToggleScreens(bool state)
        {
            Debug.Log("TOGGLESCREENS");
            gameScreen.SetActive(state);
            pauseScreen.SetActive(!state);
        }

        public void ReturnToTitle() => GameManager.instance.OnReturnToMenuPressed();

        public void ResumeGame() => GameManager.instance.OnResumeGamePressed();
    }
}