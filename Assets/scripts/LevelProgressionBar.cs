using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionBar : MonoBehaviour
{

    public static LevelProgressionBar self;

    public Transform endTransform;
    public Image progressImage;

    private Vector3 endLine;
    private float fullDistance;

    private void Awake()
    {
        if(self == null)
        {
            self = this;
        }
    }

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
        if(progressImage != null)
        {
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

            FillUI(progressValue);
        }


    }
}
