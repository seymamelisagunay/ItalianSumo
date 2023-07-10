using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private float _targetRotation;
    void Start()
    {
        
        // rastgele bir yon veriyor
        _targetRotation = Random.Range(0f, 1f) < 0.5f ? -1f : 1f;
    }

    private void Update()
    {
        // o yone dogru kendi cevresinde donduruyor
        transform.Rotate(Vector3.up * rotationSpeed * _targetRotation * Time.deltaTime);
    }
}
