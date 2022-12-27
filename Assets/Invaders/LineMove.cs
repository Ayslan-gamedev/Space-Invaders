using UnityEngine;

public class LineMove : MonoBehaviour {
    [SerializeField] private protected GameObject[] invaders;
    [SerializeField] private protected Sprite[] freames;

    private protected float speed = 0.25f;
    private protected byte speedDown = 0;
    private protected const double LIMIT_X = 7.25;

    private protected int currentInvader = 0;
    private protected byte direction = 1, animationFreame = 1;
    public byte changeDirection = 0;

    public byte end = 0;
    public int invadersQuant;

    private void Awake() {
        invadersQuant = invaders.Length;
    }

    public void Start() {
        switch(direction) {
            case 0: currentInvader = 0; break;
            case 1: currentInvader = invaders.Length - 1; break;
        }
        changeDirection = 0;
    }

    public void ReloadDirection() {
        do {
            if(direction == 0) currentInvader++; else currentInvader--;
            if(currentInvader < 0 && direction == 1 || currentInvader > invaders.Length - 1 && direction == 0) {
                if(animationFreame == 0) animationFreame = 1; else animationFreame = 0;
                speedDown = 0;
                end = 1;
            }
        } while(end == 0 && invaders[currentInvader].activeSelf != true);
    }

    public void Move() {
        if(end != 1 && invaders[currentInvader].activeSelf == true) {
            invaders[currentInvader].GetComponent<SpriteRenderer>().sprite = freames[animationFreame];
            invaders[currentInvader].transform.position += Vector3.right * speed;
            invaders[currentInvader].transform.position += Vector3.down * speedDown;
            
            if(invaders[currentInvader].transform.position.x > LIMIT_X || invaders[currentInvader].transform.position.x < -LIMIT_X) changeDirection = 1;
        }
        ReloadDirection();
    }

    public void ChangeDirection() {
        if(direction == 0) direction = 1; else direction = 0;
        
        speed *= -1;
        speedDown = 1;
        Start();
    }
}