using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *Esta clase se usa para destruir los objetos y que nuestro juego no consuma demasiada memoria
 **/
public class Destructor : MonoBehaviour
{
	GameObject personaje;
	// Use this for initialization
	/**
	 * Al empezar el juego asignamos al personaje el game object que le corresponde
	 **/
	void Start ()
	{
		personaje = GameObject.Find ("Personaje");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	/**
	 * Al chocar un elemento con el destructor.
	 * 
	 * *Si es el jugador lanza la notificacion de personaje a muerto y deja el personaje inactivo
	 * *Si es otro objeto lo destruye
	 **/
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "PersonajeMuere");
			GetComponent<AudioSource> ().Play ();
			personaje.SetActive (false);
			//gameOver
		} else {
			Destroy (collision.gameObject);
		}
        
	}
}
