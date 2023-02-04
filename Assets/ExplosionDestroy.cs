using UnityEngine;

public class ExplosionDestroy : MonoBehaviour {

    [SerializeField] private protected double timeToDestroy;
    private protected float timer = 0;

    void Update() {
        if(timer < timeToDestroy) {
            timer += Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
}