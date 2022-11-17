using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGameOver : MonoBehaviour {
	public GameObject camaraGameOver;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeMuere");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void PersonajeMuere(Notification notificacion){
		camaraGameOver.SetActive (true);
	}
}
