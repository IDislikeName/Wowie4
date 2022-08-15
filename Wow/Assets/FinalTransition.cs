using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTransition : MonoBehaviour
{
    public GameObject final;
    public AudioClip crash;
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
        yield return new WaitForSeconds(2f);
        SoundManager.instance.PlayClip(crash);
        yield return new WaitForSeconds(5f);
        final.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MenuScene");
    }
}
