using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour {

    public AnimationClip[] animationClips;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        int index = Random.Range(0, animationClips.Length);
        animator.Play(animationClips[index].name);
    }

}
