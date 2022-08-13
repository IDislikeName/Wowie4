using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public int dir;
    public Vector3 forw;
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
    }
    public void Turn()
    {
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currentstate == State.Moving)
        {
            Debug.Log("bruh");
            if (other.CompareTag("Wall"))
            {
                Turn();
            }
        }
    }
}
