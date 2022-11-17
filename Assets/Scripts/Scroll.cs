using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Esta clase se usa para establecer el movimiento del offset de una textura en el juego
 **/
public class Scroll : MonoBehaviour
{
	public float velocidad = 0f;
	float tiempoInicio = 0f;
	bool corriendo = false;
	public bool comenzarMovimiento = false;
	// Use this for initialization
	/**
	 * Al iniciar se suscribe a las notificaciones PersonajeEmpiezaACorrer y PersonajeMuere
	 **/
	void Start ()
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuere");
	}

	/**
	 * Cuando se recibe la notificacion de PersonajeEmpiezaACorrer
	 * se establece corriendo a true y se guarda el tiempo en el que 
	 * se recibe la notificacion como tiempoInicio
	 **/
	void PersonajeEmpiezaACorrer ()
	{
		corriendo = true;
		tiempoInicio = Time.time;
	}

	/**
	 * Cuando se recibe la notificación PersonajeMuere
	 * se establece corriendo a false
	 **/
	void PersonajeMuere ()
	{
		corriendo = false;
	}
	// Update is called once per frame
	/**
	 * Una vez por fotograma
	 * Si el personaje esta corriendo o comenzarMovimiento es true, se actualiza el offset en x de un componente Renderer
	 * el offset se desplaza el modulo de 1 de el tiempo actual menos el inicial multiplicado por la velocidad
	 **/
	void Update ()
	{
		if (corriendo || comenzarMovimiento) {
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
}
