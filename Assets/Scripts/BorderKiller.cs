using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderKiller : MonoBehaviour
{
    [SerializeField] float minBorderY = -5f;
    PlayerLife playerLife;

    void Start()
    {
        playerLife = GetComponent<PlayerLife>();
    }

    void Update()
    {
        if(transform.position.y <= minBorderY)
        {
            playerLife.Die();
        }
    }
}
