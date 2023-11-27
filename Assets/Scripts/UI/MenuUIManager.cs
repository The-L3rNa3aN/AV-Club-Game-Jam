using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Managers;

namespace AVClub.UI
{
    public class MenuUIManager : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject aboutScreen;

        public void PlayButton() => GameManager.instance.OnPlayButtonPressed();

        public void ExitButton() => GameManager.instance.OnExitButtonPressed();

        public void ToggleScreens(bool state)       //Used by the "About..." and "Return" buttons.
        {
            mainScreen.SetActive(state);
            aboutScreen.SetActive(!state);
        }
    }
}
