using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassObject : MonoBehaviour
{
    private Player _player = null;


    // Start is called before the first frame update
    void Start()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Glass":

                if (_player != null)
                {
                    _player.UpdateScore(10);
                }

                Destroy(this.gameObject);
                break;


            case "Plastic":

                if (_player != null)
                {
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                break;


            case "Can":

                if (_player != null)
                {
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                break;


            case "Paper":

                if (_player != null)
                {
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                break;


            default:
                Debug.LogError("Error in Switch Statement");
                break;
        }
    }
}
