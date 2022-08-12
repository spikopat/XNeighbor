using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    private void Start()
    {

        Application.targetFrameRate = 30;
    }

    //Called by button
    public void OnClickRestartGame()
    {
        SceneManager.LoadScene(0);
    }

}