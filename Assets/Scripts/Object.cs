using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Player _player = null;
    private bool _isCollected = false;
    private Vector3 _direction;
    [SerializeField]
    private float _speed = 20.0f;
    [SerializeField]
    private bool _hasBeenThrown = false;
    [SerializeField]
    private float _timer = 0.0f;
    [SerializeField]
    private bool _hasSpawned = false;


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
        // If the player is carrying the object
        if (_isCollected && !Input.GetButtonDown("Throw"))
        {
            Vector3 playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + 1.0f, _player.transform.position.z + 1.0f);

            transform.position = playerPosition;
            _hasBeenThrown = false;
            _hasSpawned = false;
        }

        // If the player throws the object
        else if (_isCollected && Input.GetButtonDown("Throw"))
        {
            _direction = transform.forward + (transform.rotation * new Vector3(0, 20, 10));

            //GetComponent<Rigidbody>().AddForce(_player.transform.forward * _throwForce);
            GetComponent<Rigidbody>().velocity = _direction * _speed * Time.deltaTime;
            _isCollected = false;
            _hasBeenThrown = true;
            _hasSpawned = false;
        }

        if (_hasSpawned)
        {
            Timer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_player.GetIsHoldingItem() && other.tag == "Player")
        {
            _isCollected = true;
            _player.SetIsHoldingItem(true);
        }

        if (other.tag == "Floor")
        {
            _isCollected = false;
            _player.SetIsHoldingItem(false);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            _hasBeenThrown = false;
        }
    }

    public bool HasObjectBeenThrown()
    {
        return _hasBeenThrown;
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
        _hasSpawned = spawned;
    }
}
