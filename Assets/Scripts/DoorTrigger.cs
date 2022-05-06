using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private UnityEvent _doorOpened = new UnityEvent();
    [SerializeField] private UnityEvent _doorClosed = new UnityEvent();

    private const string Close = "Close";
    private const string Open = "Open";

    private Animator _doorAnimator;
    private bool _thiefInside;

    public event UnityAction DoorOpened
    {
        add => _doorOpened.AddListener(value);
        remove => _doorOpened.RemoveListener(value);
    }

    public event UnityAction DoorClosed
    {
        add => _doorClosed.AddListener(value);
        remove => _doorClosed.RemoveListener(value);
    }

    private void Start()
    {
        _doorAnimator = _door.GetComponent<Animator>();
        // _doorAnimator.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Thief>(out Thief thiefController))
        {
            if (_thiefInside)
            {
                _doorAnimator.SetTrigger(Close);
                _thiefInside = false;
                _doorClosed.Invoke();
            }
            else
            {
                _doorAnimator.SetTrigger(Open);
                _doorOpened.Invoke();
                _thiefInside = true;
            }
        }
    }
}