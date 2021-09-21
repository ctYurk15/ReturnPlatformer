using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

    void Update()
    {
        transform.Rotate(new Vector3(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime));
    }
}
