using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHPBarController : MonoBehaviour
{
    public GameObject HPBarObject;
    public Image FillImage;
    public TextMeshProUGUI healthText;

    private BossLiving bossLiving;
    // Start is called before the first frame update
    void Start()
    {
        bossLiving = GetComponent<BossLiving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHPValue()
    {
        healthText.text = $"{bossLiving.CurrentHP}  /  {bossLiving.MaxHP}";
        FillImage.fillAmount = (float)bossLiving.CurrentHP / bossLiving.MaxHP;
    }

    public void DestroyHealthBar()
    {
        Destroy(HPBarObject, 4f);
    }
}
