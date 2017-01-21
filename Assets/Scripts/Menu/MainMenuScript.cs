using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    //Variables del propio Menu
    private CGameController gameController;
    public string gameControllerTag = "GameController";
    public string gameLevelTag = "Level1";

    private void Start()
    { 
        gameController = GameObject.FindGameObjectWithTag(gameControllerTag).GetComponent<CGameController>();
    }

    /*
     * StartPulsado: Funcion llamada en el menu principal cuando se pulsa el boton Start
     *   - Carga la escena que contiene el juego
     */
    public void StartPulsado()
    {
        //Aqui fundido a negro
        gameController.CargaNivel(gameLevelTag);
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
