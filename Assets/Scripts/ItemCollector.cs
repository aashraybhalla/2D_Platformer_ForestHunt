using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int collectible = 0;

    [SerializeField] private Text collectibleText;
    [SerializeField] private AudioSource collectionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectible"))
        {
            Destroy(collision.gameObject);
            collectible++;
            collectibleText.text = "BOTTLES : " + collectible;
            collectionSound.Play();
        }
    }
}
