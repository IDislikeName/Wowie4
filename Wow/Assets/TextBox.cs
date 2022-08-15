using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextBox : MonoBehaviour
{
    private Image im;
    public Sprite[] bubble;
    public GameObject[] text;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Activate(int i)
    {
        im.sprite = bubble[0];
        yield return new WaitForSeconds(0.1f);
        im.sprite = bubble[1];
        yield return new WaitForSeconds(0.1f);
        im.sprite = bubble[2];
        text[i].SetActive(true);
    }
    public IEnumerator Dissipate(int i)
    {
        im.sprite = bubble[2];
        yield return new WaitForSeconds(0.1f);
        im.sprite = bubble[1];
        yield return new WaitForSeconds(0.1f);
        im.sprite = bubble[0];
        yield return new WaitForSeconds(0.1f);
        text[i].SetActive(false);
        gameObject.SetActive(false);
    }
    public void Act(int i)
    {
        StartCoroutine(Activate(i));
    }
    public void Dis(int i)
    {
        StartCoroutine(Dissipate(i));
    }
}
