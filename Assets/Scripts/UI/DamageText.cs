using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float MoveSpeed;
    public float AlphaSpeed;
    public float DestroyTime;

    public int damage;

    private TextMeshPro tmPro;
    private Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        tmPro = GetComponent<TextMeshPro>();
        alpha = tmPro.color;
        tmPro.text = damage.ToString();

        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, MoveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, AlphaSpeed * Time.deltaTime);
        tmPro.color = alpha;
    }
}
