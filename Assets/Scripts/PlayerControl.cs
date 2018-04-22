using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float XMin, XMax, ZMin, ZMax;

}
public class PlayerControl : MonoBehaviour {
    private Rigidbody _rb;
    private Transform _tr;
    private AudioSource _audioSource;

    // Shooting.
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    public float NextFire;
    public float Speed;
    public float SpeedOffset;
    
    // Rotation
   
    private float MouseX;
    private float MouseY;
    private float Degree;
   
    private Vector3 Rotation;

    // Velocity and drift.
    Vector3 Movement1;
    Vector3 Movement2;
    Vector3 Tmp;

    public Boundary Boundary;
   
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _tr = GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        NextFire = Time.time + FireRate;
    }
	

	void Update () {

        // Shooting with the mouse.
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            
            NextFire = Time.time + FireRate;
           Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            _audioSource.Play();
        }
       
        // Mouse position used for rotation.
        MouseX = Input.mousePosition.x - 512 - _tr.position.x * 22.260869f;
        MouseY = Input.mousePosition.y - 384 - _tr.position.z * 22.588235f;
        Degree = Mathf.Atan(MouseX/MouseY);
        Degree = Degree * 180 / Mathf.PI;


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        // Movement using a key.
        Speed = 0;
        if (Input.GetKey(KeyCode.W))
        {
            Tmp = Movement2;
            Movement1 = transform.forward;
            Speed = 7;
           Movement2 = Movement1;
        }

        _rb.velocity = Tmp * SpeedOffset + Movement1 * Speed;




        // Boundary preventing player from going off the screen.
        _rb.position = new Vector3
            (
            Mathf.Clamp(_rb.position.x, Boundary.XMin, Boundary.XMax),
            0.0f,
            Mathf.Clamp(_rb.position.z, Boundary.ZMin, Boundary.ZMax)
            );


        // Rotation.
        if (MouseX < 0 && MouseY < 0)
            Degree = 180 + Degree;
       
        else if (MouseX > 0 && MouseY < 0)
           Degree = 180 +  Degree;

        _rb.rotation = Quaternion.Euler(0.0f, Degree, 0.0f);
        

    }
}
