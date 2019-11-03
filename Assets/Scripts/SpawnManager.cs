using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _canObjectPrefab;
    [SerializeField]
    private GameObject _glassObjectPrefab;
    [SerializeField]
    private GameObject _paperObjectPrefab;
    [SerializeField]
    private GameObject _plasticObjectPrefab;
    int random = 0;
    private Vector3 _direction;
    [SerializeField]
    private float _speed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        _direction = transform.forward + (transform.rotation * new Vector3(0, 20, 10) * Random.Range(0, 1));
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            random = Random.Range(1, 4);

            switch (random)
            {
                case 1:
                    //Vector3 positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Vector3 positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject canObj = (GameObject)Instantiate(_canObjectPrefab, positionToSpawn, transform.rotation);
                    canObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 2:
                    //positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject glassObj = (GameObject)Instantiate(_glassObjectPrefab, positionToSpawn, transform.rotation);
                    glassObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 3:
                    // positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject paperObj = (GameObject)Instantiate(_paperObjectPrefab, positionToSpawn, transform.rotation);
                    paperObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 4:
                    //positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject plasticObj = (GameObject)Instantiate(_plasticObjectPrefab, positionToSpawn, transform.rotation);
                    plasticObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    yield return new WaitForSeconds(5.0f);
                    break;
            }

            //_canObjectPrefab.GetComponent<Rigidbody>().velocity = _direction * _speed * Time.deltaTime;
            //yield return new WaitForSeconds(5.0f);
        }
    }
}
