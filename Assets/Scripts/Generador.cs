using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Esta clase se usa para generar objetos dado un array de objetos entre un tiempo maximo y un minimo
 **/
public class Generador : MonoBehaviour
{
	public GameObject[] obj;
	public float tiempoMin = 1.5f;
	public float tiempoMax = 2.5f;
	bool generarMas = true;
	// Use this for initialization
	/**
	 * Al empezar el juego suscribimos las notificaciones de PersonajeEmpiezaACorrer y PersonajeMuere
	 **/
	void Start ()
	{
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuere");
	}

	/**
	 * Este metodo se ejecutará al recibir la notificación de PersonajeEmpiezaACorrer
	 * Llama al metodo generar para que se empiecen a generar los objetos
	 **/
	void PersonajeEmpiezaACorrer (Notification notificacion)
	{
		Generar ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	/**
	 * Este metodo comprueba si generarMas es positivo y en ese caso elige una posicion 
	 * aleatoria del array y genera ese objeto en la posicion que esta el generador
	 * después se invoca a si mismo en un tirmpo aleatorio entre el máximo y el mínimo
	 **/
	void Generar ()
	{
		if (generarMas) {
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
		}
	}

	/**
	 * Este metodo se ejcuta al recibir la notificacion PersonajeMuere
	 * Pone generarMas a false para que no se generen más objetos
	 **/
	void PersonajeMuere ()
	{
		generarMas = false;
	}
}
