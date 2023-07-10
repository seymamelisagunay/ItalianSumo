using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KinamaticPush : MonoBehaviour
{
    public float speed;
    public bool useScaleAnimation = true;
    private Vector3 _direction;
    private bool _isTweenRun = true;

    // nesneye temas edeni firlatiyor
    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        // carptigi yonun tersine firlatiyor
        _direction = (col.contacts[0].point - col.transform.position).normalized;
        col.rigidbody.GetComponent<Rigidbody>().AddForce(-_direction * speed, ForceMode.Acceleration);

        if (useScaleAnimation)
        {
            if (_isTweenRun)
            {
                _isTweenRun = false;
                transform.DOShakeScale(0.5f, .5f).OnComplete(() => { _isTweenRun = true; });
            }
        }
    }
}
