using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAndCoinObj : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private Coin _coin;

    private const string Open = "Open";
    private const string Jump = "Jump";
    private const string Thief = "Thief";

    private Animator _chestAnimator;
    private Animator _coinAnimator;

    private void Start()
    {
        _coin.SetActive(false);
        _chestAnimator = _chest.GetComponent<Animator>();
        _coinAnimator = _coin.GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent<Thief>(out Thief thief))
        {
            _coin.SetActive(true);
            _chestAnimator.SetTrigger(Open);
            _coinAnimator.SetTrigger(Jump);
        }
    }
}