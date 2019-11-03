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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            random = Random.Range(1, 4);

            switch (random)
            {
                case 1:
                    Vector3 positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Instantiate(_canObjectPrefab, positionToSpawn, Quaternion.identity);
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 2:
                    positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Instantiate(_glassObjectPrefab, positionToSpawn, Quaternion.identity);
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 3:
                    positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Instantiate(_paperObjectPrefab, positionToSpawn, Quaternion.identity);
                    yield return new WaitForSeconds(5.0f);
                    break;

                case 4:
                    positionToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, Random.Range(-8.0f, 8.0f));
                    Instantiate(_plasticObjectPrefab, positionToSpawn, Quaternion.identity);
                    yield return new WaitForSeconds(5.0f);
                    break;
            }
        }
    }
}
