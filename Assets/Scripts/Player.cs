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

    private UIManager _uiManager = null;


    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
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

    public void UpdateScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void setIsHoldingItem(bool holding)
    {
        _isHoldingItem = holding;
    }

    public bool getIsHoldingItem()
    {
        return _isHoldingItem;
    }
}