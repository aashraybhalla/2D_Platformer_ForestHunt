using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining = 3;

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Die()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("Death");


    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseLife()
    {
        livesRemaining--;

        lives[livesRemaining].enabled= false;

        if (livesRemaining <= 0)
        {
            Die();
            Invoke("RestartLevel", 1f);
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("strap"))
        {
            LoseLife();
        }
    }

    
}
