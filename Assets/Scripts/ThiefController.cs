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

    private void Start()
    {
        _thiefStartXPos = transform.position.x;
        _thiefFinalXPos = _finalPoint.position.x;
    }

    private void Update()
    {
        time += Time.deltaTime;
        _newXPos = Mathf.MoveTowards(_thiefStartXPos, _thiefFinalXPos, _speed * time);
        transform.position = new Vector3(_newXPos, transform.position.y);
    }
}