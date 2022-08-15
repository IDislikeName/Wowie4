using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Lv1Ending : MonoBehaviour
{
    public bool started = false;
    public GameObject objective;
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
            SceneManager.LoadScene(2);
        }
    }
    IEnumerator Cutscene()
    {
        objective.SetActive(true);
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space)==true);
        objective.SetActive(false);
        textbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        textbox.GetComponent<TextBox>().Act(2);
        yield return new WaitForSeconds(3f);
        textbox.GetComponent<TextBox>().Dis(2);
        yield return new WaitForSeconds(1f);
        doorBox.SetActive(false);
    }
}
