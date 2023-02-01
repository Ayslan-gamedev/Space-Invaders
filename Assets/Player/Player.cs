using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private protected float speed;
    private protected const double LIMIT_X = 8.5;


    [SerializeField] private GameObject shotPreFab;
    [SerializeField] private Transform shotTransform;

    public RaycastHit2D protectionRayCast;
    public bool a;

    [SerializeField] private Text playerPoints;
    private protected int currentPoints;

    private protected const string tag_enemyShot = "InvaderShot";

    [SerializeField] private GameObject[] lifeImage;
    [SerializeField] private Text player_life;
    private protected int lifeQuant = 3;

    void Update() {
        float newPosition = transform.position.x + speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if(newPosition > -LIMIT_X && newPosition < LIMIT_X) transform.position = new Vector2(newPosition, transform.position.y);

        if(Input.GetKeyDown(KeyCode.Return)) Instantiate(shotPreFab, transform.position, transform.rotation, shotTransform); ;

        protectionRayCast = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f, 1 << 7);
        Debug.DrawRay(transform.position + Vector3.up, Vector2.up, Color.blue, 0.5f);
        a = protectionRayCast.collider;
    }

    public void AddPoints(int points) {
        currentPoints += points;
        playerPoints.text = currentPoints.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(tag_enemyShot)) {
            lifeQuant--;
            player_life.text = lifeQuant.ToString();

            if(lifeQuant > 0) {
                lifeImage[lifeQuant - 1].SetActive(false);
            } else {
                Debug.Log("GAME OVER!!");
            }
        }
    }
}