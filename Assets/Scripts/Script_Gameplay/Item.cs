using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Settings")]
    public int scoreValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance?.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
    // 3D ให้ใช้ OnTriggerEnter(Collider other) แทน
}
