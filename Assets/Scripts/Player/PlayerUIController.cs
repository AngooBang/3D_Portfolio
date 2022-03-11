using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject HPprefab;
    public GameObject SPprefab;
    public GameObject InteractiveImg;

    private Slider hpSlider;
    private Slider spSlider;

    private PlayerStatus pStatus;
    // Start is called before the first frame update
    void Start()
    {
        pStatus = GetComponent<PlayerStatus>();

        hpSlider = HPprefab.GetComponent<Slider>();
        spSlider = SPprefab.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHPBarValue()
    {
        hpSlider.value = (float)pStatus.CurrentHP / pStatus.MaxHP;
    }

    public void SetSPBarValue()
    {
        spSlider.value = (float)pStatus.CurrentSP / pStatus.MaxSP;
    }

    public void ShowInteractiveImg()
    {
        InteractiveImg.SetActive(true);
    }

    public void HideInteractiveImg()
    {
        InteractiveImg.SetActive(false);
    }
}
