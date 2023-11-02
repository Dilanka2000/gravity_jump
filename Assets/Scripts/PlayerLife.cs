using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float health = 0.4f;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Image healthBarTotal;
    [SerializeField] private Image healthBarCurrent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBarTotal.fillAmount = health;
        healthBarCurrent.fillAmount = health;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap")){
            health -= 0.1f;
            if(health >= 0.1f){
                healthBarCurrent.fillAmount = health;
                deathSoundEffect.Play();
            }
            else{
                healthBarCurrent.fillAmount = health;
                Die();
            }
        }
    }

    private void Die(){
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
