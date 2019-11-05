using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassObject : Object
{
    // Changed above to Object from MonoBehaviour, do i need these?

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
                // If collided with Glass Bin, increase points
                case "Glass":

                    if (GetPlayerNumber() == 1)
                    {
                        _player1.UpdateScore(10, _player1.GetPlayerNumber());
                        _player1.SetIsHoldingItem(false);
                    }

                    else if (GetPlayerNumber() == 2)
                    {
                        _player2.UpdateScore(10, _player2.GetPlayerNumber());
                        _player2.SetIsHoldingItem(false);
                    }

                    Destroy(this.gameObject);
                    break;


                // If collided with Glass Plastic, decrease points
                case "Plastic":

                    if (GetPlayerNumber() == 1)
                    {
                        _player1.UpdateScore(-5, _player1.GetPlayerNumber());
                        _player1.SetIsHoldingItem(false);
                    }

                    else if (GetPlayerNumber() == 2)
                    {
                        _player2.UpdateScore(-5, _player2.GetPlayerNumber());
                        _player2.SetIsHoldingItem(false);
                    }

                    Destroy(this.gameObject);
                    break;


                // If collided with Can Bin, decrease points
                case "Can":

                    if (GetPlayerNumber() == 1)
                    {
                        _player1.UpdateScore(-5, _player1.GetPlayerNumber());
                        _player1.SetIsHoldingItem(false);
                    }

                    else if (GetPlayerNumber() == 2)
                    {
                        _player2.UpdateScore(-5, _player2.GetPlayerNumber());
                        _player2.SetIsHoldingItem(false);
                    }

                    Destroy(this.gameObject);
                    break;


                // If collided with Paper Bin, decrease points
                case "Paper":

                    if (GetPlayerNumber() == 1)
                    {
                        _player1.UpdateScore(-5, _player1.GetPlayerNumber());
                        _player1.SetIsHoldingItem(false);
                    }

                    else if (GetPlayerNumber() == 2)
                    {
                        _player2.UpdateScore(-5, _player2.GetPlayerNumber());
                        _player2.SetIsHoldingItem(false);
                    }

                    Destroy(this.gameObject);
                    break;


                default:
                    break;
            }
        }
    }
}