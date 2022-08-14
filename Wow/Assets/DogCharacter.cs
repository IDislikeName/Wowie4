using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCharacter : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 movedir = new Vector3(horiz, 0, vert);
        characterController.Move(movedir * Time.deltaTime * speed);
    }
}
