using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Thief _thief;

    private void CoinJumped()
    {
        Destroy(gameObject);
    }
}
