using UnityEngine;

public class Invader : MonoBehaviour {
    private protected InvadersManager manager;

    private void Start() {
        manager = GameObject.Find("Invaders").GetComponent<InvadersManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("PlayerShot")) {
            gameObject.SetActive(false);
            manager.KillInvader();
        }
    }
}