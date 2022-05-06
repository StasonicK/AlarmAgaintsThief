using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private float _thiefStartXPos;
    private float _thiefEndXPos;
    private float _newXPos;
    private float _time;
    private bool _needMoveLeft = false;

    private void Start()
    {
        _thiefStartXPos = transform.position.x;
        _thiefEndXPos = _endPoint.position.x;
    }

    private void Update()
    {
        if (_needMoveLeft)
        {
            _time = 0.0f;
            Move(false);
        }
        else
        {
            Move(true);
        }
    }

    private void Move(bool right)
    {
        _time += Time.deltaTime;

        if (right)
        {
            _newXPos = Mathf.MoveTowards(_thiefStartXPos, _thiefEndXPos, _speed * _time);
        }
        else
        {
            _newXPos = Mathf.MoveTowards(transform.position.x, _thiefStartXPos, _speed * _time);
        }

        transform.position = new Vector3(_newXPos, transform.position.y);

        if (transform.position.x == _thiefEndXPos)
        {
            _needMoveLeft = true;
        }
    }
}