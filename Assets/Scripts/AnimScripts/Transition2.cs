using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2 : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(CharacterScript.instance.isAttacking)
        {
            CharacterScript.instance.myAnim.Play("Knight_Attack3");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterScript.instance.isAttacking = false;
    }
}
