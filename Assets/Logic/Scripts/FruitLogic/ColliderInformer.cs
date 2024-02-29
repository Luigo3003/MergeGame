using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn = false;

    private bool _hasCollided = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombinedIn )
        {
            _hasCollided = true;
            ThrowFruitController.instance.CanThrow = true;
            ThrowFruitController.instance.SpawnAfruit(FruitSelector.instance.NextFruit);
            FruitSelector.instance.PickNextFruit();
            Destroy(this);
        }
    }
}
