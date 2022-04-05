using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    private Rigidbody rigid;
    public InventorySystem inventorySystem;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        inventorySystem = GameObject.FindGameObjectWithTag("MainInventory").GetComponent<InventorySystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float randNum = Random.Range(3f, 7f);
        rigid.AddForce(Vector3.up * randNum, ForceMode.Impulse);

        randNum = Random.Range(1f, 3f);
        rigid.AddForce(Random.onUnitSphere.normalized * randNum, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // 자석처럼 빨려들어가고. 생성시 튀어오르게 해야디~

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            inventorySystem.GetCoin(1);
            Destroy(gameObject);
        }
    }
}
