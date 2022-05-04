using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OpenCloseDoorOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private UnityEvent _doorOpened = new UnityEvent();
    [SerializeField] private UnityEvent _doorClosed = new UnityEvent();
    private Animator _doorAnimator;
    private bool thiefInside = false;

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
        _doorAnimator.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<ThiefController>(out ThiefController thiefController))
        {
            if (thiefInside)
            {
                _doorAnimator.SetTrigger("Close");
                // _doorAnimator.Play();
                thiefInside = false;
                _doorClosed.Invoke();
            }
            else
            {
                Debug.Log("Open the door!");
                _doorAnimator.SetTrigger("Open");
                // _doorAnimator.Play();
                _doorOpened.Invoke();
                thiefInside = true;
            }
        }
    }
}