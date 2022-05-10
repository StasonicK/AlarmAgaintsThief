using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _coin;

    private const string Open = "Open";
    private const string Close = "Close";
    private const string Jump = "Jump";

    private Animator _chestAnimator;
    private Animator _coinAnimator;

    private void Start()
    {
        _coin.SetActive(false);
        _chestAnimator = _chest.GetComponent<Animator>();
        _coinAnimator = _coin.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Thief>(out Thief thief))
        {
            _coin.SetActive(true);
            _chestAnimator.SetTrigger(Open);
            _coinAnimator.SetTrigger(Jump);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            Destroy(_coin.gameObject);
            _chestAnimator.SetTrigger(Close);
        }
    }
}