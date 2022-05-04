using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    [SerializeField] private Transform _finalPoint;
    [SerializeField] private float _speed;
    private float _thiefStartXPos;
    private float _thiefFinalXPos;
    private float _newXPos;
    private float time;
    private bool isChestReached = false;

    private void Start()
    {
        _thiefStartXPos = transform.position.x;
        _thiefFinalXPos = _finalPoint.position.x;
    }

    private void Update()
    {
        if (isChestReached)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    public void ChestReached()
    {
        isChestReached = true;
    }

    private void MoveRight()
    {
        time += Time.deltaTime;
        _newXPos = Mathf.MoveTowards(_thiefStartXPos, _thiefFinalXPos, _speed * time);
        transform.position = new Vector3(_newXPos, transform.position.y);
    }

    private void MoveLeft()
    {
        time += Time.deltaTime;
        _newXPos = Mathf.MoveTowards(_thiefFinalXPos, _thiefStartXPos, _speed * time);
        transform.position = new Vector3(_newXPos, transform.position.y);
    }
}