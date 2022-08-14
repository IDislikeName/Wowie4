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
    // Start is called before the first frame update
    void Start()
    {
        cam.Follow = null;
        cam.LookAt = null;
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
        yield return new WaitForSeconds(2f);
        dogMoving = false;
        cam.Follow = dog.transform;
        cam.LookAt = dog.transform;
    }
}
