using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestWithCoinController : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private GameObject _coin;
    private Animator _chestAnimator;
    private Animator _coinAnimator;

    private void Start()
    {
        _coin.SetActive(false);
        _chestAnimator = _chest.GetComponent<Animator>();
        _chestAnimator.enabled = true;
        _coinAnimator = _coin.GetComponent<Animator>();
        _coinAnimator.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<ThiefController>(out ThiefController thiefController))
        {
            Debug.Log("OnTriggerEnter2D chest");
            gameObject.SetActive(true);
            _chestAnimator.SetTrigger("Open");
            _coinAnimator.SetTrigger("Jump");
        }
    }

    public void DestroyCoin()
    {
        Destroy(_coin);
    }
}