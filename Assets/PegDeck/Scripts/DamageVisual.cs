using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageVisual : MonoBehaviour
{
    [SerializeField] private Image _damageImage;
    [SerializeField] private float _fadeSpeed;

    private bool _isVisible = false;
    private float _progress;

    private void Start()
    {
        if(_damageImage != null) DisableVisual();
    }
    private void Update()
    {
        if (_isVisible)
        {
            if(_damageImage != null)
            {
                _progress -= Time.deltaTime;

                _damageImage.color = General.GetModifiedOpacity(_damageImage.color, _progress);

                if (_progress <= 0)
                {
                    _damageImage.color = General.GetModifiedOpacity(_damageImage.color, 1.0f);
                    DisableVisual();
                }
            }
            
        }
    }

    public void DisableVisual()
    {
        _isVisible = false;
        if(_damageImage != null) _damageImage.gameObject.SetActive(false);
    }
    public void EnableVisual()
    {
        _progress = 1.0f;
        if(_damageImage != null) _damageImage.gameObject.SetActive(true);
        _isVisible = true;
    }
}
