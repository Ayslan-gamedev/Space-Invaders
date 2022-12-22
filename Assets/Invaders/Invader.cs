using UnityEngine;

public class Invader : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("PlayerShot")) gameObject.SetActive(false);
    }
}