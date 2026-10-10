using UnityEngine;
using UnityEngine.Video;

namespace Theerapat_Boongrom.Code672110100
{
    public class GameAppFlowButtons : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            GameAppFlowManager.Instance.LoadScene(sceneName);
        }

        public void LoadOptionsScene(string optionSceneName)
        {
            GameAppFlowManager.Instance.LoadOptionScene(optionSceneName);
        }

        public void UnloadOptionsScene(string optionSceneName)
        {
            GameAppFlowManager.Instance.UnloadOptionScene(optionSceneName);
        }

        public void LoadStageSelectionScene(string stageSelectionSceneName)
        {
            GameAppFlowManager.Instance.LoadStageSelectionScene(stageSelectionSceneName);
        }

        public void UnloadStageSelectionScene(string stageSelectionSceneName)
        {
            GameAppFlowManager.Instance.UnloadStageSelectionScene(stageSelectionSceneName);
        }

        public void ExitGame()
        {
            GameAppFlowManager.Instance.ExitGame();
        }
    }
    
}
