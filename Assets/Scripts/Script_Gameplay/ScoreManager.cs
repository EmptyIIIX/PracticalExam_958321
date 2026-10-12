using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Theerapat_Boongrom.Code672110100;
using StarterAssets;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI Reference")]
    public Text scoreText;

    [Header("Win Settings")]
    public int winScore = 10000;
    public string missionCompleteScene = "MissionComplete";

    private int currentScore = 0;

    private void Awake()
    {
        // if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();

        // Check win condition
        if (currentScore >= winScore)
        {
            DisablePlayerAndUnlockCursor();
            GameAppFlowManager.Instance.LoadMissionComplete(missionCompleteScene);
        }
    }

    private void DisablePlayerAndUnlockCursor()
    {
        var controller = FindAnyObjectByType<ThirdPersonController>();
        var inputs = FindAnyObjectByType<StarterAssetsInputs>();

        if (controller != null) controller.CanMove = false;
        if (inputs != null) inputs.SetCursorLocked(false);
    }

    private void UpdateUI()
    {
        if (scoreText != null) scoreText.text = $"Score: {currentScore}";
        else Debug.LogWarning("⚠️ Score Text not assigned!");
    }

    public int GetScore() => currentScore;
    public void ResetScore() { currentScore = 0; if (scoreText) scoreText.text = "Score: 0"; }
}
