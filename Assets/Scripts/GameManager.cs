using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
