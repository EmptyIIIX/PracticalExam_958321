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

        public void LoadGameOverScene(string loadGameOverScene)
        {
            GameAppFlowManager.Instance.LoadGameOverScene(loadGameOverScene);
        }

        public void UnLoadGameOverScene(string loadGameOverScene)
        {
            GameAppFlowManager.Instance.UnLoadGameOverScene(loadGameOverScene);
        }

        public void LoadMissionCompleteScene(string loadMissionComplete)
        {
            GameAppFlowManager.Instance.LoadMissionComplete(loadMissionComplete);
        }

        public void UnLoadMissionCompleteScene(string loadMissionComplete)
        {
            GameAppFlowManager.Instance.UnLoadMissionComplete(loadMissionComplete);
        }
        
        public void ExitGame()
        {
            GameAppFlowManager.Instance.ExitGame();
        }
    }
    
}
