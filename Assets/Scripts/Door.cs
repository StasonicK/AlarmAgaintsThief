using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private const string Close = "Close";
    private const string Open = "Open";

    private Animator _animator;
    private bool _thiefInside;

    public event UnityAction<bool> Opened;

    private void Start()
    {
        _animator = _door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Thief>(out Thief thiefController))
        {
            _thiefInside = !_thiefInside;
            _animator.SetTrigger(_thiefInside ? Open : Close);
            Opened?.Invoke(_thiefInside);
        }
    }
}