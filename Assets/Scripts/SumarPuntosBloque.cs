using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Esta clase controla que al pisar un bloque se sumen puntos
 **/
public class SumarPuntosBloque : MonoBehaviour
{
	private int puntosAIncrementar = 1;
	private bool haColisionadoConElJugador = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	/**
	 * Este metodo se usa para cuando un objeto colisiona con el bloque
	 * Si haColisionadoConElJugador es false, el objeto que ha colisionado tiene el ag player y no tiene el nombre cabeza ni cuerpo
	 * haColisionadoConElJugador se establece a true y se manda la notificación IncrementarPuntos con los puntos a incrementear
	 **/
	void OnCollisionEnter2D (Collision2D colision)
	{
		if ((haColisionadoConElJugador == false) && (colision.gameObject.tag == "Player") && (colision.contacts [0].collider.gameObject.name != "Cabeza") && (colision.contacts [0].collider.gameObject.name != "Cuerpo")) {
			haColisionadoConElJugador = true;
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncrementarPuntos", puntosAIncrementar);
		}
	}
}
