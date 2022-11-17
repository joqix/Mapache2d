using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Esta clase controla el comportamiento que tendra un item
 * cuando un objeto colisiona con el.
 **/
public class Item : MonoBehaviour
{
	public int puntosAIncrementar = 5;
	public AudioClip sonidoItem;
	bool incrementados = false;
	public float volumenSonidoItem=1f;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	/**
     * Este metodo salta al colisionar algo con el item
     * Si lo que ha colisionado tiene el tag Player incrementa cinco puntos 
     * y pone incrementadois a true para que si se vuelve a detectar la colision 
     * con el mismo item no sume mas puntos
     * Independiente mente del objeto que haya colisionado con el item este se destruye
     **/
	void OnTriggerEnter2D (Collider2D colider)
	{
		if (colider.gameObject.tag == "Player" && !incrementados) {
			AudioSource.PlayClipAtPoint (sonidoItem, Camera.main.transform.position, volumenSonidoItem);
			incrementados = true;
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncrementarPuntos", puntosAIncrementar);
		}
		Destroy (gameObject);
	}
}

