using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoorOnTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}