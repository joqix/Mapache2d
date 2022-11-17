using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Este script controla el botón jugar
 * */
public class BotonJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/**
	 * Al pulsar se carga GameScene
	 **/
	void OnMouseDown(){
		Camera.main.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		Invoke ("CambiarDeEscena", GetComponent<AudioSource> ().clip.length);

	}
	void CambiarDeEscena(){
		Application.LoadLevel ("GameScene");
	}
}
