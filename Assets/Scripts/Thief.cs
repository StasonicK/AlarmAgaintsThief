using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(LaunchMovement(transform.position.x, _endPoint.position.x));
    }

    public IEnumerator LaunchMovement(float start, float end)
    {
        yield return StartCoroutine(Move(end));

        StartCoroutine(Move(start));
    }

    private IEnumerator Move(float target)
    {
        while (transform.position.x != target)
        {
            float newXPos = Mathf.MoveTowards(transform.position.x, target, _speed * Time.deltaTime);
            transform.position = new Vector3(newXPos, transform.position.y);

            yield return null;
        }
    }
}