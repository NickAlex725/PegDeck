using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingStat : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 10f;
    private bool _canMove = false;

    private RectTransform _rect;
    private Vector2 _targetPosition;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _text = GetComponent<TextMeshProUGUI>();
    }
    public void InitializeMove(Vector2 targetPosition, int statValue)
    {
        //update text and start moving towards position
        if(_rect == null) _rect = GetComponent<RectTransform>();
        if(_text == null) _text = GetComponent<TextMeshProUGUI>();

        _canMove = true;
        _targetPosition = targetPosition;
        _text.text = statValue.ToString();
    }

    public void Update()
    {
        if (_canMove)
        {
            if(_rect.anchoredPosition != _targetPosition)
            {
                if(Vector2.Distance(_rect.anchoredPosition, _targetPosition) >= 0.5f)
                {
                    _rect.anchoredPosition = Vector2.Lerp(_rect.anchoredPosition, _targetPosition, Time.deltaTime * _lerpSpeed);
                }
                else
                {
                    _rect.anchoredPosition = _targetPosition;
                    Destroy(gameObject);
                }
            }
        }
    }
}
