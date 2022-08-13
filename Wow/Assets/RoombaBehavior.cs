using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public float targetDeg;
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, targetDeg, 0), Time.deltaTime * 2f);
            if (Mathf.Abs(transform.rotation.eulerAngles.y - targetDeg) <= 0.1f)
            {
                currentstate = State.Moving;
            }
        }
        Debug.Log(transform.rotation.eulerAngles.y);
    }
    public void Turn(float degrees)
    {
        currentstate = State.Turning;
        targetDeg = transform.rotation.eulerAngles.y+degrees;
        targetDeg = targetDeg % 360;
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
