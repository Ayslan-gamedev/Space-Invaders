using UnityEngine;

public class DestroyProtection : MonoBehaviour {
    private protected const string TAG_ENEMY = "Invader";
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(TAG_ENEMY)) {
            Destroy(gameObject);
        }
    }
}