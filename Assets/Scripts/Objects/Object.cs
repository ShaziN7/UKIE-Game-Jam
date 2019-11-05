using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Player _player1 = null; // Reference to player 1
    private Player _player2 = null; // Reference to player 2
    private bool _isCollected = false; // If object has been collected
    private int _collectedBy = 0;
    [SerializeField]
    private float _timer = 0.0f; // Timer for object lying on floor
    private bool _atSpawn = false; // If object is still at spawn
    [SerializeField]
    public int _playerNumber = 0;


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


    // Update is called once per frame
    void Update()
    {
        // If the player is carrying the object
        if (_isCollected && (!Input.GetButtonDown("P1Throw") || !Input.GetButtonDown("P2Throw")))
        {
            CarryObject(_collectedBy);
        }

        // If the object hasn't been picked up
        if (_atSpawn)
        {
            Timer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Player 1 picks up the item
        if (_player1.GetIsHoldingItem() == false && other.tag == "Player1")
        {
            _isCollected = true;
            _collectedBy = 1;
            _player1.SetIsHoldingItem(true);
        }

        // Player 2 picks up the item
        else if (_player2.GetIsHoldingItem() == false && other.tag == "Player2")
        {
            _isCollected = true;
            _collectedBy = 2;
            _player2.SetIsHoldingItem(true);
        }

        // Object is on the floor
        else if (other.tag == "Floor")
        {
            
            _player1.SetIsHoldingItem(false);
            _player2.SetIsHoldingItem(false);

            _isCollected = false;
        }
    }


    // Set the position of the object to the player
    public void CarryObject(int player)
    {
        if (player == 1)
        {
            Vector3 player1Position = new Vector3(_player1.transform.position.x, _player1.transform.position.y + 1.0f, _player1.transform.position.z + 1.0f);
            transform.position = player1Position;
            _playerNumber = _player1.GetPlayerNumber();
        }

        else if (player == 2)
        {
            Vector3 player2Position = new Vector3(_player2.transform.position.x, _player2.transform.position.y + 1.0f, _player2.transform.position.z + 1.0f);
            transform.position = player2Position;
            _playerNumber = _player2.GetPlayerNumber();
        }
        
        _atSpawn = false;
    }


    public void Timer()
    {
        _timer += Time.deltaTime;

        if (_timer >= 10.0f)
        {
            _player1.UpdateScore(-2, _player1.GetPlayerNumber());
            _player2.UpdateScore(-2, _player2.GetPlayerNumber());
            Destroy(this.gameObject);
        }
    }


    public void SetHasSpawned(bool spawned)
    {
        _atSpawn = spawned;
    }

    public int GetPlayerNumber()
    {
        return _playerNumber;
    }
}
