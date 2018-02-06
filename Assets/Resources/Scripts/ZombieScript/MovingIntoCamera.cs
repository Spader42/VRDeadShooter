using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIntoCamera : MonoBehaviour {

    public Transform target;
    public float nearEnoughFromTarget;
    public float speed;
    bool isnearToTarget;
    static int atakState = Animator.StringToHash("frappe");
    Animator anim;

    private void Start()
    {
        isnearToTarget = false;
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (!checkIfNearEnoughFromTarget() && !currentBaseState.IsName("frappe"))
        {
            float step = speed * Time.deltaTime;
            Vector3 positionTargetWithoutYAxes = target.position;
            positionTargetWithoutYAxes.y = transform.position.y;
            transform.LookAt(positionTargetWithoutYAxes);
            transform.position = Vector3.MoveTowards(transform.position, positionTargetWithoutYAxes, step);
        }
    }

    bool checkIfNearEnoughFromTarget()
    {
        if (Vector3.Distance(target.position, this.transform.position) <= nearEnoughFromTarget)
        {
            anim.SetBool("nearToTarget", true);
            isnearToTarget = true;
            return true;
        }
        anim.SetBool("nearToTarget", false);
        isnearToTarget = false;
        return false;
    }
}
