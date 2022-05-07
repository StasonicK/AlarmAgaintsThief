using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private UnityEvent _opened = new UnityEvent();
    [SerializeField] private UnityEvent _closed = new UnityEvent();

    private const string Close = "Close";
    private const string Open = "Open";

    private Animator _animator;
    private bool _thiefInside;

    public event UnityAction Opened
    {
        add => _opened.AddListener(value);
        remove => _opened.RemoveListener(value);
    }

    public event UnityAction Closed
    {
        add => _closed.AddListener(value);
        remove => _closed.RemoveListener(value);
    }

    private void Start()
    {
        _animator = _door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Thief>(out Thief thiefController))
        {
            if (_thiefInside)
            {
                _animator.SetTrigger(Close);
                _thiefInside = false;
                _closed.Invoke();
            }
            else
            {
                _animator.SetTrigger(Open);
                _opened.Invoke();
                _thiefInside = true;
            }
        }
    }
}