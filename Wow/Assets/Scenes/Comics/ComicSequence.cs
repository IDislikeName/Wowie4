using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicSequence : MonoBehaviour
{
    public List<Transform> LPositions;
    public List<Transform> LComics;

    int stage = -1;
    bool canLoad = false;

    private void Update()
    {
        if(stage == -1)
        {
            stage = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stage >= LPositions.Count) { } //SceneManager.LoadScene("");
            canLoad = false;
            StartCoroutine(LoadComic());
        }

        IEnumerator LoadComic()
        {
            float duration = Random.Range(0.2f,1f);
            print(duration);
            float timeCount = 0f;
            Vector3 origionalPos = LComics[stage].position;
            while ((LPositions[stage].position - LComics[stage].position).magnitude >= 0.1)
            {
                print(timeCount/duration);
                print("comic" + LComics[stage].position);
                print("slerp" + Vector3.Slerp(origionalPos, LPositions[stage].position, timeCount / duration));
                LComics[stage].position = Vector3.Slerp(origionalPos, LPositions[stage].position, timeCount / duration);
                timeCount += Time.deltaTime;
                yield return new WaitForSeconds(0);
            }
            stage += 1;
            canLoad = true;
        }
    }


}

