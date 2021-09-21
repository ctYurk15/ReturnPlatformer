using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] string enemy_tag = "Enemy";
    [SerializeField] float delay = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(enemy_tag))
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;

        Invoke("ReloadLevel", delay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
