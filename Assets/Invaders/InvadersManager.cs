using UnityEngine;

public class InvadersManager : MonoBehaviour {
    [SerializeField] private protected LineMove[] lines;

    private protected int currentLine;
    private byte changeDirection = 0;

    [SerializeField] private protected float timeLoop;
    private protected float timer = 0;

    [SerializeField] private protected int invadersQuant = 0;

    private protected const string GAME_MANAGER_OBJECT = "GameManager";
    private GameManager gameManager;

    private void Start() {
        for(int i = 0; i < lines.Length; i++) invadersQuant += lines[i].invadersQuant;
        currentLine = lines.Length - 1;

        gameManager = GameObject.Find(GAME_MANAGER_OBJECT).GetComponent<GameManager>();
    }

    private void Update() {
        if(timer < timeLoop) timer += Time.deltaTime;
        else {
            Movement();
            timer= 0;
        }
    }

    private void Movement() {
        if(lines[currentLine].end == 1){
            int oldLine = currentLine;
           
            if(lines[currentLine].changeDirection == 1) changeDirection = 1;

            switch(currentLine) {
                case 0:
                    if(changeDirection == 1) {
                        for(int i = 0; i < lines.Length; i++) {
                            lines[i].changeDirection = 0;
                            lines[i].ChangeDirection();
                        }
                    }
                    else for(int i = 0; i < lines.Length; i++) lines[i].Start();
                    changeDirection = 0;
                    currentLine = lines.Length - 1;
                    break;

                default: currentLine--; break;
            }

            lines[oldLine].end = 0;
            Movement();
        }
        else lines[currentLine].Move();
    }

    public void KillInvader() {
        invadersQuant--;
        if(invadersQuant <= 5) {
            timeLoop = 0;
        }
        if(invadersQuant == 0) {
            gameManager.PlayerWin();
        }
    }
}