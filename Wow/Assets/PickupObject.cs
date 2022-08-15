using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObject : MonoBehaviour
{
    public GameObject canvas;
    
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
            SoundManager.instance.PlayClip(GetComponentInParent<POLYGON_DogAnimationController>().up);
        }
        if (other.CompareTag("Scene1")){

            SceneManager.LoadScene(1);
        }        
        if (other.CompareTag("Scene2")){
            SceneManager.LoadScene(2);
        }
        if (other.CompareTag("Scene3")){
            SceneManager.LoadScene(3);
        }
        if (other.CompareTag("Scene4")){
            SceneManager.LoadScene(4);
        }
        if (other.CompareTag("Scene5")){
            SceneManager.LoadScene(5);
        }
        if (other.CompareTag("Credit"))
        {
            //ispickup = true;
            GetComponentInParent<POLYGON_DogAnimationController>().pickUpObj = other.gameObject;
            canvas.GetComponent<ToogleNames>().EnableGO();
            SoundManager.instance.PlayClip(GetComponentInParent<POLYGON_DogAnimationController>().up);
        }

    }
}
