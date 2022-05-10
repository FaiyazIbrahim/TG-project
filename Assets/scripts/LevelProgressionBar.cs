using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionBar : MonoBehaviour
{

    public Transform endTransform;
    public Image progressImage;

    private Vector3 endLine;
    private float fullDistance;

    private void Start()
    {
        endLine = endTransform.position;
        fullDistance = GetDistance();
    }

    public float GetDistance()
    {
        return Vector3.Distance(transform.position, endLine);
    }

    public void FillUI(float value)
    {
        progressImage.fillAmount = value;
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance,0f, newDistance);

        FillUI(progressValue);



    }
}
