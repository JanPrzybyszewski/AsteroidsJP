using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float Tumble;
    private Rigidbody _rr;
   
    // Rotaring Asteroids with random angular velocity.
    void Start () {
        _rr = GetComponent<Rigidbody>();
        _rr.angularVelocity = Random.insideUnitSphere * Tumble;
    }
	
	void Update () {
		
	}
}
