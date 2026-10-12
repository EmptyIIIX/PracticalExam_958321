using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class ScoreItem : MonoBehaviour, IItem
    {
        [Header("Settings")]
        public int scoreValue = 10;

        public ItemType ItemType => ItemType.ScoreItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ScoreManager.Instance?.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }
    
}
