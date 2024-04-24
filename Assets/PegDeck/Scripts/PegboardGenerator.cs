using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegboardGenerator : MonoBehaviour
{
    [SerializeField] List<Peg> _pegs = new List<Peg>();
    [SerializeField] int _spacing = 1;
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
        _maxY = _topLeft.position.y;
        //testing
        GeneratePegs();
    }

    public void GeneratePegs()
    {
        _placementTransform = _topLeft;
        for (float i = _minY; i <= _maxY; i += _spacing)
        {
            for (float j = _minX; j <= _maxX; j += _spacing)
            {
                _placementTransform.position = new Vector2(j, i);
                var pegIndex = Random.Range(0, _pegs.Count);
                Instantiate(_pegs[pegIndex], _placementTransform.position, Quaternion.identity);
            }
        }
    }
}
