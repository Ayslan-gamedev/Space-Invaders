using UnityEditor.TextCore.Text;
using UnityEngine;

public class Invader : MonoBehaviour {
    private protected const string INVADERS_MANAGER_GAMEOBJECT = "Invaders";
    private protected InvadersManager manager;
    [SerializeField] private protected int invaderPoints;

    private protected const string PLAYER_OBJECT = "Player";
    private protected Player player;
    private float playerDistance;

    byte shot = 0;

    [SerializeField] private protected GameObject[] shotPrefab;

    public RaycastHit2D ray;
    public byte canShot = 0;

    private protected float delayTime = 0.15f;
    private protected float timerToShot;

    private protected const string GAMEMANAGER_OBJECT = "GameManager";
    private protected GameManager gameManager;

    [SerializeField] private protected GameObject explosionPreFab;

    private void Start() {
        manager = GameObject.Find(INVADERS_MANAGER_GAMEOBJECT).GetComponent<InvadersManager>();
        player = GameObject.Find(PLAYER_OBJECT).GetComponent<Player>();

        gameManager = GameObject.Find(GAMEMANAGER_OBJECT).GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("PlayerShot")) {
            Instantiate(explosionPreFab, transform.position, transform.rotation);
            player.PauseTime(0);

            gameObject.SetActive(false);
            manager.KillInvader();
            gameManager.AddPoints(invaderPoints);
        }
    }

    private void Update() {
        ray = Physics2D.Raycast(transform.position + (Vector3.down * 0.5f), Vector3.down, 0.5f, 1 << 6);
        playerDistance = transform.position.x - player.transform.position.x;

        if(!ray && playerDistance < 0.4f && playerDistance > -0.4f && !player.protectionRayCast.collider) {
            canShot = 1;
            if(shot == 0 && timerToShot >= delayTime) {
                Shot();
                shot = 1;
            }
            else timerToShot += Time.deltaTime;
        }
        else {
            timerToShot = 0;
            canShot = 0;
            shot = 0;
        }
        Debug.DrawRay(transform.position + (Vector3.down * 0.5f), Vector3.down, Color.blue, 0.5f);
    }

    public void Shot() {
        Instantiate(shotPrefab[Random.Range(0, shotPrefab.Length)], transform.position, transform.rotation);
    }
}