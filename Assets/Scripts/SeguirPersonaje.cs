using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Esta clase se usa para que la cámara siga al personaje
 **/
public class SeguirPersonaje : MonoBehaviour {

    public Transform personaje;
    public float separacion = 6f;
	
	// Update is called once per frame
	/**
	 * Una vez por fotograma
	 * Hace que la cámara siga al personaje
	 * La camara tendra la posicion x del personaje más una separación
	 * Las posiciones y & z se mantienen
	 **/
	void Update () {
        transform.position = new Vector3(personaje.position.x+separacion, transform.position.y, transform.position.z);
		
	}
}
