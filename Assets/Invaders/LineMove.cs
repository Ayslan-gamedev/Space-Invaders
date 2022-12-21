using UnityEngine;

public class LineMove : MonoBehaviour {
    [SerializeField] private protected GameObject[] invaders;
    private float speed = 1f, speedDown = 0;
    private protected const double LIMIT_X = 6;

    void Move() {
        byte changeDirection = 0;

        for(int i = 0; i < invaders.Length; i++) {
            if(invaders[i] != null) {
                invaders[i].transform.position += Vector3.right * speed; 
                invaders[i].transform.position += Vector3.down * speedDown;

                if(invaders[i].transform.position.x > LIMIT_X || invaders[i].transform.position.x < -LIMIT_X) changeDirection = 1;
            }
        }
        speedDown = 0;

        if(changeDirection == 1) {
            speed *= -1;
            speedDown = 1;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.L)) Move();
    }
}