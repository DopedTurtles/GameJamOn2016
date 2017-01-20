using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

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
    public void RetryPulsado()
    {
        //Aqui fundido a negro
        gameController.Retry();
    }

    /*
     * QuitPulsado: Funcion llamada en el menu principal cuando se pulsa el boton Quit
     *   - Cierra el juego
     */
    public void ToMenuPulsado()
    {
        gameController.CargaNivel("MainMenu");
    }
}
