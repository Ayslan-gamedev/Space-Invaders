using UnityEditor;
using UnityEngine;

public class LineMove : MonoBehaviour {
    [SerializeField] private protected GameObject[] invaders;
    [SerializeField] private protected Sprite[] freames;
    private protected float speed = 1f, speedDown = 0;
    private protected const double LIMIT_X = 6;

    private protected int currentInvader = 0;
    private protected byte direction = 1, changeDirection = 0, animationFreame = 1;
    
    private void Start() {
        switch(direction) {
            case 0: currentInvader = 0; break;
            case 1: currentInvader = invaders.Length; break;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.L)) Move();
    }

    private protected void Move() {
        do {
            switch(direction) {
                case 0: currentInvader++; break;
                case 1: currentInvader--; break;
            }

            if(currentInvader > invaders.Length - 1 && direction == 0 || currentInvader < 0 && direction == 1) {
                speedDown = 0;

                switch(direction) {
                    case 0: currentInvader = 0; break;
                    case 1: currentInvader = invaders.Length - 1;  break;
                }
                VerifyDirectionChange();
                if(animationFreame == 0) animationFreame = 1;
                else animationFreame = 0;
            }
        } while(invaders[currentInvader].activeSelf != true);

        invaders[currentInvader].GetComponent<SpriteRenderer>().sprite = freames[animationFreame];
        invaders[currentInvader].transform.position += Vector3.right * speed;
        invaders[currentInvader].transform.position += Vector3.down * speedDown;

        if(invaders[currentInvader].transform.position.x > LIMIT_X || invaders[currentInvader].transform.position.x < -LIMIT_X) changeDirection = 1;

        void VerifyDirectionChange() {
            if(changeDirection == 1) {
                switch(direction) {
                    case 0:
                        direction = 1;
                        currentInvader = invaders.Length - 1;
                        break;
                    case 1:
                        direction = 0;
                        currentInvader = 0;
                        break;
                }
                
                speed *= -1;
                speedDown = 1;
                changeDirection = 0;
            }
        }
    }
}