using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MasterUI : MonoBehaviour
{

    public RectTransform menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        menu.transform.position = Vector2.MoveTowards(menu.transform.position, new Vector2(2f, 50f), 0.09f);

    }


    public void OpenOrCloseSlide(RectTransform menu)
    {
        StartCoroutine(MovePanel(4f, menu));
    }

    IEnumerator MovePanel(float waitTime, RectTransform menu)
    {
        yield return new WaitForSeconds(0);

    }
}
