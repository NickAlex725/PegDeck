using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool _startOnPeggle;
    [SerializeField] private Vector3 _pegglePosition;
    [SerializeField] private Vector3 _cardPosition;
    [SerializeField] private float _lerpSpeed = 10f;

    private Vector3 _targetPosition;
    private Camera _mainCamera;

    public Action<bool> OnTargetPosition = delegate { };
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        if (_startOnPeggle)
        {
            _targetPosition = _pegglePosition;
        }
        else
        {
            _targetPosition = _cardPosition;
        }
        _mainCamera.transform.position = _targetPosition;

    }
    private void Update()
    {
        if(_mainCamera.transform.position != _targetPosition)
        {
            if(Vector3.Distance(_mainCamera.transform.position, _targetPosition) > 0.25f)
            {
                //lerp
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _targetPosition, _lerpSpeed * Time.deltaTime);
            }
            else
            {
                _mainCamera.transform.position = _targetPosition;

                if (_targetPosition == _pegglePosition)
                    OnTargetPosition?.Invoke(true);
                if (_targetPosition == _cardPosition)
                    OnTargetPosition?.Invoke(false);
            }
        }
    }
    public bool CheckIfOnPeggleState()
    {
        if (_targetPosition == _pegglePosition)
            return true;
        else
            return false;
    }
    public void SwapToPeggle()
    {
        _targetPosition = _pegglePosition;
    }
    public void SwapToCard()
    {
        _targetPosition = _cardPosition;
    }
}
