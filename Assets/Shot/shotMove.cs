using UnityEngine;

public class shotMove : MonoBehaviour {
    [SerializeField] private protected float speed;
    [SerializeField] private protected string tagToColision;

    private void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(transform.position.y <= -10 || transform.position.y > 7) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(tagToColision)) Destroy(gameObject);
    }
}