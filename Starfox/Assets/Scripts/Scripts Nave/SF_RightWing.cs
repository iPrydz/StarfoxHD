using UnityEngine;
using System.Collections;

public class SF_RightWing : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (player.RWLife <= 0f) {
            this.transform.parent = null;
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.left * 2f, ForceMode.Impulse);
            Collider c = this.GetComponent<Collider>();
            c.isTrigger = false;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
        
    }

    void OnTriggerStay (Collider other) {
        if (other.tag != "Player") {
            player.mainLife -= Time.deltaTime * 50f;
            player.RWLife -= Time.deltaTime * 50f;
        }
    }
}
