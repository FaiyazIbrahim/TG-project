using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject canvas;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if(canvas == null)
        {
            GameObject go = Instantiate(Resources.Load("Canvas", typeof(GameObject))) as GameObject;
            canvas = go;
        }
    }




}
