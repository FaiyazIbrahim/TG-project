using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject canvas;
    public CanvasView canvasView;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject tempObject = GameObject.Find("Canvas(Clone)");
        Debug.Log("obj : " + tempObject);
        if (tempObject != null)
        {
            canvas = tempObject;
            canvasView = tempObject.GetComponent<CanvasView>();
        }
        else
        {
            GameObject go = Instantiate(Resources.Load("Canvas", typeof(GameObject))) as GameObject;
            canvas = go;
            canvasView = go.GetComponent<CanvasView>();
        }



     
    }




}
