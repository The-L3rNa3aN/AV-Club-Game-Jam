using AVClub.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AVClub.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Vector3 lastSavePoint;
        public bool isGamePaused = false;

        [Header("In-Game UI variables")]
        public GameUIManager _gUi;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

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

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch(scene.name)
            {
                case "PlayScene":
                    _gUi = FindObjectOfType<GameUIManager>();
                    break;

                case "Menu":
                    break;
            }
        }

        public void TogglePauseState(bool state)
        {
            isGamePaused = state;
            Time.timeScale = isGamePaused ? 0f : 1f;
        }

        //MAIN MENU UI CALLBACKS
        public void OnPlayButtonPressed()
        {
            SceneManager.LoadScene(1);
        }

        public void OnExitButtonPressed()
        {
            Application.Quit();
        }

        //IN-GAME UI CALLBACKS
        public void OnReturnToMenuPressed()
        {
            SceneManager.LoadScene(0);
        }

        public void OnResumeGamePressed()
        {
            Debug.Log("ONRESUMEGAMEPRESSED");
            _gUi.ToggleScreens(true);
            TogglePauseState(false);
        }
    }
}
