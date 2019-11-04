using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5.0f;
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private bool _isHoldingItem = false;
    [SerializeField]
    private string _controller;

    private UIManager _uiManager = null;
    private Vector3 _direction = Vector3.zero;

    private CharacterController _characterController;
    private float _gravity = Physics.gravity.y;
    private Vector3 _velocity;


    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }

        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        //CalculateMovementCC(); // Character controller - not colliding atm
    }

    void CalculateMovement()
    {
        //float horizontalInput = Input.GetAxis("C1LHorizontal");
        //float verticalInput = Input.GetAxis("C1LVertical");

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }

    void CalculateMovementCC()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * _movementSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            _velocity.y = 0.0f;
        }
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void SetIsHoldingItem(bool holding)
    {
        _isHoldingItem = holding;
    }

    public bool GetIsHoldingItem()
    {
        return _isHoldingItem;
    }
}