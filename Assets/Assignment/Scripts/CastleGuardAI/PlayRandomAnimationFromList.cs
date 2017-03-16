using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class PlayRandomAnimationFromList : ActionNode
{
    Animator animator;
    public AnimationClip[] animationClips;
    bool playing = false;

    public override void Reset()
    {
        animator = owner.root.GetComponent<Animator>();
    }

    public void AnimationEnd()
    {
        Debug.Log("AnimationEnd");
        playing = false;
    }

    public override void Start()
    {
        int index = Random.Range(0, animationClips.Length);
        animator.Play(animationClips[index].name);
        playing = true;
    }

    public override Status Update()
    {
        if (!playing)
        {
            return Status.Failure;            
        }
        else
        {
            return Status.Running;
        }
    }
}
