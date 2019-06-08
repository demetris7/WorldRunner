using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string gameObject = "";
    public bool isQuit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp()
    {
        if (isQuit)
        {
            Application.Quit();
        }
        if(gameObject != "")
        {
            SceneManager.LoadScene(gameObject);
            MainScript.score = 0;
            MainScript.m_speed = -20f;
            MainScript.isGameOver = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
