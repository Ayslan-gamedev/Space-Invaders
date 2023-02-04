using UnityEngine;

public class shotMove : MonoBehaviour {
    [SerializeField] private protected float speed;
    [SerializeField] private protected string tagToColision;

    private protected const string TAG_TRENCH = "Trench";
    private SpriteRenderer sprite;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(transform.position.y <= -10 || transform.position.y > 7) {
            Destroy(gameObject);
        }

        if(transform.position.y < -5) {
            sprite.color = Color.green;
        } else if(transform.position.y > 5) {
            sprite.color = Color.red;
        } else {
            sprite.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(!collision.CompareTag(tagToColision) && !collision.CompareTag(TAG_TRENCH)) {
            Destroy(gameObject);
        }
    }
}