using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody _rb;
    private Transform _tr;
    public float Speed = 15;
  
 
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _tr = GetComponent<Transform>();
     
        _rb.velocity = _tr.forward * Speed;
    }
}
