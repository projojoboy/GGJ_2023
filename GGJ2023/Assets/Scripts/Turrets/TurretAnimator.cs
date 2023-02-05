using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnimator : MonoBehaviour
{
    private Animator anim = null;
    private string curAnim = "";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnimation(string str)
    {
        if(curAnim == str) { return; }
        curAnim = str;

        switch (str)
        {
            case "idle":
                anim.Play("Idle");
                break;
            case "attack":
                anim.Play("Attack");
                break;
        }
    }
}
