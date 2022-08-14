using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    
    // Start is called before the first frame update
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
            GetComponentInParent<POLYGON_DogAnimationController>().pickUpObj = other.gameObject;
        }
    }
}
