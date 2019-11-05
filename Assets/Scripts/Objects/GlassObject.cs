using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassObject : MonoBehaviour
{
    private Player _player = null; // Reference to player


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
       
            switch (other.tag)
            {
                // If collided with Glass Bin, increase points
                case "Glass":

                    if (_player != null)
                    {
                        _player.UpdateScore(10);
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


                // If collided with Can Bin, decrease points
                case "Can":

                    if (_player != null)
                    {
                        _player.UpdateScore(-5);
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