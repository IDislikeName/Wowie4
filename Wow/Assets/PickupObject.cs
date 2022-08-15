using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    
    // Start is called before the first frame update
    //public bool ispickup = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Small") || other.CompareTag("Big"))
        {
            //ispickup = true;
            GetComponentInParent<POLYGON_DogAnimationController>().pickUpObj = other.gameObject;
        }
        if (other.CompareTag("Scene1")){
             GetComponentInParent<POLYGON_DogAnimationController>().SceneNum = 1;
        }        
        if (other.CompareTag("Scene2")){
             GetComponentInParent<POLYGON_DogAnimationController>().SceneNum = 2;
        }
        if (other.CompareTag("Scene3")){
             GetComponentInParent<POLYGON_DogAnimationController>().SceneNum = 3;
        }
        if (other.CompareTag("Scene4")){
             GetComponentInParent<POLYGON_DogAnimationController>().SceneNum = 4;
        }
        if (other.CompareTag("Scene5")){
             GetComponentInParent<POLYGON_DogAnimationController>().SceneNum = 5;
        }

    }
}
