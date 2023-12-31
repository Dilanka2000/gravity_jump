using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int totalCherries = 0;
    private int currentCherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1){
            totalCherries = 12;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2){
            totalCherries = 35;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            totalCherries = 42;
        }
        cherriesText.text = "Cherries: " + currentCherries + "/" + totalCherries;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Cherry")){
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            currentCherries++;
            cherriesText.text = "Cherries: " + currentCherries + "/" + totalCherries;
        }
    }
}



