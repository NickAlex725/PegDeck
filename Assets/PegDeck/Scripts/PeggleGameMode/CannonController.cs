using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class CannonController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform _origin;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private TextMeshProUGUI _ballCountText;

    [Header("Settings")]
    [Tooltip("Amount of power used to launch the ball.")]
    [SerializeField] private float _cannonForce = 10f;
    [Tooltip("Minimum distance from cannon where touch is detected.")]
    [SerializeField] private float _buffer = 1f;
    [SerializeField] private Ball _ballPrefab;

    [Header("Ball Settings")]
    public bool ballReady = true;
    public int ballsPerTurn = 2;
    //public float maxBallSpeed = 2;
    public int _remainingBalls;
    public int _extraBalls;

    private InputBroadcaster _input;
    private Camera _mainCamera;

    private Vector2 _pivotPosition;
    private Vector2 _savedDirection = Vector2.down;
    private bool _isPressed = false;

    private void Awake()
    {
        _input = GetComponent<InputBroadcaster>();
        _mainCamera = Camera.main;
        _remainingBalls = ballsPerTurn;
    }
    private void Start()
    {
        _pivotPosition = _origin.position;
        if (_ballCountText != null) _ballCountText.text = _remainingBalls.ToString();
    }
    private void OnEnable()
    {
        _input.OnTouchPress += Press;
    }
    private void OnDisable()
    {
        _input.OnTouchPress -= Press;
    }

    private void Update()
    {
        #region Cannon Rotation
        if (_isPressed)
        {
            if (_origin == null) return;

            Vector2 touchPosition = Touchscreen.current.position.ReadValue();
            Vector2 current = _mainCamera.ScreenToWorldPoint(touchPosition);

            //if not above button and not too close to button
            if(current.y < _pivotPosition.y && Vector3.Distance(current, _pivotPosition) > _buffer)
            {
                Vector2 direction = current - _pivotPosition;
                float angle = Vector3.Angle(direction.normalized, -transform.up) * ((current.x < _pivotPosition.x) ? -1 : 1);

                _origin.rotation = Quaternion.Euler(_origin.rotation.x, _origin.rotation.y, angle);
                //direction.x = Mathf.Clamp(direction.x, -maxBallSpeed, maxBallSpeed);
                //direction.y = Mathf.Clamp(direction.y, -maxBallSpeed, maxBallSpeed);
                _savedDirection = direction;
                Debug.Log(_savedDirection);
                Debug.DrawRay(_pivotPosition, _savedDirection, Color.red);
            }
        }
        #endregion
    }
    private void Press(bool down)
    {
        if (down)
        {
            _isPressed = true;
        }
        else
        {
            _isPressed = false;
        }
    }

    #region Ball Stuff
    public void LaunchBall()
    {
        if (_ballPrefab == null || _ballSpawn == null) return;

        if (ballReady && _remainingBalls > 0)
        {
            Ball ball = Instantiate(_ballPrefab, null);
            ball.transform.position = _ballSpawn.position;
            Rigidbody2D rBody = ball.GetComponent<Rigidbody2D>();
            ballReady = false;
            _remainingBalls--;
            if(_ballCountText != null) _ballCountText.text = _remainingBalls.ToString();

            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.BallLaunch);

            if (rBody != null)
            {
                rBody.velocity = Vector3.zero;
                rBody.AddForce(_savedDirection.normalized * _cannonForce, ForceMode2D.Force);
            }
        }
    }
    public void LaunchReady()
    {
        ballReady = true;
        if (_ballCountText != null) _ballCountText.text = _remainingBalls.ToString();
    }
    public void ResetCannon()
    {
        ballReady = true;
        _remainingBalls = ballsPerTurn + _extraBalls;
        if (_ballCountText != null) _ballCountText.text = _remainingBalls.ToString();
    }
    public void GainExtraBall()
    {
        _extraBalls++;
    }
    #endregion
}
