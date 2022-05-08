using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private Alarm _alarm;
    [SerializeField] private UnityEvent _isOpened = new UnityEvent();

    private const string Close = "Close";
    private const string Open = "Open";

    private Animator _animator;
    private bool _thiefInside;

    public event UnityAction IsOpened
    {
        add => _isOpened.AddListener(value);
        remove => _isOpened.RemoveListener(value);
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
                _alarm.Launch(_thiefInside);
                _thiefInside = false;
                _isOpened.Invoke();
            }
            else
            {
                _animator.SetTrigger(Open);
                _alarm.Launch(_thiefInside);
                _isOpened.Invoke();
                _thiefInside = true;
            }
        }
    }
}