using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController instance;

    public GameObject CurrentFruit { get; set;}
    [SerializeField] private Transform _fruitTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private FruitSelector _selector;



    private PlayerMovement _playerMovement;

    private Rigidbody2D _rb2D;
    private CircleCollider2D _circleCollider2D;

    public Bounds Bounds { get; private set; }

    private const float EXTRA_WIDTH = 0.02F;

    public bool CanThrow { get; set; } = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        SpawnAfruit(_selector.PickRandomFruitToThrow());
    }


    public void Update()
    {
        if (_playerMovement._playerThrowAction == true && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.instance.Fruits[index.Index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(_parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }
    public void SpawnAfruit(GameObject fruit)
    {
        GameObject go = Instantiate(fruit, _fruitTransform);
        CurrentFruit = go;
        _circleCollider2D = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider2D.bounds;

        _playerMovement.ChangeBoundary(EXTRA_WIDTH);

    }

}
