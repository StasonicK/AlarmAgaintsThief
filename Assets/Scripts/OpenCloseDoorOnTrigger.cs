using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OpenCloseDoorOnTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _doorOpened = new UnityEvent();

    public event UnityAction DoorOpened
    {
        add => _doorOpened.AddListener(value);
        remove => _doorOpened.RemoveListener(value);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
        if (col.TryGetComponent<ThiefController>(out ThiefController thiefController))
        {
            Debug.Log("Open the door!");
            _animator.SetTrigger("OpenDoor");
            
            _doorOpened.Invoke();
        }
    }

}