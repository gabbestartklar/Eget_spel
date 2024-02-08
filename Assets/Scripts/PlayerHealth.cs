using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthbar;
    private float healthAmount = 100f;
    public Slider healthSlider;
    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        healthSlider.maxValue = healthAmount;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthSlider.value = healthAmount;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("tar skada :)");
        healthAmount -= damage;
        StartCoroutine(UpdateHealthBar());

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    IEnumerator UpdateHealthBar()
    {
        float elapsedTime = 0f;
        float duration = 0.5f;  

        while (elapsedTime < duration)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, healthAmount, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        healthSlider.value = healthAmount;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolliderar med n�got");  

        if ((collision.gameObject.CompareTag("Spikes")) || (collision.gameObject.CompareTag("SpikeMan")) || (collision.gameObject.CompareTag("Bottom")) || collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
}






