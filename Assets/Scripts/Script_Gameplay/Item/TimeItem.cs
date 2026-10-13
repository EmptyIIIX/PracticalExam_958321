using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class TimeItem : MonoBehaviour, IItem
    {
        [Header("Settings")]
        public float addTime = 3f;
        public AudioClip collectSound;
        [Range(0f, 1f)] public float volume = 1f;
        public ItemType ItemType => ItemType.TimeItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Timer.Instance?.AddTime(addTime);

                if (collectSound != null)
                    AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);

                Destroy(gameObject);
            }
        }
    }
    
}
