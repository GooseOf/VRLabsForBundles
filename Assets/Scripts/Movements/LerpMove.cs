using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpMove : MonoBehaviour
{
    [SerializeField] private Transform MovingObj;
    [SerializeField] private Vector3 _goalPos;
    [SerializeField] private Transform goalPositionTransform;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Sprite[] sprites;

    private float _current, _target;
    private Vector3 _curPos;
    private bool isMoved = false;

    private Image image;

    private void Start()
    {
        _curPos = MovingObj.position;

        image = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        _target = isMoved ? 1 : 0;
        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        var goalPos = _goalPos;

        if (goalPositionTransform != null)
            goalPos = goalPositionTransform.position;

        MovingObj.position = Vector3.Lerp(_curPos, goalPos, _curve.Evaluate(_current));
    }
    public void Move()
    {
        isMoved = !isMoved;
        ChangeSprite();
    }
    private void ChangeSprite()
    {
        if (isMoved) { image.sprite = sprites[1]; }
        else { image.sprite = sprites[0]; }
    }
}
