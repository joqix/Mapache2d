using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualiarValoresGameOver : MonoBehaviour {
	public TextMesh textoValorPuntuacion, textoValormaxima;
	public Puntuacion puntuacion;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable(){
		textoValorPuntuacion.text = puntuacion.puntuacion.ToString();
		textoValormaxima.text = EstadoJuego.estadoJuego.puntucionMaxima.ToString ();
	}
}
