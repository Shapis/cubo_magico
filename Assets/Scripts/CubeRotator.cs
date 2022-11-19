using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CubeRotator : MonoBehaviour
{
    [SerializeField]
    private Transform m_EntireCube;

    [SerializeField]
    private float m_Speed = 1f;
    private Vector2 _touchDown;
    private Vector2 _touchUp;
    private Vector2 _touchDelta;
    private Quaternion _targetRotation = Quaternion.identity;
    private Quaternion _previousRotation = Quaternion.identity;
    private bool _isMoving = false;
    private bool _isBeingDragged;

    Transform nearestHit = null;

    // Update is called once per frame
    void Update()
    {
        Drag();
        RotateToTarget();
    }

    private void Drag()
    {
        // int? rotationAxis = null;
        if (!_isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nearestHit = null;
                // _targetRotation = Quaternion.identity;
                var rayHits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

                float minDistance = 99999f;

                foreach (var item in rayHits)
                {
                    if (item.distance < minDistance)
                    {
                        minDistance = item.distance;
                        nearestHit = item.transform;
                    }
                }

                _touchDown = Input.mousePosition;
                _previousRotation = transform.rotation;
            }
            if (Input.GetMouseButton(0) && nearestHit == null)
            {
                _touchDelta = (Vector2)Input.mousePosition - _touchDown;
                if (_touchDelta.x < 0f)
                {
                    _targetRotation = _previousRotation * Quaternion.Euler(0, -_touchDelta.x, 0);
                }
                else if (_touchDelta.x > 0f)
                {
                    _targetRotation = _previousRotation * Quaternion.Euler(0, -_touchDelta.x, 0);
                }
            }
        }
    }

    private void RotateToTarget()
    {
        _isMoving = false;
        if (transform.rotation != _targetRotation)
        {
            _isMoving = true;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                _targetRotation,
                m_Speed * Time.deltaTime
            );
        }
    }

    // private void SwipeDirectionDecider(Vector2 touchDelta)
    // {
    //     if (touchDelta.x < 0f && touchDelta.y > -0.5f && touchDelta.y < 0.5f)
    //     {
    //         _targetRotation.Rotate(0, 90, 0, Space.World);
    //     }
    //     else if (touchDelta.x > 0f && touchDelta.y > -0.5f && touchDelta.y < 0.5f)
    //     {
    //         _targetRotation.Rotate(0, -90, 0, Space.World);
    //     }
    //     else if (touchDelta.x < 0f && touchDelta.y > 0f)
    //     {
    //         _targetRotation.Rotate(0, 0, 90, Space.World);
    //     }
    //     else if (touchDelta.x > 0f && touchDelta.y > 0f)
    //     {
    //         _targetRotation.Rotate(90, 0, 0, Space.World);
    //     }
    //     else if (touchDelta.x > 0f && touchDelta.y < 0f)
    //     {
    //         _targetRotation.Rotate(0, 0, -90, Space.World);
    //     }
    //     else if (touchDelta.x < 0f && touchDelta.y < 0f)
    //     {
    //         _targetRotation.Rotate(-90, 0, 0, Space.World);
    //     }
    // }

    // void CameraSwipeControl()
    // {
    //     if (Input.GetMouseButtonDown(1) && !_isMoving)
    //     {
    //         _touchDown = Input.mousePosition;
    //     }
    //     if (Input.GetMouseButtonUp(1) && !_isMoving)
    //     {
    //         _touchUp = Input.mousePosition;
    //         _touchDelta = _touchUp - _touchDown;
    //         _touchDelta.Normalize();

    //         SwipeDirectionDecider(_touchDelta);
    //     }

    //     if (transform.rotation != _targetRotation.rotation && !_isBeingDragged)
    //     {
    //         _isMoving = true;
    //         var step = m_Speed * Time.deltaTime;
    //         transform.rotation = Quaternion.RotateTowards(
    //             transform.rotation,
    //             _targetRotation.rotation,
    //             step
    //         );
    //     }
    //     else if (!_isBeingDragged)
    //     {
    //         _isMoving = false;
    //     }
    // }
}
