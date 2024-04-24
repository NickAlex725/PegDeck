using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegboardGenerator : MonoBehaviour
{
    [SerializeField] List<Peg> _pegs = new List<Peg>();
    [SerializeField] int _spacing;
    [SerializeField] Transform _topLeft;
    [SerializeField] Transform _bottonLeft;
    [SerializeField] Transform _topRight;
    [SerializeField] Transform _bottonRight;

    private Transform _placementTransform;
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private void Start()
    {
        _minX = _topLeft.position.x;
        _maxX = _topRight.position.x;
        _minY = _bottonLeft.position.y;
        _maxY = _topLeft.position.x;
        //testing
        GeneratePegs();
    }

    public void GeneratePegs()
    {
        _placementTransform = _topLeft;
        for (float i = _minX; i <= _maxX; i += 1)
        {
            _placementTransform.position = new Vector2(i, 7.5f);
            Instantiate(_pegs[0], _placementTransform.position, Quaternion.identity);
        }
    }
}
