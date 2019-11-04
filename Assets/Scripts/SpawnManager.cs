using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // References to objects to spawn
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

    [SerializeField]
    private GameObject _objectContainer; // Container to hold objects



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine()); // Starts the Spawn Routine
    }


    // Update is called once per frame
    void Update()
    {
        // Set a random direction to items for spawning - Dunno if we need this?
        //_direction = transform.forward + (transform.rotation * new Vector3(0, 20, 10) * Random.Range(0, 1));
    }


    // Spawn items randomly
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            random = Random.Range(1, 4);

            switch (random)
            {

                // Spawn a Can Object
                case 1:

                    // Set the position for object to spawn and instantiate a new object
                    //Vector3 positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Vector3 positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject canObj = Instantiate(_canObjectPrefab, positionToSpawn, transform.rotation);

                    // Set a random velocity
                    canObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));

                    canObj.GetComponent<Object>().SetHasSpawned(true);
                    canObj.transform.parent = _objectContainer.transform;

                    yield return new WaitForSeconds(5.0f);
                    break;


                // Spawn a Glass Object
                case 2:

                    // Set the position for object to spawn and instantiate a new object
                    //positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject glassObj = Instantiate(_glassObjectPrefab, positionToSpawn, transform.rotation);

                    // Set a random velocity
                    glassObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));

                    glassObj.GetComponent<Object>().SetHasSpawned(true);
                    glassObj.transform.parent = _objectContainer.transform;

                    yield return new WaitForSeconds(5.0f);
                    break;


                // Spawn a Paper Object
                case 3:

                    // Set the position for object to spawn and instantiate a new object
                    // positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject paperObj = Instantiate(_paperObjectPrefab, positionToSpawn, transform.rotation);

                    // Set a random velocity
                    paperObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));

                    paperObj.GetComponent<Object>().SetHasSpawned(true);
                    paperObj.transform.parent = _objectContainer.transform;

                    yield return new WaitForSeconds(5.0f);
                    break;


                // Spawn a Platic Object
                case 4:

                    // Set the position for object to spawn and instantiate a new object
                    //positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    positionToSpawn = new Vector3(0.0f, 8.0f, 0.0f);
                    GameObject plasticObj = Instantiate(_plasticObjectPrefab, positionToSpawn, transform.rotation);

                    // Set a random velocity
                    plasticObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));

                    plasticObj.GetComponent<Object>().SetHasSpawned(true);
                    plasticObj.transform.parent = _objectContainer.transform;

                    yield return new WaitForSeconds(5.0f);
                    break;
            }
        }
    }
}