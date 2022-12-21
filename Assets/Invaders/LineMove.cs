using UnityEngine;

public class LineMove : MonoBehaviour {
    [SerializeField] private protected GameObject[] invaders;
    private float speed = 1f, speedDown = 0;
    private protected const double LIMIT_X = 6;

    int currentInvader = 0;
    byte direction = 1;
        byte changeDirection = 0;
    
    private void Start() {
        currentInvader = invaders.Length;
    }

    void Move() {

        for(int i = 0; i < invaders.Length; i++) {
            if(invaders[i] != null) {
                invaders[i].transform.position += Vector3.right * speed; 
                invaders[i].transform.position += Vector3.down * speedDown;

             //   if(invaders[i].transform.position.x > LIMIT_X || invaders[i].transform.position.x < -LIMIT_X) changeDirection = 1;
            }
        }
        speedDown = 0;

        //if(changeDirection == 1) {
        //    speed *= -1;
        //    speedDown = 1;
        //}
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.L)) NeewMove();
    }

    private protected void NeewMove() {
        do {
            if(direction == 1) {
                currentInvader--;
                if(currentInvader < 0) {
                    speedDown = 0;
                    currentInvader = invaders.Length - 1;
                    VerifyDirectionChange();
                }
            }
            else {
                currentInvader++;
                if(currentInvader > invaders.Length - 1) {
                    speedDown = 0;
                    currentInvader = 0;
                    VerifyDirectionChange();
                }
            }
        } while(invaders[currentInvader].activeSelf != true);

        invaders[currentInvader].transform.position += Vector3.right * speed;
        invaders[currentInvader].transform.position += Vector3.down * speedDown;

        if(invaders[currentInvader].transform.position.x > LIMIT_X || invaders[currentInvader].transform.position.x < -LIMIT_X) changeDirection = 1;

        void VerifyDirectionChange() {
            if(changeDirection == 1) {
                if(direction == 1) {
                    direction = 0;
                    currentInvader = 0;
                }
                else {
                    direction = 1;
                    currentInvader = invaders.Length - 1;
                }

                speed *= -1;
                changeDirection = 0;
                speedDown = 1;
            }
        }
    }
}