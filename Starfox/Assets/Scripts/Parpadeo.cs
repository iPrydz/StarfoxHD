using UnityEngine;
using System.Collections;

public class Parpadeo : MonoBehaviour {

    // Temporizador para cambiar de color el reactor
    public Material reactor;
    private float time = 0;
    private bool reacAnim;

    // Use this for initialization
    void Start () {

        // Variables contador
        reacAnim = false;
        time = Time.timeSinceLevelLoad + 0.25f;

    }
	
	// Update is called once per frame
	void Update () {
        Reactor();
    }

    /* CAMBIO DE COLOR AL REACTOR */
    void Reactor() {
        // Contador
        if (Time.timeSinceLevelLoad > time) {

            if (reacAnim) {
                reactor.color = new Color(255f, 0f, 0f);
            } else {
                reactor.color = new Color(255f, 255f, 0f);
            }

            reacAnim = !reacAnim;
            time = Time.timeSinceLevelLoad + 0.10f;

        }
    }
}
