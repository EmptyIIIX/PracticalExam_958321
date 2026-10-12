using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Theerapat_Boongrom.Code672110100
{
    public class Timer : MonoBehaviour
    {
        [Header("UI Reference")]
        public Text timeText;

        [Header("Timer Settings")]
        [SerializeField] protected float m_TimerDuration = 30f;
        [SerializeField] protected bool m_AutoStart = true;
        [SerializeField] protected string m_GameOverSceneName = "GameOver";

        [Header("Events")]
        [SerializeField] protected UnityEvent m_TimerStartEvent = new();
        [SerializeField] protected UnityEvent m_TimerEndEvent = new();
        [SerializeField] protected UnityEvent<float> m_OnTimeChanged = new();

        protected bool _IsTimerStart = false;
        protected float _StartTimeStamp;
        protected float _EndTimeStamp;
        protected float _CurrentTime;
        [SerializeField] protected float _TimeRemaining;

        public static Timer Instance { get; private set; }
        public float TimeRemaining => _TimeRemaining;
        public float TotalDuration => m_TimerDuration;
        public bool IsRunning => _IsTimerStart;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (m_AutoStart)
            {
                StartTimer();
            }
        }

        private void Update()
        {
            if (!_IsTimerStart) return;

            _CurrentTime = Time.time - _StartTimeStamp;
            _TimeRemaining = Mathf.Max(0f, _EndTimeStamp - Time.time);
            m_OnTimeChanged?.Invoke(_TimeRemaining);

            if (timeText != null) timeText.text = $"Time Remain: {(int)TimeRemaining}s";
            else Debug.LogWarning("⚠️ Time Text not assigned!");

            if (Time.time >= _EndTimeStamp)
            {
                EndTimer();
            }
        }

        public virtual void StartTimer()
        {
            if (_IsTimerStart) return;

            _IsTimerStart = true;
            _StartTimeStamp = Time.time;
            _EndTimeStamp = Time.time + m_TimerDuration;
            _TimeRemaining = m_TimerDuration;

            m_TimerStartEvent.Invoke();
            m_OnTimeChanged?.Invoke(_TimeRemaining);
        }

        public virtual void EndTimer()
        {
            if (!_IsTimerStart) return;

            _IsTimerStart = false;
            _TimeRemaining = 0f;
            m_TimerEndEvent.Invoke();
            m_OnTimeChanged?.Invoke(0f);

            // Load Game Over scene
            LoadGameOverScene();
        }

        public void AddTime(float timeToAdd)
        {
            if (!_IsTimerStart) return;

            _EndTimeStamp += timeToAdd;
            _TimeRemaining = Mathf.Max(0f, _EndTimeStamp - Time.time);
            m_OnTimeChanged?.Invoke(_TimeRemaining);
        }

        public void SetTime(float newTime)
        {
            if (!_IsTimerStart) return;

            _EndTimeStamp = Time.time + newTime;
            _TimeRemaining = newTime;
            m_OnTimeChanged?.Invoke(_TimeRemaining);
        }

        public void PauseTimer()
        {
            if (!_IsTimerStart) return;
            _IsTimerStart = false;
        }

        public void ResumeTimer()
        {
            if (_IsTimerStart) return;
            _IsTimerStart = true;
            _StartTimeStamp = Time.time - _CurrentTime;
            _EndTimeStamp = Time.time + _TimeRemaining;
        }

        protected virtual void LoadGameOverScene()
        {
            // SceneManager.LoadScene(m_GameOverSceneName, LoadSceneMode.Single);
            GameAppFlowManager.Instance.LoadGameOverScene(m_GameOverSceneName);
        }

        public void SetGameOverSceneName(string sceneName)
        {
            m_GameOverSceneName = sceneName;
        }
    }
    
}
