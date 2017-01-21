using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CGameController : MonoBehaviour {

    //Variables de GameController [PERSISTENTES]
    private string ultimaEscenaCargada;
    public string mainMenuScene = "MainMenu";
    public string gameOverScene = "GameOverMenu";

    //Variables para LevelController
    private int dificultad;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        CargaNivel(mainMenuScene);
	}


    //Implementacion de funciones


    //Getters and Setters dificultad
    public void SetDificultad(int nuevaDificultad)
    {
        dificultad = nuevaDificultad;
    }

    public int GetDificultad()
    {
        return dificultad;
    }

    /*
     * CargaNivel: Carga una nueva escena del juego.
     *   idEscena: nombre o id de la escena a cargar.
    */

    public void CargaNivel(string idEscena)
    {
        ultimaEscenaCargada = idEscena;
        SceneManager.LoadScene(idEscena);
    }

    /*
     * Retry: Carga la escena desde la que se llamo a GameOver
    */
    public void Retry()
    {
        SceneManager.LoadScene(ultimaEscenaCargada);
    }

    /*
     * GameOver: Carga la escena asignada al GameOver
    */
    public void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }
}
