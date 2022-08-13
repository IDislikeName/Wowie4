using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 movedir = new Vector3(horiz, 0, vert);
        movedir.Normalize();
        transform.Translate(movedir * speed * Time.deltaTime,Space.World);
        if (movedir != Vector3.zero)
        {
            transform.up = movedir;
        }
    }
}
