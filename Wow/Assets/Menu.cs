using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject esc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    public void Toggle()
    {
        esc.SetActive(!esc.activeSelf);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void M()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
