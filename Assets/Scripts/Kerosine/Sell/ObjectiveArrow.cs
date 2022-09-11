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
                arrow.SetActive(true);

                Vector3 dir = closestBucket.transform.position - arrow.transform.position;
                Vector2 twodimDir = new Vector2(dir.x, dir.z);
                twodimDir.Normalize();
                float angle = Mathf.Atan2(twodimDir.y, twodimDir.x);

                Quaternion originRot = arrow.transform.rotation;
                arrow.transform.LookAt(closestBucket.transform.position);
                Quaternion lookRot = arrow.transform.rotation;


                if (closestBucket = null)
                {
                    arrow.SetActive(false);
                }
            }
        }
    }
}