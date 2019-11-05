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
    private float _movementSpeed = 10.0f;
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private GameObject particlesystem;

    private bool _isHoldingItem = false;
   
    private UIManager _uiManager = null;

    private Object _objectHeld;
    private Vector3 direction = Vector3.zero;

       // Start is called before the first frame update
    void Start()
    {

        if (gameObject.tag == "Player" )
        {
            this.transform.position = new Vector3(0f, 3.2f, 0.0f);
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

    }

    // Calculate player movement
    void CalculateMovement()
    {
        float LhorizonalInput = Input.GetAxis(LHorizontal);
        float LverticalInput = Input.GetAxis(LVertical);

        Vector3 direction = new Vector3(LhorizonalInput, 0, LverticalInput);

        transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);
        transform.LookAt(transform.position + new Vector3(LhorizonalInput, 0, LverticalInput), Vector3.up);

        if (LhorizonalInput != 0 || LverticalInput != 0)
        {
            particlesystem.SetActive(true);
        }
        else
        {
            particlesystem.SetActive(false);
        }
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