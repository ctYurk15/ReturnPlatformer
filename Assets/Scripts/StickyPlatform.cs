using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    [SerializeField] GameObject acceptedGameObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == acceptedGameObject.name)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == acceptedGameObject.name)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
