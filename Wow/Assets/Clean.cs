using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            GetComponentInParent<RoombaBehavior>().Clean(other.gameObject);
        }
    }
}
