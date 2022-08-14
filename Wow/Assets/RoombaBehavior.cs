using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBehavior : MonoBehaviour
{
    public float speed;
    public float slowSpeed = 0.1f;
    public bool cleaning = false;
    Rigidbody rb;
    public float targetDeg;
    public float turnSpeed;
    public enum State
    {
        Moving,
        Turning,
    }
    public State currentstate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentstate == State.Moving)
        {
            if (cleaning)
            {
                transform.Translate(transform.forward * slowSpeed* Time.deltaTime, Space.World);
            }                
            else
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
        if (currentstate == State.Turning)
        {
            transform.Rotate(0, turnSpeed*Time.deltaTime, 0);
            if (Mathf.Abs(transform.rotation.eulerAngles.y - targetDeg) <= 0.2f)
            {
                transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, targetDeg, transform.rotation.eulerAngles.z);
                currentstate = State.Moving;
            }
        }
    }
    public void Turn(float degrees)
    {
        currentstate = State.Turning;
        targetDeg = transform.rotation.eulerAngles.y+degrees;
        targetDeg = Mathf.Round( targetDeg % 360);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentstate == State.Moving)
        {
            if (other.CompareTag("Wall")|| other.CompareTag("Big"))
            {
                Turn(90);
            }
            else if (other.CompareTag("Small")) {
                Turn(45);
            }
        }
    }
    public void Clean(GameObject trash)
    {
        StartCoroutine(Cleaner(trash));
    }
    IEnumerator Cleaner(GameObject trash)
    {
        cleaning = true;
        yield return new WaitForSeconds(0.2f);
        cleaning = false;
        yield return new WaitForSeconds(0.2f);
        cleaning = true;
        yield return new WaitForSeconds(0.2f);
        cleaning = false;
        yield return new WaitForSeconds(0.2f);
        cleaning = true;
        yield return new WaitForSeconds(0.2f);
        cleaning = false;
        Destroy(trash);
    }
}
