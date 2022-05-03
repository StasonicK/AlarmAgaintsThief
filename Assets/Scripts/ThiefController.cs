using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    // [SerializeField] private GameObject _finalPoint;
    [SerializeField] private Transform _finalPoint;
    [SerializeField] private float _speed;

    // [SerializeField] private Transform _thief;
    // private float _thiefStartXPos => _thief.transform.position.x;
    private float _thiefStartXPos;
    private float _thiefFinalXPos;
    private float _newXPos;
    private float time;

    private void Start()
    {
        _thiefStartXPos = transform.position.x;
        _thiefFinalXPos = _finalPoint.position.x;

        Debug.Log("_thiefStartXPos " + _thiefStartXPos);
        Debug.Log("_thiefFinalXPos " + _thiefFinalXPos);
    }

    private void Update()
    {
        time += Time.deltaTime;
        _newXPos = Mathf.MoveTowards(_thiefStartXPos, _thiefFinalXPos, _speed * time);
        transform.position = new Vector3(_newXPos, transform.position.y);
        Debug.Log("_newXPos " + _newXPos);
        Debug.Log("transform.position " + transform.position);
    }
}