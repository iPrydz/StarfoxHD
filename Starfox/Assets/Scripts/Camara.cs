using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

    public GameObject target;

    // Variables para la cámara
    public float anguloV;
    public float anguloH;
    public float radio;
    public float roll;
    private float horizon;
    private Vector3 rot;

    // Use this for initialization
    void Start () {
        anguloV = 0.2f;
        anguloH = -1.57f;
        radio = 12.5f;
        roll = 0f;
        horizon = 0f;
	}
	
	// PARA QUE LA CÁMARA NO PEGUE TEMBLEQUE HAY QUE ACTUALIZAR EN LATEUPDATE
	void LateUpdate () {
        MoveCamera();
	}

    void MoveCamera() {
        /* POSICIONA LA CÁMARA ALEATORIAMENTE MIRANDO HACIA EL CENTRO */

        Vector3 pos = Vector3.zero;

        pos.y = Mathf.Sin(anguloV) * radio;
        float r2 = Mathf.Cos(anguloV) * radio;

        pos.x = Mathf.Cos(anguloH) * r2;
        pos.z = Mathf.Sin(anguloH) * r2;

        pos.x += target.transform.position.x;
        pos.y += target.transform.position.y;
        pos.z += target.transform.position.z;

        rot = this.transform.rotation.eulerAngles;

        float rs = 0f; // Rotation speed

        rs = (roll - horizon) * Time.deltaTime;
        horizon += rs;
        
        if (horizon < -5f) horizon = -5f;
        if (horizon > 5f) horizon= 5f;

        rot.z = horizon;

        this.transform.position = pos;

        //Debug.Log(rot);

        this.transform.LookAt(target.transform.position);
        this.transform.rotation = Quaternion.Euler(rot);

    }

}
