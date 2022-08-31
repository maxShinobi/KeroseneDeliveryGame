using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;

    private void Start()
    {
        image.enabled = false;
    }

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

                image.enabled = true;
                transform.LookAt(new Vector3(closestBucket.transform.position.x, closestBucket.transform.position.y, closestBucket.transform.position.z));

                if(closestBucket = null)
                {
                    image.enabled = false;
                }
            }
        }
    }
}