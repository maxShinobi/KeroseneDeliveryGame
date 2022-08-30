using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressArea : MonoBehaviour
{
    GameObject activeCar;

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activeCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ProgressBar.instance.FillTheBar(1f);
        }
    }
}