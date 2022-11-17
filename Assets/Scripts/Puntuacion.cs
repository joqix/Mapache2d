using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Esta clase controla la puntuación y el marcador de puntos
 **/
public class Puntuacion : MonoBehaviour
{
	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	/**
	 * Al epezar actualiza el marcador (para ponerlo a 0)
	 * y se suscribe a la notificación IncrementarPuntos
	 **/
	void Start ()
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuere");
		ActualizarMarcador ();
        
	}
	void PersonajeMuere(Notification notificacion){
		if (puntuacion > EstadoJuego.estadoJuego.puntucionMaxima) {
			EstadoJuego.estadoJuego.puntucionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar ();
		} 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	/**
	 * Este método se llama al recibir la notificacion IncrementarPuntos
	 * Recibe de la notificacion un entero que son los puntos que debe incrementar
	 * Le suma esos puntos a la puntuacion y después, llama al método
	 * ActualizarMarcador
	 **/
	void IncrementarPuntos (Notification notificacion)
	{
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion += puntosAIncrementar;
		/**
		 * Para comprobar que funcione
		 **/
		//Debug.Log ("Puntos incrementados: " + puntosAIncrementar + ", TOTAL: " + puntuacion);
		ActualizarMarcador ();
	
	}

	/**
	 * Este método establece el texto del marcador en el juego (que es un texto 3D)
	 * y pone en el el valor de la puntuación como String
	**/
	void ActualizarMarcador ()
	{
		marcador.text = puntuacion.ToString ();
	}
}
