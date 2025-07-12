using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
{
    // Cierra la aplicación
    Application.Quit();

    // Solo para pruebas en el editor de Unity (esto no afecta el build final)
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
}
}
