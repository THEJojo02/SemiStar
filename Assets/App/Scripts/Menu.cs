using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void VR ()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Theorie ()
    {
        SceneManager.LoadScene("Theorie", LoadSceneMode.Single);
    }

    public void Aufgaben ()
    {
        SceneManager.LoadScene("Multiple", LoadSceneMode.Single);
    }
    public void Aufgaben2()
    {
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Single);
    }
    public void Home()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

}
