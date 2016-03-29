using UnityEngine;
using System.Collections;

public class ControlFondo : MonoBehaviour {

    private Vector3 startPos;
    private GameObject player;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        player = GameObject.Find("Arwing");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = startPos;

        pos.z = player.transform.position.z + 490f;
        this.transform.position = pos;
	}
}
