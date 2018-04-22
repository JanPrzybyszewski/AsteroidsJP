using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeystroyByContact : MonoBehaviour {

    public GameObject Explosion;
    private Transform Transform;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    private GameController _gameController;
    
    void Start()
    {
        Transform = GetComponent<Transform>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            _gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (_gameController == null)
        {
            Debug.Log("cannot find");
        }
    }

    private void OnTriggerEnter(Collider other)
    {if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            _gameController.GameOver();
        }
        if (other.tag == "Bolt")
        {
            Instantiate(Explosion, other.transform.position, other.transform.rotation);
            _gameController.AddScore();
        }
        else
        Instantiate(Explosion, Transform.position, Transform.rotation);
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
