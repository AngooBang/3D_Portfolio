using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public GameObject HpBarPrefab;

    private Canvas hpCanvas;
    private Slider hpSlider;
    private EnemyLiving enemyLiving;

    private Vector3 hpBarOffset = new Vector3(0f, 1.5f, 0f);



    // Start is called before the first frame update
    void Awake()
    {
        hpCanvas = GameObject.Find("EnemyHPCanvas").GetComponent<Canvas>();

        
        GameObject enemyHpBar = Instantiate(HpBarPrefab, hpCanvas.transform);
        hpSlider = enemyHpBar.GetComponent<Slider>();
        hpSlider.value = 1f;
        var _hpbar = enemyHpBar.GetComponent<EnemyHPSlider>();
        _hpbar.target = this.transform;
        _hpbar.offset = hpBarOffset;

        enemyLiving = GetComponent<EnemyLiving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHPBarValue()
    {
        hpSlider.value = (float)enemyLiving.CurrentHP / enemyLiving.MaxHP;
        if (enemyLiving.isDead)
            Destroy(hpSlider.gameObject, 5);
        Debug.Log(hpSlider.value);
    }
}
