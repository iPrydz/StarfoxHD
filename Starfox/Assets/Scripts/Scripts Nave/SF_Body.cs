using UnityEngine;
using System.Collections;

public class SF_Body : MonoBehaviour {

    private PlayerController player;

    // Use this for initialization
    void Start() {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

        //Debug.Log(player.LWLife + "  " + player.mainLife + "  " + player.RWLife);

    }

    void OnTriggerStay(Collider other) {
        if (other.tag != "Player") {
            player.mainLife -= Time.deltaTime * 50f;
        }
    }
}
