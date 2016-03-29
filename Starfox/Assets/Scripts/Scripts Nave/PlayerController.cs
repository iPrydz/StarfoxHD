using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector3 angle;
    public float playerSpeed;

    private int shootType;
    public GameObject singleShoot;
    public GameObject leftShoot;
    public GameObject rightShoot;

    private Camara rotCamara;

    private Rigidbody rb;

    private float timer;
    private float dist;

    private bool prueba;

    // Variables vida
    public float mainLife;
    public float LWLife;    // Left wing
    public float RWLife;    // Right wing




    // Use this for initialization
    void Start () {
        prueba = false;

        dist = this.transform.position.z;
        timer = Time.timeSinceLevelLoad + 1f;

        mainLife = 100f;
        LWLife = 50f;
        RWLife = 50f;

        rb = this.GetComponent<Rigidbody>();
        angle = Vector3.zero;
        rotCamara = Camera.main.GetComponent<Camara>();

        shootType = 1;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > timer) {
            Debug.Log(this.transform.position.z - dist);
            dist = this.transform.position.z;
            timer = Time.timeSinceLevelLoad + 1f;
        }

        if (Input.GetKeyDown(KeyCode.M)) {

            if (prueba) {
                shootType = 1;
            } else {
                shootType = 0;
            }

            prueba = !prueba;

        }

        Move();

    }

    /* FUNCIÓN MOVIMIENTO NAVE */
    void Move () {
        float roll = 0.0f, pitch = 0.0f, turn = 0.0f;
        rotCamara.roll = 0f;

        // Calcular el pitch (arriba-abajo)
        if (Input.GetKey(KeyCode.W)) {
            pitch = 20.0f;
        } else if (Input.GetKey(KeyCode.S)) {
            pitch = -20.0f;
        }

        // Calcular el turn (derecha-izquierda)
        if (Input.GetKey(KeyCode.A)) {
            turn = -75.0f;
            roll = 30.0f;
            rotCamara.roll = 5f;
        } else if (Input.GetKey(KeyCode.D)) {
            turn = 75.0f;
            roll = -30.0f;
            rotCamara.roll = -5f;
        }

        // Aplica el pitch con el Lerp para suavizar movimiento
        angle.x = Mathf.Lerp(angle.x, pitch, Time.smoothDeltaTime * 2.0f);

        // Aplica el turn con el Lerp para suavizar movimiento
        angle.y = Mathf.Lerp(angle.y, turn, Time.smoothDeltaTime * 2.0f);

        // Aplica el roll con el Lerp para suavizar movimiento
        angle.z = Mathf.Lerp(angle.z, roll, Time.smoothDeltaTime * 2.0f);

        this.transform.rotation = Quaternion.Euler(angle);

        //this.transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        rb.velocity = this.transform.forward * playerSpeed;

        

        if (Input.GetKeyDown(KeyCode.K)) {
            GameObject o = null;
            switch (shootType) {
                // Disparo único
                case 0:
                    o = Instantiate(singleShoot,
                                    this.transform.position + (this.transform.forward * 6f),
                                    this.transform.rotation) as GameObject;
                    break;
                // Disparo doble
                case 1:
                    o = Instantiate(leftShoot,
                                    this.transform.position + (this.transform.right * 1.5f) + 
                                    (this.transform.forward * 1f),
                                    this.transform.rotation) as GameObject;

                    o = Instantiate(rightShoot,
                                    this.transform.position + (-this.transform.right * 1.5f) + 
                                    (this.transform.forward * 1f),
                                    this.transform.rotation) as GameObject;
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

    }

}
