using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private string LHorizontal = "LHorizontal";
    [SerializeField]
    private string LVertical = "LVertical";
    [SerializeField]
    private string RHorizontal = "RHorizontal";
    [SerializeField]
    private string Rvertical = "RVertical";
    [SerializeField]
    private string Controller = "0";
    [SerializeField]
    public int _playerNumber;

    [SerializeField]
    private float _mSpeed = 10.0f;
    [SerializeField]
    private int _score = 0;
    private bool _isHoldingItem = false;
   
    private UIManager _uiManager = null;

    private Object _objectHeld;
    private Vector3 direction = Vector3.zero;

       // Start is called before the first frame update
    void Start()
    {

        if (gameObject.tag == "Player1" )
        {
            this.transform.position = new Vector3(-11.0f, 2.0f, -13.0f);
        }

        if (gameObject.tag == "Player2")
        {
            this.transform.position = new Vector3(9.0f, 2.0f, -13.0f);
        }

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
        calculateRotation();
    }

    // Calculate player movement
    void CalculateMovement()
    {
        float LhorizonalInput = Input.GetAxis(LHorizontal);
        float LverticalInput = Input.GetAxis(LVertical);

        Vector3 direction = new Vector3(LhorizonalInput, 0, LverticalInput);

        transform.Translate(direction * _mSpeed * Time.deltaTime, Space.World);
        transform.LookAt(transform.position + new Vector3(LhorizonalInput, 0, LverticalInput), Vector3.up);
    }

    
    void calculateRotation()
    {
        //float RhorizontalInput = Input.GetAxis(RHorizontal);
        //float RverticalInput = Input.GetAxis(Rvertical);

        //transform.LookAt(transform.position + new Vector3(RhorizontalInput, 0, RverticalInput), Vector3.up);

    }
    // Updates player score
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * 50);
    }
}