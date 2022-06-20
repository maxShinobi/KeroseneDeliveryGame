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

    [SerializeField] GameObject sellKeroseneButton;

    [SerializeField] Collider bucketCollider;

    bool sellButtonPressed;

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

    private void OnTriggerStay(Collider bucketCollider)
    {
        if (bucketCollider.gameObject.tag == "Bucket")
        {
            Bucket b = bucketCollider.GetComponentInParent<Bucket>();
            sellKeroseneButton.SetActive(true);

            if (sellButtonPressed && b.KerosineDecrease(depletionValue) > 0)
                {
                    DepleteTheKeroseneBar(depletionValue);
                    Bucket.instance.BuyKerosine();
                }
            }
        }

    private void OnTriggerExit(Collider bucketCollider)
    {
        sellKeroseneButton.SetActive(false);
    }

    public void SellingKerosene(bool selling)
    {
        if (selling)
        {
            sellButtonPressed = true;
        }
        else
        {
            sellButtonPressed = false;
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
