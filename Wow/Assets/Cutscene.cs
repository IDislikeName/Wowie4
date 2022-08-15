using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
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
            if (Mathf.Abs(entranceDoor.transform.rotation.eulerAngles.y - 270) <= 0.8f)
            {
                entranceDoor.transform.eulerAngles = new Vector3(entranceDoor.transform.rotation.eulerAngles.x, 270, entranceDoor.transform.rotation.eulerAngles.z);
                doorOpening = false;
            }
        }
        if (doorClosing)
        {
            entranceDoor.transform.Rotate(0, 30 * Time.deltaTime, 0);
            if (Mathf.Abs(entranceDoor.transform.rotation.eulerAngles.y-0) <= 0.8f)
            {
                entranceDoor.transform.eulerAngles = new Vector3(entranceDoor.transform.rotation.eulerAngles.x, 0, entranceDoor.transform.rotation.eulerAngles.z);
                doorClosing = false;
            }
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
        yield return new WaitUntil(() => !doorOpening);
        dogMoving = true;
        yield return new WaitForSeconds(3f);
        dogMoving = false;
        doorBox.SetActive(true);
        doorClosing = true;
        yield return new WaitUntil(() => !doorClosing);
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
