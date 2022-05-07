using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _coin;

    private const string Open = "Open";
    private const string Jump = "Jump";
    private const string Thief = "Thief";

    private Animator _chestAnimator;
    private Animator _coinAnimator;

    private void Start()
    {
        // _coin.SetActive(false);
        _chestAnimator = _chest.GetComponent<Animator>();
        // _chestAnimator.enabled = true;
        _coinAnimator = _coin.GetComponent<Animator>();
        // _coinAnimator.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Thief))
        {
            Debug.Log("OnCollisionEnter2D chest");
            // gameObject.SetActive(true);
            _chestAnimator.SetTrigger(Open);
            _coinAnimator.SetTrigger(Jump);
        }
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.TryGetComponent<Thief>(out Thief thiefController))
    //     {
    //         Debug.Log("OnTriggerEnter2D chest");
    //         // gameObject.SetActive(true);
    //         _chestAnimator.SetTrigger(Open);
    //         _coinAnimator.SetTrigger(Jump);
    //     }
    // }
}