using UnityEngine;

public class ProtectionCollision : MonoBehaviour {
    [SerializeField] private Sprite[] freames;
    private SpriteRenderer currentRender;
    private protected int currentFreame = 0;

    private void Start() {
        currentRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        currentFreame++;
        if(currentFreame < freames.Length) currentRender.sprite = freames[currentFreame];
        else gameObject.SetActive(false);
    }
}