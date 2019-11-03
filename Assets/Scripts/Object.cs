using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject player = null;
    private bool _isCollected = false;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z + 1.0f);
       
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
            // add points to player's score
            
            Destroy(this.gameObject);
        }
    }
}
