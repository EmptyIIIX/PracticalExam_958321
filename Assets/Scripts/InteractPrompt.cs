using UnityEngine;
using System.Collections.Generic;

namespace Theerapat_Boongrom.Code672110100
{
    public class InteractPrompt : MonoBehaviour
    {
        public static InteractPrompt Instance { get; private set; }
 
        [SerializeField] private GameObject _promptObject;
 
        private readonly HashSet<Object> _sources = new();
 
        private void Awake()
        {
            Instance = this;
            Refresh();
        }
 
        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
 
        public static void Show(Object source)
        {
            if (Instance == null) return;
            Instance._sources.Add(source);
            Instance.Refresh();
        }
 
        public static void Hide(Object source)
        {
            if (Instance == null) return;
            Instance._sources.Remove(source);
            Instance.Refresh();
        }
 
        private void Refresh()
        {
            _sources.RemoveWhere(s => s == null); // sources that were destroyed
            if (_promptObject != null)
            {
                _promptObject.SetActive(_sources.Count > 0);
            }
        }
    }
    
}
