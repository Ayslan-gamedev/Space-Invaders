using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private protected float speed;
    private protected const double LIMIT_X = 8.5;

    [SerializeField] private GameObject shotPreFab;
    [SerializeField] private Transform shotTransform;

    public RaycastHit2D protectionRayCast;
    public bool a;

    private protected const string tag_enemyShot = "InvaderShot";

    private protected const string GAME_MANAGER_OBJECT = "GameManager";
    private protected GameManager manager;

    private protected float timer = 0;

    private protected const double TIME_STOP_PLAYER = 3.5;
    private protected const double TIME_STOP_INVADER = 0.5;

    private protected double currentTimeStop;
    private const float acelerationConstant = 0.025f;

    [SerializeField] private protected SpriteRenderer playerSpriteRender;

    [SerializeField] private Sprite[] explosion;
    [SerializeField] private Sprite playerSprite;

    private double timeToChangeSprite = 0;
    private byte currentSprite, playerExplosion;

    private void Start() {
        manager = GameObject.Find(GAME_MANAGER_OBJECT).GetComponent<GameManager>();
        timer = ((float)currentTimeStop + 1);
    }

    private void Move() {
        float newPosition = transform.position.x + speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if(newPosition > -LIMIT_X && newPosition < LIMIT_X) {
            transform.position = new Vector2(newPosition, transform.position.y);
        }
    }
    
    private void Shot() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            Instantiate(shotPreFab, transform.position, transform.rotation, shotTransform); ;
        }
    }

    public void PauseTime(byte player) {
        timer = 0;
        Time.timeScale = 0;
        playerExplosion = player;

        switch(playerExplosion) {
            case 0: currentTimeStop = TIME_STOP_INVADER; break;
            case 1: currentTimeStop = TIME_STOP_PLAYER; break;
        }
    }

    private void Update() {
        if(timer < currentTimeStop) {
            timer += acelerationConstant;

            if(timer >= timeToChangeSprite && playerExplosion == 1) {
                playerSpriteRender.sprite = explosion[currentSprite];
                switch(currentSprite) {
                    case 0: currentSprite = 1; break;
                    case 1: currentSprite = 0; break;
                }
                timeToChangeSprite += 0.25;
            }
        } else if(timer >= currentTimeStop) {
            Time.timeScale = 1;
            timeToChangeSprite = 0;
            playerSpriteRender.sprite = playerSprite;

            Move();
            Shot();
        }

        protectionRayCast = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f, 1 << 7);
        Debug.DrawRay(transform.position + Vector3.up, Vector2.up, Color.blue, 0.5f);
        a = protectionRayCast.collider;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag(tag_enemyShot)) {
            PauseTime(1);
            manager.PlayerTakeDamage();
        }
    }
}