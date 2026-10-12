using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class TimeItem : MonoBehaviour, IItem
    {
        [Header("Settings")]
        public float addTime = 3f;
        public ItemType ItemType => ItemType.TimeItem;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Timer.Instance?.AddTime(addTime);
                Destroy(gameObject);
            }
        }
    }
    
}
