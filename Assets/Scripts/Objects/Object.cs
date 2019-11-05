using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
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
            _player = GameObject.Find("Player").GetComponent<Player>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // If the player is carrying the object
        if (_isCollected)
        {
            CarryObject();
        }

        // If the object hasn't been picked up
        if (_atSpawn)
        {
            Timer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Player picks up the item
        if (_player.GetIsHoldingItem() == false && other.tag == "Player")
        {
            _isCollected = true;
            _player.SetIsHoldingItem(true);
        }

        // Object is on the floor
        else if (other.tag == "Floor")
        {
            
            //_player.SetIsHoldingItem(false);

            _isCollected = false;
        }
    }


    // Set the position of the object to the player
    public void CarryObject()
    {
        Vector3 playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + 1.0f, _player.transform.position.z + 1.0f);

        transform.position = playerPosition;
        _atSpawn = false;
    }


    public void Timer()
    {
        _timer += Time.deltaTime;

        if (_timer >= 10.0f)
        {
            _player.UpdateScore(-2);
            Destroy(this.gameObject);
        }
    }


    public void SetHasSpawned(bool spawned)
    {
        _atSpawn = spawned;
    }
}
