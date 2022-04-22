using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurttleShellSpawner : MonoBehaviour
{

    public GameObject TurttleShellPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;



    [SerializeField]
    private GameObject spawnTurttle1;
    [SerializeField]
    private GameObject spawnTurttle2;
    [SerializeField]
    private GameObject spawnTurttle3;


    private bool isSpawn1;
    private bool isSpawn2;
    private bool isSpawn3;
    // Start is called before the first frame update
    void Start()
    {
        spawnTurttle1 = Instantiate(TurttleShellPrefab, spawnPoint1.position, Quaternion.identity);
        spawnTurttle2 = Instantiate(TurttleShellPrefab, spawnPoint2.position, Quaternion.identity);
        spawnTurttle3 = Instantiate(TurttleShellPrefab, spawnPoint3.position, Quaternion.identity);
        isSpawn1 = false;
        isSpawn2 = false;
        isSpawn3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurttleObject();
    }


    void CheckTurttleObject()
    {
        if(spawnTurttle1 == null && isSpawn1 == false)
        {
            isSpawn1 = true;
            StopCoroutine(SpawnTurttle(1));
            StartCoroutine(SpawnTurttle(1));
        }
        if (spawnTurttle2 == null && isSpawn2 == false)
        {
            isSpawn2 = true;
            StopCoroutine(SpawnTurttle(2));
            StartCoroutine(SpawnTurttle(2));
        }
        if (spawnTurttle3 == null && isSpawn3 == false)
        {
            isSpawn3 = true;
            StopCoroutine(SpawnTurttle(3));
            StartCoroutine(SpawnTurttle(3));
        }
    }

    IEnumerator SpawnTurttle(int num)
    {
        yield return new WaitForSeconds(5f);
        if(num == 1)
        {
            spawnTurttle1 = Instantiate(TurttleShellPrefab, spawnPoint1.position, Quaternion.identity);
            isSpawn1 = false;
            yield break;
        }

        if (num == 2)
        {
            spawnTurttle2 = Instantiate(TurttleShellPrefab, spawnPoint2.position, Quaternion.identity);
            isSpawn2 = false;
            yield break;
        }

        if (num == 3)
        {
            spawnTurttle3 = Instantiate(TurttleShellPrefab, spawnPoint3.position, Quaternion.identity);
            isSpawn3 = false;
            yield break;
        }
    }
}
