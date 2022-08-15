using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicSequence : MonoBehaviour
{
    public List<Transform> LPositions;
    public List<Transform> LComics;
    public List<float> LSize;
    public Transform camFirstTran;
    public float camFirstSize;

    int stage = -1;
    float delayTime = 1;
    bool canLoad = false;
    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if(stage == -1)
        {
            StartCoroutine(SetCamera());
            stage = 0;
        }

        if (canLoad && Input.GetKeyDown(KeyCode.Space))
        {
            if (stage >= LPositions.Count)
            { SceneManager.LoadScene("MenuScene");} 
                canLoad = false;
            StartCoroutine(LoadComic());
            StartCoroutine(SetCamera());

        }

        IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(1);
            canLoad = true;
        }

        IEnumerator LoadComic()
        {
            float duration = Random.Range(0.3f,0.8f);
            float timeCount = 0f;
            Vector3 origionalPos = LComics[stage].position;
            while ((LPositions[stage].position - LComics[stage].position).magnitude >= 0.1)
            {
                LComics[stage].position = Vector3.Slerp(origionalPos, LPositions[stage].position, timeCount / duration);
                timeCount += Time.deltaTime;
                yield return new WaitForSeconds(0);
            }
            stage += 1;
            StartCoroutine(StartDelay());
        }

        IEnumerator SetCamera()
        {
            float duration = Random.Range(0.3f, 0.6f);
            float timeCount = 0f;
            Vector3 origionalPos = transform.position;
            Vector3 targetPos;
            float orgSize = cam.orthographicSize;
            float tarSize;
            if (stage == -1) { tarSize = camFirstSize; }
            else { tarSize = LSize[stage]; }

            if(stage == -1) { targetPos = camFirstTran.position;}
            else {targetPos = new Vector3(LPositions[stage].position.x, LPositions[stage].position.y, origionalPos.z); }
            
            while ((transform.position - targetPos).magnitude >= 0.1)
            {
                transform.position = Vector3.Slerp(origionalPos, targetPos, timeCount / duration);
                cam.orthographicSize = orgSize + (tarSize-orgSize) * (timeCount / duration);
                timeCount += Time.deltaTime;
                yield return new WaitForSeconds(0);
            }

            if(stage ==0)canLoad = true;
        }

    }


}

