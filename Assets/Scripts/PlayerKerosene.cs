using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKerosene : MonoBehaviour
{
    public static PlayerKerosene instance;

    public int maximumValue, minimumValue, currentValue, depletionValue;

    public int playerMoney;

    [SerializeField] Image mask;

    private void Awake()
    {
        instance = this;
        PlayerUIController.instance.playerMoneyText.text = playerMoney + "$";
    }

    void SetCurrentState()
    {
        float fillAmount = (float)currentValue / (float)maximumValue;
        mask.fillAmount = fillAmount;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bucket")
        {
            Bucket b = other.GetComponentInParent<Bucket>();

                if (Input.GetKey(KeyCode.E) && b.KerosineDecrease(depletionValue) > 0)
                {
                    DepleteTheKeroseneBar(depletionValue);
                    Bucket.instance.BuyKerosine();
                }
            }
        }

    public void FillTheKeroseneBar(int value)
    {
        if (currentValue < maximumValue)
        {
            currentValue += value;

        } else
        {
            Mathf.Clamp(currentValue, 0, 200);
        }

        SetCurrentState();
    }

    public void DepleteTheKeroseneBar(int value)
    {
            if (currentValue > minimumValue)
            {
                currentValue -= value;
            } else
            {
                Mathf.Clamp(currentValue, 0, 0);
            }

            SetCurrentState();
    }
    public void UpdatePlayerMoney()
    {
        PlayerUIController.instance.playerMoneyText.text = playerMoney + "$";
    }
}
