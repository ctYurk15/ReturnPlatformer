using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] string enemy_tag = "Enemy";
    [SerializeField] float delay = 1f;
    [SerializeField] float minBorderY = -5f;
    [SerializeField] AudioSource deadSound;


    bool dead = false;

    void Update()
    {
        if (transform.position.y <= minBorderY && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(enemy_tag))
        {
            //making player invisible
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;

            Die();
        }
    }

    void Die()
    {
        deadSound.Play();
        Invoke("ReloadLevel", delay);
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
