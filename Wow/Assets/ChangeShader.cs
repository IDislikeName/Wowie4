using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader : MonoBehaviour
{
    public Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera.SetReplacementShader ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
