using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public float health = 100;

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

    public void LoseHealth(float value)
    {
        health -= value;

        fillbar.fillAmount = health / 100;

        if (health <=0)
        {
            Die();
            Invoke("RestartLevel", 1f);
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("strap"))
        {
            LoseHealth(34);
        }
    }

    

}
