using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBehavior : MonoBehaviour
{
    public float speed;
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
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        }
        if (currentstate == State.Turning)
        {
            transform.Rotate(0, turnSpeed*Time.deltaTime, 0);
            if (Mathf.Abs(transform.rotation.eulerAngles.y - targetDeg) <= 0.2f)
            {
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
            if (other.CompareTag("Wall"))
            {
                Turn(90);
            }
        }
    }
}
