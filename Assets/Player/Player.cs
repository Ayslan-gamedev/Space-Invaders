using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private protected float speed;
    private protected const double LIMIT_X = 7.25;

    [SerializeField] private GameObject shotPreFab;
    [SerializeField] private Transform shotTransform;

    void Update() {
        float newPosition = transform.position.x + speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if(newPosition > -LIMIT_X && newPosition < LIMIT_X) transform.position = new Vector2(newPosition, transform.position.y);

        if(Input.GetKeyDown(KeyCode.V)) Instantiate(shotPreFab, transform.position, transform.rotation, shotTransform); ;
    }
}