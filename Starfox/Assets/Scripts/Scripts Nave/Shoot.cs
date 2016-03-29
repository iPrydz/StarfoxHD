using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public float speed;
    public float distance;
    private Vector3 startPos;
    private Renderer r;
    private Color color;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;

        // Render para cambiar color al disparo
        r = this.GetComponent<Renderer>();
        // Color cian + aplicamos
        color = new Color(0f, 1f, 1f, 1f);
        r.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        // Mueve los disparos hacia delante
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Cambia de color ciclico de cian a blanco
        color.r += Time.deltaTime * 2f;
        // Cuando llega a 1 vuelve a 0
        color.r %= 1f;
        r.material.color = color;
        // Destruye el disparo cuando supera distance
        if (Vector3.Distance(this.transform.position, startPos) > distance) {
            Destroy(this.gameObject);
        }

	}
}
