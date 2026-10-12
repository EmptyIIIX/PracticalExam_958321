using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Theerapat_Boongrom.Code672110100;

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
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();

        // Check win condition
        if (currentScore >= winScore)
        {
            GameAppFlowManager.Instance.LoadScene(missionCompleteScene);
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null) scoreText.text = $"Score: {currentScore}";
        else Debug.LogWarning("⚠️ Score Text not assigned!");
    }

    public int GetScore() => currentScore;
    public void ResetScore() { currentScore = 0; if (scoreText) scoreText.text = "Score: 0"; }
}
