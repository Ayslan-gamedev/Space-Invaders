using UnityEngine;

public class DestroyProtection : MonoBehaviour {
    private protected const string TAG_ENEMY = "Invader";

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("a");
        if(collision.CompareTag(TAG_ENEMY)) {
            Debug.Log(TAG_ENEMY);
            Destroy(gameObject);
        }
    }
}