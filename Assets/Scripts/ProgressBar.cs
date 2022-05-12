using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;

    [SerializeField] float maximumValue, currentValue;
    [SerializeField] Image mask;
    [SerializeField] Canvas progressBarCanvas;

    [HideInInspector] public bool areaObserved;

    private void Awake()
    {
        instance = this;
        areaObserved = false;
    }

    public void GetCurrentFill()
    {
        float fillAmount = (float)currentValue / (float)maximumValue;
        mask.fillAmount = fillAmount;
    }

    public void FillTheBar(float value)
    {
        currentValue += value;

        if(currentValue > maximumValue)
        {
            currentValue = maximumValue;
        }

        if(currentValue == maximumValue)
        {
            progressBarCanvas.enabled = false;
            areaObserved = true;
        } else
        {
            areaObserved = false;
        }

        GetCurrentFill();
    }
}
