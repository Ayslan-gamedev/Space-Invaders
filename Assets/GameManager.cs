using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private protected Text[] Scores; // 0 -> player 1 ; 1 -> player 2
    [SerializeField] private protected Text HiScore;

    private protected byte gameStart = 0;

    private protected const int NUM_MAINMENU = 1;
    private protected const int NUM_SPACE = 2;

    public byte playerMode;

    private protected int[] playerPoints = new int[1];

    private protected int HIPoints = 0;

    private protected byte currentPlayer = 0;

    [SerializeField] private GameObject downArea;

    [SerializeField] private GameObject[] lifeImage;
    [SerializeField] private Text player_life;
    private protected int lifeQuant = 3;

    [SerializeField] private GameObject gameOverText;

    private void Start() {
        downArea.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerTakeDamage() {
        lifeQuant--;
        player_life.text = lifeQuant.ToString();

        if(lifeQuant > 0) {
            lifeImage[lifeQuant - 1].SetActive(false);
        } else {
            gameOverText.SetActive(true);
            Debug.Log("GAME OVER!!");
        }
    }

    private void Update() {
        if(gameStart == 0 && Input.anyKeyDown) {
            gameStart = 1;
            SceneManager.LoadSceneAsync(NUM_MAINMENU);
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            PlayerWin();
        }
    }

    public void SetPlayerMode(byte playersQuant) {
        switch(playersQuant) {
            case 0:
                Scores[1].gameObject.SetActive(false);
                break;

            case 1:
                Scores[1].gameObject.SetActive(true);
                break;
        }
    }

    public void StartGame() {
        downArea.SetActive(true);
        lifeQuant = 3;
    }

    public void PlayerWin() {
        SceneManager.LoadSceneAsync(NUM_SPACE);
        SetHiScore();
    }

    public void AddPoints(int points) {
        playerPoints[currentPlayer] += points;
        Scores[currentPlayer].text = numeberToStringConvert(playerPoints[currentPlayer]);
    }

    private void SetHiScore() {
        HIPoints = 0;        
        for(int i = 0; i < playerPoints.Length; i++) {
            HIPoints += playerPoints[i];
        }

        HiScore.text= numeberToStringConvert(HIPoints);
    }

    string numeberToStringConvert(int number) {
        int index = 4 - number.ToString().Length;
        string FinalResult = string.Empty;

        if(index <= 0) {
            return number.ToString();
        } else {
            for(int i = 0; i < index; i++) {
                FinalResult += 0;
            }
            FinalResult += number;
            return FinalResult;
        }
    }
}