using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Managers;
using TMPro;

namespace AVClub.UI
{
    public class GameUIManager : MonoBehaviour
    {
        public GameObject gameScreen;
        public GameObject pauseScreen;

        public TMP_Text loreText;
        [HideInInspector] public Transform ltParent;

        private void Start()
        {
            ltParent = loreText.transform.parent;
            ltParent.gameObject.SetActive(false);
        }

        public void ToggleScreens(bool state)
        {
            gameScreen.SetActive(state);
            pauseScreen.SetActive(!state);
        }

        public void ReturnToTitle() => GameManager.instance.OnReturnToMenuPressed();

        public void ResumeGame() => GameManager.instance.OnResumeGamePressed();
    }
}