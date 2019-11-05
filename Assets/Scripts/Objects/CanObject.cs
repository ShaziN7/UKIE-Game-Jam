using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanObject : MonoBehaviour
{
    private Player _player = null; // Reference to player
    private bool _isCollected = false; // If object has been collected
    private Vector3 _direction; // Which direction to throw object
    [SerializeField]
    private float _speed = 20.0f; // Speed to throw object
    private bool _hasBeenThrown = false; // If object has been thrown
    [SerializeField]
    private float _timer = 0.0f; // Timer for object lying on floor
    private bool _atSpawn = false; // If object is still at spawn


    // Start is called before the first frame update
    void Start()
    {
        // Make sure player has been referenced
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        // Only check collision with bin if object has been thrown
            switch (other.tag)
            {
                // If collided with Glass Bin, decrease points
                case "Glass":

                    if (_player != null)
                    {
                        _player.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player.SetIsHoldingItem(false);
                    break;


                // If collided with Glass Plastic, decrease points
                case "Plastic":

                    if (_player != null)
                    {
                        _player.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player.SetIsHoldingItem(false);
                    break;


                // If collided with Can Bin, increase points
                case "Can":


                    if (_player != null)
                    {
                        _player.UpdateScore(10);
                    }

                    Destroy(this.gameObject);
                    _player.SetIsHoldingItem(false);
                    break;


                // If collided with Paper Bin, decrease points
                case "Paper":

                    if (_player != null)
                    {
                        _player.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player.SetIsHoldingItem(false);
                    break;


                default:
                    break;
            }
        }
    
}