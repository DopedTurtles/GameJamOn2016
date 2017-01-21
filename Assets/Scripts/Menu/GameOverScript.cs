using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    //Variables del propio Menu
    private CGameController gameController;
    public string gameControllerTag= "GameController";
    public string mainMenuTag = "MainMenu";

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag(gameControllerTag).GetComponent<CGameController>();
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
        gameController.CargaNivel(mainMenuTag);
    }
}
