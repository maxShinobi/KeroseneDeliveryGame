using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ProgressBar.instance.FillTheBar(1f);
        }
    }
}