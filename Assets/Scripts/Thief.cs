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
    private bool _moveLeft;
    private Coroutine job;

    private void Start()
    {
        _thiefStartXPos = transform.position.x;
        _thiefEndXPos = _endPoint.position.x;
    }

    private void Update()
    {
        LaunchMovement();
    }

    public void LaunchMovement()
    {
        if (_moveLeft)
        {
            StopJob();
            job = StartCoroutine(Move(_thiefStartXPos));
        }
        else
        {
            StopJob();
            job = StartCoroutine(Move(_thiefEndXPos));
        }
    }

    private IEnumerator Move(float endPosition)
    {
        _newXPos = Mathf.MoveTowards(transform.position.x, endPosition, _speed * Time.deltaTime);
        transform.position = new Vector3(_newXPos, transform.position.y);

        if (transform.position.x == _endPoint.position.x)
        {
            _moveLeft = true;
        }

        // Debug.Log($"transform.position.x {transform.position.x}");
        // Debug.Log($"endPosition {endPosition}");
        // Debug.Log($"_speed * Time.deltaTime {_speed * Time.deltaTime}");
        // Debug.Log($"_newXPos {_newXPos}");

        yield return null;
    }

    private void StopJob()
    {
        if (job != null)
        {
            StopCoroutine(job);
        }
    }
}