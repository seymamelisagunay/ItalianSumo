using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemPoint = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))  return;
       
        ItemGenerator.DestroyTransformObject(gameObject);
        ItemGenerator.GenerateTransformObject();
        PointManager.GetPoint(itemPoint, other.gameObject);
    }
}
