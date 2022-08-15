using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    private void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
        }
    }
    public GameObject[] stains;
    public bool doorOpened;
    public GameObject exit;
    public bool doorOpening;
    public GameObject exitCol;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (!CheckStains()&&!doorOpened)
        {
            OpenDoor();   
        }
        if (doorOpening)
        {
            exit.transform.Rotate(0, -30 * Time.deltaTime, 0);
        }
    }
    public bool CheckStains()
    {
        bool flag = false;
        for (int i = 0; i < stains.Length; i++)
        {
            if (stains[i] != null)
            {
                flag = true;
            }
        }
        return flag;
    }
    public void OpenDoor()
    {
        
        doorOpened = true;
        exitCol.tag = "Untagged";
        StartCoroutine(DoorStuff());
    }
    IEnumerator DoorStuff()
    {
        doorOpening = true;
        yield return new WaitForSeconds(3f);
        doorOpening = false;
    }
}
