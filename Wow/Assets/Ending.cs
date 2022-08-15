using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public bool started;
    public int nextSceneNumber;
    public GameObject textbox;
    public GameObject doorBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Roomba") && !started)
        {
            started = true;
            StartCoroutine(Cutscene());
        }
        if (other.CompareTag("Player") && started)
        {
            SceneManager.LoadScene(nextSceneNumber);
        }
    }
    IEnumerator Cutscene()
    {
        textbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        textbox.GetComponent<TextBox>().Act(2);
        yield return new WaitForSeconds(3f);
        textbox.GetComponent<TextBox>().Dis(2);
        yield return new WaitForSeconds(1f);
        doorBox.SetActive(false);
    }
}

