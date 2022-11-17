using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField]
    private Transform m_EntireCube;

    [SerializeField]
    private float m_Speed = 1f;
    private Vector2 _touchDown;
    private Vector2 _touchUp;
    private Vector2 _touchDelta;
    private Transform _targetTransform;
    private bool _isMoving = false;
    private bool _isBeingDragged;

    // Start is called before the first frame update
    void Start()
    {
        var _go = Instantiate(new GameObject(), new Vector3(1, 1, 1), Quaternion.identity);
        _go.name = "TargetRotation";
        _targetTransform = _go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSwipeControl();
        Drag();
    }

    private void Drag()
    {
        if (!_isMoving && Input.GetMouseButton(1))
        {
            print("dragging");
        }
    }

    private void SwipeDirectionDecider(Vector2 touchDelta)
    {
        if (touchDelta.x < 0f && touchDelta.y > -0.5f && touchDelta.y < 0.5f)
        {
            _targetTransform.Rotate(0, 90, 0, Space.World);
        }
        else if (touchDelta.x > 0f && touchDelta.y > -0.5f && touchDelta.y < 0.5f)
        {
            _targetTransform.Rotate(0, -90, 0, Space.World);
        }
        else if (touchDelta.x < 0f && touchDelta.y > 0f)
        {
            _targetTransform.Rotate(0, 0, 90, Space.World);
        }
        else if (touchDelta.x > 0f && touchDelta.y > 0f)
        {
            _targetTransform.Rotate(90, 0, 0, Space.World);
        }
        else if (touchDelta.x > 0f && touchDelta.y < 0f)
        {
            _targetTransform.Rotate(0, 0, -90, Space.World);
        }
        else if (touchDelta.x < 0f && touchDelta.y < 0f)
        {
            _targetTransform.Rotate(-90, 0, 0, Space.World);
        }
    }

    void CameraSwipeControl()
    {
        if (Input.GetMouseButtonDown(1) && !_isMoving)
        {
            _touchDown = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1) && !_isMoving)
        {
            _touchUp = Input.mousePosition;
            _touchDelta = _touchUp - _touchDown;
            _touchDelta.Normalize();

            SwipeDirectionDecider(_touchDelta);
        }

        if (transform.rotation != _targetTransform.rotation && !_isBeingDragged)
        {
            _isMoving = true;
            var step = m_Speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                _targetTransform.rotation,
                step
            );
        }
        else if (!_isBeingDragged)
        {
            _isMoving = false;
        }
    }
}
