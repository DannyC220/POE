using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sense : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checklayers;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checklayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        foreach (Collider item  in colliders)
        {
            Debug.Log(item.name);
            if(item.gameObject.tag != this.tag)
            {
                transform.LookAt(transform.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
	
}
