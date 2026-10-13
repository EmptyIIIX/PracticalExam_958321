using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class ScoreItem_Stage2 : MonoBehaviour, IItem
    {
        [Header("Settings")]
        public int scoreValue = 500;
        public AudioClip collectSound;
        [Range(0f, 1f)] public float volume = 1f;

        public ItemType ItemType => ItemType.ScoreItem_Stage2;

        public void Collect()
        {
            ScoreManager.Instance?.AddScore(scoreValue);

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);

            Destroy(gameObject);
        }
    }
    
}
