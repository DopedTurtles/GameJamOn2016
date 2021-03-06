﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CLevelController : MonoBehaviour {

    //Variables propias de LevelController
    private int idEstado;
    private int dificultad;
    private CGameController gameController;
    public string gameControllerTag = "GameController";
    //Variables para WavesController
    public float waveParam1;
    public float waveParam2;

    //Variables para EventsController
    public float eventParam1;
    public float eventParam2;

    //Variables para DecoradoController
    public float decoradoParam1;
    public float decoradoParam2;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag(gameControllerTag).GetComponent<CGameController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Funciones

    //Getter y Setter de idEstado
    int GetIdEstado() { return idEstado; }
    void SetIdEstado(int nuevoEstado) { idEstado = nuevoEstado; }

    /*
     * GameOver: Llamada al metodo que provoca la llamada al metodo PedirGameOver de GameController
     */
    public void PedirGameOver()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CCameraController>().siguiendo = false;
        GameObject.FindGameObjectWithTag("EventsController").GetComponent<EventsController>().spawning = false;

        gameController.GameOver();
    }

    
}
