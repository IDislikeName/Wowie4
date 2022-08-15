using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleNames : MonoBehaviour
{
 public GameObject[] objs;
 
 
 void Start()
 {
     //objs = GameObject.FindGameObjectsWithTag("Names"); // this will look for all gameobjects and add them in the objs array
 }
 
 //Use this to disable all gameobjects with your tag
 public void DisableGO()
 {
     foreach(GameObject obj in objs)
     {
         if(obj.CompareTag("Names"))
         {
             obj.SetActive(false);
         }
     }
 }
 
 //use this to enable all gameobjects with your tag
 public void EnableGO()
 {
    Debug.Log("gg");
     foreach(GameObject obj in objs)
     {
         if(obj.CompareTag("Names"))
         {
             obj.SetActive(true);
         }
     }
 }
}
