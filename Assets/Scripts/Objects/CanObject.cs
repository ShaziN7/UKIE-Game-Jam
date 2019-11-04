using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanObject : MonoBehaviour
{
    private Player _player1 = null; // Reference to player 1
    private Player _player2 = null; // Reference to player 2


    // Start is called before the first frame update
    void Start()
    {
        // Make sure player has been referenced
        if (_player1 == null)
        {
            _player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        }

        if (_player2 == null)
        {
            _player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Only check collision with bin if object has been thrown
        if (GetComponent<Object>().HasObjectBeenThrown())
        {
            switch (other.tag)
            {
                // If collided with Glass Bin, decrease points
                case "Glass":

                    if (_player1 != null)
                    {
                        _player1.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player1.SetIsHoldingItem(false);
                    break;


                // If collided with Glass Plastic, decrease points
                case "Plastic":

                    if (_player1 != null)
                    {
                        _player1.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player1.SetIsHoldingItem(false);
                    break;


                // If collided with Can Bin, increase points
                case "Can":

                    if (_player1 != null)
                    {
                        _player1.UpdateScore(10);
                    }

                    Destroy(this.gameObject);
                    _player1.SetIsHoldingItem(false);
                    break;


                // If collided with Paper Bin, decrease points
                case "Paper":

                    if (_player1 != null)
                    {
                        _player1.UpdateScore(-5);
                    }

                    Destroy(this.gameObject);
                    _player1.SetIsHoldingItem(false);
                    break;


                default:
                    break;
            }
        }
    }
}