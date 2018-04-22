using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverup : MonoBehaviour
{
    private Rigidbody _rb;
    public int SpeedIndex;

  
    void Start()
    {
        Vector3 speed = new Vector3(Random.Range(-2, 2), 0, Random.Range(2,5));
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = speed * SpeedIndex;
    }
}
