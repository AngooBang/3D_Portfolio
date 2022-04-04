using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemChestController : MonoBehaviour
{
    [SerializeField]
    Animation animation;
    [SerializeField]
    ChestEffectCycler chestEffectCycler;

    public Canvas HUDCanvas;
    public GameObject NameTextPrefab;

    public GameObject player;

    public TextMeshProUGUI NameText;

    private void Awake()
    {
        animation = GetComponentInChildren<Animation>();
        chestEffectCycler = GetComponentInChildren<ChestEffectCycler>();
        HUDCanvas = GameObject.FindGameObjectWithTag("HUDCanvas").GetComponent<Canvas>();

        NameTextPrefab = Instantiate(NameTextPrefab, HUDCanvas.transform);
        NameTextPrefab.GetComponent<EnemyHPSlider>().target = transform;
        NameText = NameTextPrefab.GetComponentInChildren<TextMeshProUGUI>();

        NameText.text = "받아올 이름";

        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnDestroy()
    {
        Destroy(NameTextPrefab);
    }

    private void Update()
    {
        Vector3 distVec = player.transform.position - transform.position;

        if(distVec.magnitude < 4.0f)
        {
            NameTextPrefab.SetActive(true);
            if (Input.GetKeyDown(KeyCode.G))
            {
                PickUpItem();
            }
        }
        else
        {
            NameTextPrefab.SetActive(false);
        }
    }
    void PickUpItem()
    {
        animation.Play();
        chestEffectCycler.PlayEffect();

        Destroy(gameObject, 1.5f);
    }
}
