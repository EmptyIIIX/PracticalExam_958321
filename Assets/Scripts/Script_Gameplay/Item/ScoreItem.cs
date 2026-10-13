using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class ScoreItem : MonoBehaviour, IItem
    {
        [Header("Settings")]
        public int scoreValue = 10;
        public AudioClip collectSound;
        [Range(0f, 1f)] public float volume = 1f;

        public ItemType ItemType => ItemType.ScoreItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ScoreManager.Instance?.AddScore(scoreValue);

                if (collectSound != null)
                    AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
                    
                Destroy(gameObject);
            }
        }
    }
    
}
