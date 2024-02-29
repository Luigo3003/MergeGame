using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private BoxCollider2D _boundaries;
    [SerializeField] private Transform _fruitThrowTransform;

    private ThrowFruitController _fruitController;
    private PlayerInput _playerInput;
    private Rigidbody2D _RB2D;
    public bool _playerThrowAction = false;

    private Bounds _bounds;

    private float _leftBound;
    private float _rightBound;

    private float _startingLeftBound;
    private float _startingRightBound;

    private float _offset;

    private void Awake()
    {
        _bounds = _boundaries.bounds;

        _offset = transform.position.x - _fruitThrowTransform.position.x;

        _leftBound = _bounds.min.x + _offset;
        _rightBound = _bounds.max.x + _offset;

        _startingLeftBound = _leftBound;
        _startingRightBound = _rightBound;

        _playerInput = new PlayerInput();
        _fruitController = GetComponent<ThrowFruitController>();
        _RB2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _playerInput.Enable();

        _playerInput.Player.Move.performed += movePlayer;
        _playerInput.Player.Move.canceled += stopPlayer;
        _playerInput.Player.Throw.performed += ThrowFruit;
        _playerInput.Player.Throw.canceled += RefreshFruitThrower;
    }

    void Update()
    {
        
    }


    private void movePlayer(InputAction.CallbackContext callbackContext)
    {
        Vector2 direction = new Vector2(_playerInput.Player.Move.ReadValue<float>(),0);
        _RB2D.AddForce(direction * speed);
    }

    private void stopPlayer(InputAction.CallbackContext callbackContext)
    {
        _RB2D.velocity = Vector2.zero;
    }

    private void ThrowFruit(InputAction.CallbackContext callbackContext)
    {
        _playerThrowAction = true;
        _fruitController.Update();
    }

    public void ChangeBoundary(float extraWidth)
    {
        _leftBound = _startingLeftBound;
        _rightBound = _startingRightBound;

        _leftBound += ThrowFruitController.instance.Bounds.extents.x + extraWidth;
        _rightBound += ThrowFruitController.instance.Bounds.extents.x + extraWidth;
    }

    private void RefreshFruitThrower(InputAction.CallbackContext callbackContext)
    {
        _playerThrowAction = false;
    }

}
