using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ending());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("MenuScene");
    }
}
