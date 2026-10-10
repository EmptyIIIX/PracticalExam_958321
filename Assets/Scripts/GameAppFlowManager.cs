using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Theerapat_Boongrom.Code672110100
{
    public class GameAppFlowManager : Singleton<GameAppFlowManager>
    {
        protected static bool IsSceneOptionsLoaded;
        protected static bool IsSceneStageSelectionLoaded;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void LoadOptionScene(string optionSceneName)
        {
            if (!IsSceneOptionsLoaded)
            {
                SceneManager.LoadScene(optionSceneName, LoadSceneMode.Additive);
                IsSceneOptionsLoaded = true;
            }
        }

        public void UnloadOptionScene(string optionSceneName)
        {
            if (IsSceneOptionsLoaded)
            {
                SceneManager.UnloadSceneAsync(optionSceneName);
                IsSceneOptionsLoaded = false;
            }
        }

        public void LoadStageSelectionScene(string stageSelectionSceneName)
        {
            if (!IsSceneStageSelectionLoaded)
            {
                SceneManager.LoadScene(stageSelectionSceneName, LoadSceneMode.Additive);
                IsSceneStageSelectionLoaded = true;
            }
        }

        public void UnloadStageSelectionScene(string stageSelectionSceneName)
        {
            if (IsSceneStageSelectionLoaded)
            {
                SceneManager.UnloadSceneAsync(stageSelectionSceneName);
                IsSceneStageSelectionLoaded = false;
            }
        }

        public void ExitGame()
        {
            Application.Quit();
            Debug.Log("OnExit");
        }

        #region Scene Load and Unload Events Handler
        private void Onable()
        {
            SceneManager.sceneUnloaded += SceneUnloadEventHandler;
            SceneManager.sceneLoaded += SceneLoadedEventHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloadEventHandler;
            SceneManager.sceneLoaded -= SceneLoadedEventHandler;
        }

        private void SceneUnloadEventHandler(Scene scene)
        {
            
        }

        private void SceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
            if (scene.name.CompareTo("SceneOptions") != 0)
            {
                IsSceneOptionsLoaded = false;
            }
        }
        #endregion
    }
    
}

