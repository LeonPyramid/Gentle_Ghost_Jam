﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSync : MonoBehaviour
{
    private Animator animator;
    private orient orientation;
    private bool isMoving;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        orientation = GetComponent<MoveOnTiles>().curOrient;
        isMoving = GetComponent<MoveOnTiles>().GetIsMoving();
        animator.SetBool("North",orientation==orient.n);
        animator.SetBool("South",orientation==orient.s);
        animator.SetBool("West",orientation==orient.w);
        animator.SetBool("East",orientation==orient.e);
        animator.SetBool("IsMoving",isMoving);
    }
}