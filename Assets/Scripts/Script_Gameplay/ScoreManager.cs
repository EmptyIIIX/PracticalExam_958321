using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI Reference")]
    public Text scoreText;

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
        if (scoreText != null) scoreText.text = $"Score: {currentScore}";
        else Debug.LogWarning("⚠️ Score Text not assigned!");
    }

    public int GetScore() => currentScore;
    public void ResetScore() { currentScore = 0; if (scoreText) scoreText.text = "Score: 0"; }
}
