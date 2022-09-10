using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        FindClosestBucket();
    }

    private void FindClosestBucket()
    {
        float distanceToClosestBucket = Mathf.Infinity;
        Bucket closestBucket = null;
        Bucket[] allBuckets = GameObject.FindObjectsOfType<Bucket>();

        foreach(Bucket currentBucket in allBuckets)
        {
            float distanceToBucket = (currentBucket.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToBucket < distanceToClosestBucket)
            {
                distanceToClosestBucket = distanceToBucket;
                closestBucket = currentBucket;

                

                if (closestBucket = null)
                {
                    arrow.SetActive(false);
                }
            }
        }
    }
}