using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKerosene : MonoBehaviour
{
    public static PlayerKerosene instance;

    public int maximumValue, minimumValue, currentValue, depletionValue;

    [SerializeField] Image mask;

    [SerializeField] Collider bucketCollider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentValue = PlayerPrefs.GetInt("AmountOfKerosene", currentValue);
    }

    void SetCurrentState()
    {
        float fillAmount = (float)currentValue / (float)maximumValue;
        mask.fillAmount = fillAmount;

        currentValue = PlayerPrefs.GetInt("AmountOfKerosene", currentValue);
    }

    private void OnTriggerStay(Collider bucketCollider)
    {
        if (bucketCollider.gameObject.tag == "Bucket")
        {
            Bucket b = bucketCollider.GetComponentInParent<Bucket>();

            if (b.KerosineDecrease(depletionValue) > 0)
            {
                DepleteTheKeroseneBar(depletionValue);
                Bucket.instance.SellKerosine();
            }
        }
    }

    public void FillTheKeroseneBar(int value)
    {
        if (currentValue < maximumValue)
        {
            currentValue += value;

            PlayerPrefs.SetInt("AmountOfKerosene", currentValue);

        }
        else
        {
            Mathf.Clamp(currentValue, 0, maximumValue);
        }

        SetCurrentState();
    }

    public void DepleteTheKeroseneBar(int value)
    {
        if (currentValue > minimumValue)
        {
            currentValue -= value;

            PlayerPrefs.SetInt("AmountOfKerosene", currentValue);

        }
        else
        {
            Mathf.Clamp(currentValue, 0, 0);
        }

        SetCurrentState();
    }
}
