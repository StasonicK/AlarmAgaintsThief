using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    private void CoinJumped()
    {
        Destroy(gameObject);
    }
}