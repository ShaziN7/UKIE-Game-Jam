using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanObject : MonoBehaviour
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
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                _player.setIsHoldingItem(false);
                break;


            case "Plastic":

                if (_player != null)
                {
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                _player.setIsHoldingItem(false);
                break;


            case "Can":

                if (_player != null)
                {
                    _player.UpdateScore(10);
                }

                Destroy(this.gameObject);
                _player.setIsHoldingItem(false);
                break;


            case "Paper":

                if (_player != null)
                {
                    _player.UpdateScore(-5);
                }

                Destroy(this.gameObject);
                _player.setIsHoldingItem(false);
                break;


            default:
                Debug.LogError("Error in Switch Statement");
                break;
        }
    }
}
