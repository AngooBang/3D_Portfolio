using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_DetectPlayer : MonoBehaviour
{
    public bool IsDetect;
    private Animator animator;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        IsDetect = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        //Debug.Log(dist + " 만큼의 거리.");
        if(dist < 11f)
        {
            IsDetect = true;
            animator.SetBool("IsDetect", true);
        }

        if(dist > 15f)
        {
            IsDetect = false;
            animator.SetBool("IsDetect", false);
        }

    }
}
