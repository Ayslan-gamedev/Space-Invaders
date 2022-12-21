using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private protected float speed;
    private protected const double LIMIT_X = 7.25;

    void Update() {
        float newPosition = transform.position.x + speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if(newPosition > -LIMIT_X && newPosition < LIMIT_X) transform.position = new Vector2(newPosition, transform.position.y);
    }
}