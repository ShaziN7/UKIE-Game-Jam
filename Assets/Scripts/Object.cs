using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Player _player = null;
    private bool _isCollected = false;


    // Start is called before the first frame update
    void Start()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + 1.0f, _player.transform.position.z + 1.0f);
       
        if (_isCollected)
        {
            transform.position = playerPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isCollected = true;
        }

        else if (other.tag == "Bin")
        {
            // If player is alive, add to score
            if (_player != null)
            {
                _player.UpdateScore(10);
            }

            Destroy(this.gameObject);
        }
    }
}
