using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {
	public int puntucionMaxima=0;
	private String rutaArchivo;
	public static EstadoJuego estadoJuego;

	/**
	 * Awake es lo primero que se ejecuta
	 * Antes incluso que Start
	 **/
	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

	}
	// Use this for initialization
	void Start () {
		Cargar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream archivo = File.Create(rutaArchivo);
		DatosAGuardar datos=new DatosAGuardar(puntucionMaxima);
		bf.Serialize (archivo, datos);
		archivo.Close ();
	}
	public void Cargar(){
		if (File.Exists (rutaArchivo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream archivo = File.Open (rutaArchivo, FileMode.Open);
			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (archivo);
			puntucionMaxima = datos.puntuacionMaxima;
			archivo.Close ();
		}
	}
}
[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;
	public DatosAGuardar(int puntuacionMaxima){
		this.puntuacionMaxima = puntuacionMaxima;
	}
}
