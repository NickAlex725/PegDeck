using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;

public class LerpUI : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 10f;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;
    [Space]
    public bool atStart = true;

    private RectTransform _rect;
    private Vector2 _targetPosition = -Vector2.one;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        //update target
        UpdateTarget();

        if (_rect.anchoredPosition != _targetPosition)
        {
            if(Vector2.Distance(_rect.anchoredPosition, _targetPosition) > 1f)
            {
                _rect.anchoredPosition = Vector2.Lerp(_rect.anchoredPosition, _targetPosition, Time.deltaTime * _lerpSpeed);
            }
            else
            {
                _rect.anchoredPosition = _targetPosition;
            }
        }
    }

    private void UpdateTarget()
    {
        if (atStart)
        {
            if (_targetPosition != _startPosition) _targetPosition = _startPosition;
        }
        else
        {
            if (_targetPosition != _endPosition) _targetPosition = _endPosition;
        }
    }
}
