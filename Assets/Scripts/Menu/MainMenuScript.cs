using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    //Variables del propio Menu
    private CGameController gameController;

    private void Start()
    { 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<CGameController>();
    }

    /*
     * StartPulsado: Funcion llamada en el menu principal cuando se pulsa el boton Start
     *   - Carga la escena que contiene el juego
     */
    public void StartPulsado()
    {
        //Aqui fundido a negro
        gameController.CargaNivel("Level1");
    }

    /*
     * QuitPulsado: Funcion llamada en el menu principal cuando se pulsa el boton Quit
     *   - Cierra el juego
     */
    public void QuitPulsado()
    {
        Application.Quit();
    }
}
