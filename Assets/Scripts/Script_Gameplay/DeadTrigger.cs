using UnityEngine;
using UnityEngine.Events;

public class DeadTrigger : MonoBehaviour
{
    [Header("Teleport Settings")]
    [SerializeField] private Transform destination;
    [SerializeField] private string playerTag = "Player";

    [Header("Optional: Respawn Delay")]
    [SerializeField] private float respawnDelay = 0f;

    [Header("Optional: Death Effects")]
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private AudioClip deathSound;

    [Header("Events")]
    public UnityEvent onPlayerDeath;
    public UnityEvent onPlayerRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        var controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            if (respawnDelay > 0f)
                StartCoroutine(TeleportWithDelay(controller));
            else
                TeleportPlayer(controller);
        }
    }

    private void TeleportPlayer(CharacterController controller)
    {
        // Play death effects at current position
        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, controller.transform.position, Quaternion.identity);
        
        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, controller.transform.position);

        onPlayerDeath?.Invoke();

        // Disable controller to avoid physics conflicts
        controller.enabled = false;

        // Move the transform to destination
        controller.transform.position = destination.position;
        controller.transform.rotation = destination.rotation;

        // Re-enable controller (resets internal velocity)
        controller.enabled = true;

        onPlayerRespawn?.Invoke();
    }

    private System.Collections.IEnumerator TeleportWithDelay(CharacterController controller)
    {
        onPlayerDeath?.Invoke();

        // Play death effects
        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, controller.transform.position, Quaternion.identity);
        
        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, controller.transform.position);

        // Disable controller immediately
        controller.enabled = false;

        // Wait for delay
        yield return new WaitForSeconds(respawnDelay);

        // Teleport
        controller.transform.position = destination.position;
        controller.transform.rotation = destination.rotation;

        // Re-enable
        controller.enabled = true;

        onPlayerRespawn?.Invoke();
    }

    // Public method for manual triggering (e.g., from other scripts)
    public void TriggerDeath(CharacterController controller)
    {
        if (controller == null) return;
        
        if (respawnDelay > 0f)
            StartCoroutine(TeleportWithDelay(controller));
        else
            TeleportPlayer(controller);
    }

    // Editor helper to visualize the destination
    private void OnDrawGizmosSelected()
    {
        if (destination != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, destination.position);
            Gizmos.DrawWireSphere(destination.position, 0.5f);
        }
        
        // Draw trigger bounds
        var collider = GetComponent<Collider>();
        if (collider != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
            Gizmos.matrix = transform.localToWorldMatrix;
            if (collider is BoxCollider box)
                Gizmos.DrawCube(box.center, box.size);
            else if (collider is SphereCollider sphere)
                Gizmos.DrawSphere(sphere.center, sphere.radius);
            else if (collider is CapsuleCollider capsule)
            {
                // Approximate capsule with wire spheres + cylinder
                float halfHeight = capsule.height * 0.5f - capsule.radius;
                Vector3 offset = new Vector3(0, halfHeight, 0);
                Gizmos.DrawWireSphere(offset, capsule.radius);
                Gizmos.DrawWireSphere(-offset, capsule.radius);
            }
        }
    }
}
