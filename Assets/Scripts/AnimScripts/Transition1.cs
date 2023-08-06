using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(CharacterScript.instance.isAttacking)
        {
            CharacterScript.instance.myAnim.Play("Knight_Attack2");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterScript.instance.isAttacking = false;
    }
}
