using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private ThiefController _thiefController;

    private void CoinGained()
    {
        _thiefController.ChestReached();
        Destroy(gameObject);
    }
}
