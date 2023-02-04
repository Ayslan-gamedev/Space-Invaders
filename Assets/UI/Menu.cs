using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField] private GameObject[] menus;
    [SerializeField] private Text[] playerOptions;

    private byte currentPlayerModeSettings = 0; // 0 -> 1 player; 1 -> 2 players
    private int currentMenu = 0;

    private protected const string GAME_MANAGER = "GameManager";
    private protected const int PLAYER_MENU_INDEX = 0;
    private protected const int SCENE_SPACE_INDEX = 2;

    private void Start() {
        for(int i = 0; i < menus.Length; i++) {
            menus[i].SetActive(false);
        }
        menus[currentMenu].SetActive(true);

        playerOptions[currentPlayerModeSettings].color = Color.green;
    }

    private void Update() {
        if(Input.GetAxisRaw("Vertical") != 0 && currentMenu == PLAYER_MENU_INDEX) {
            playerOptions[currentPlayerModeSettings].color = Color.white;
            if(Input.GetAxisRaw("Vertical") > 0) {
                currentPlayerModeSettings = 0;
            } else if(Input.GetAxisRaw("Vertical") < 0) {
                currentPlayerModeSettings = 1;
            }
            playerOptions[currentPlayerModeSettings].color = Color.green;
        }

        if(Input.GetKeyDown(KeyCode.Return)) {
            menus[currentMenu].SetActive(false);
            currentMenu++;

            if(currentMenu >= menus.Length) {
                SceneManager.LoadSceneAsync(SCENE_SPACE_INDEX);
                GameObject.Find(GAME_MANAGER).GetComponent<GameManager>().StartGame();
            } else {
                menus[currentMenu].SetActive(true);
            }

            if(currentMenu - 1 == PLAYER_MENU_INDEX) {
                GameObject.Find(GAME_MANAGER).GetComponent<GameManager>().playerMode = currentPlayerModeSettings;
            }
        }
    }
}