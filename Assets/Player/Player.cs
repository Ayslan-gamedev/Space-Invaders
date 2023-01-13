using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private protected float speed;
    private protected const double LIMIT_X = 8.5;

    [SerializeField] private GameObject shotPreFab;
    [SerializeField] private Transform shotTransform;

    public RaycastHit2D protectionRayCast;
    public bool a;

    void Update() {
        float newPosition = transform.position.x + speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if(newPosition > -LIMIT_X && newPosition < LIMIT_X) transform.position = new Vector2(newPosition, transform.position.y);

        if(Input.GetKeyDown(KeyCode.Return)) Instantiate(shotPreFab, transform.position, transform.rotation, shotTransform); ;

        protectionRayCast = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f, 1 << 7);
        Debug.DrawRay(transform.position + Vector3.up, Vector2.up, Color.blue, 0.5f);
        a = protectionRayCast.collider;
    }
}