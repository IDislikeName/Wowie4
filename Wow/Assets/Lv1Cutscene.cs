using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Lv1Cutscene : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public GameObject dog;
    public GameObject door;
    public bool doorRotating;
    public bool started = false;
    public bool dogMoving = false;
    public GameObject textbox1;
    public Vector3 camPos;
    public GameObject objective;
    public GameObject doorBox;
    // Start is called before the first frame update
    void Start()
    {
        cam.Follow = null;
        cam.LookAt = null;
        doorBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorRotating)
        {
            door.transform.Rotate(0, -30 * Time.deltaTime, 0);
            if (Mathf.Abs(door.transform.rotation.eulerAngles.y -270) <= 0.8f)
            {
                door.transform.eulerAngles = new Vector3(door.transform.rotation.eulerAngles.x, 270, door.transform.rotation.eulerAngles.z);
                doorRotating = false;
            }
        }
        if (dogMoving)
        {
            dog.GetComponent<POLYGON_DogAnimationController>().w_movement = 0.75f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Roomba")&&!started)
        {
            started = true;
            StartCoroutine(Cutscene());
        }
    }
    IEnumerator Cutscene()
    {
        doorRotating = true;
        yield return new WaitUntil(() => !doorRotating);
        dogMoving = true;
        yield return new WaitForSeconds(1.3f);
        dogMoving = false;
        doorBox.SetActive(true);
        
        cam.Follow = dog.transform;
        cam.LookAt = dog.transform;
        cam.transform.position = camPos;
        textbox1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        textbox1.GetComponent<TextBox>().Act(0);
        yield return new WaitForSeconds(3f);
        textbox1.GetComponent<TextBox>().Dis(0);
        yield return new WaitForSeconds(1f);
        textbox1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        textbox1.GetComponent<TextBox>().Act(1);
        yield return new WaitForSeconds(2f);
        textbox1.GetComponent<TextBox>().Dis(1);
        yield return new WaitForSeconds(2f);
        objective.SetActive(true);
        yield return new WaitForSeconds(3f);
        objective.SetActive(false);
        dog.GetComponent<POLYGON_DogAnimationController>().gameStarted = true;
    }
}
