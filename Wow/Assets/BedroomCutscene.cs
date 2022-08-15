using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCutscene : MonoBehaviour
{
    public GameObject entranceDoor;
    public GameObject textBox;
    public GameObject objective;
    public bool doorOpening = false;
    public bool doorClosing = false;
    public GameObject dog;
    public bool dogMoving = false;
    public GameObject doorBox;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            StartCoroutine(Stuff());
        }
        if (doorOpening)
        {
            entranceDoor.transform.Rotate(0, -30 * Time.deltaTime, 0);
        }
        if (doorClosing)
        {
            entranceDoor.transform.Rotate(0, 30 * Time.deltaTime, 0);
        }
        if (dogMoving)
        {
            dog.GetComponent<POLYGON_DogAnimationController>().w_movement = 0.75f;
        }
    }
    IEnumerator Stuff()
    {
        started = true;
        doorOpening = true;
        yield return new WaitForSeconds(3f);
        doorOpening = false;
        dogMoving = true;
        yield return new WaitForSeconds(3f);
        dogMoving = false;
        doorBox.SetActive(true);
        doorClosing = true;
        yield return new WaitForSeconds(3f);
        doorClosing = false;
        textBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        textBox.GetComponent<TextBox>().Act(0);
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<TextBox>().Dis(0);
        yield return new WaitForSeconds(1f);
        textBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        textBox.GetComponent<TextBox>().Act(1);
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<TextBox>().Dis(1);
        yield return new WaitForSeconds(2f);
        objective.SetActive(true);
        dog.GetComponent<POLYGON_DogAnimationController>().gameStarted = true;
        yield return new WaitForSeconds(3f);
        objective.SetActive(false);
    }

}