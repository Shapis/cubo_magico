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
        Swipe();

        if (transform.rotation != _targetTransform.rotation)
        {
            var step = m_Speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                _targetTransform.rotation,
                step
            );
        }
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _touchDown = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _touchUp = Input.mousePosition;
            _touchDelta = _touchUp - _touchDown;
            _touchDelta.Normalize();
            if (LeftSwipe(_touchDelta))
            {
                _targetTransform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(_touchDelta))
            {
                _targetTransform.Rotate(0, -90, 0, Space.World);
            }
        }

        bool LeftSwipe(Vector2 swipe)
        {
            return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
        }

        bool RightSwipe(Vector2 swipe)
        {
            return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
        }

        bool UpLeftSwipe(Vector2 swipe)
        {
            return swipe.x < 0f && swipe.y < 0f;
        }

        bool UpRightSwipe(Vector2 swipe)
        {
            return swipe.x > 0f && swipe.y < 0f;
        }
    }
}
