using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem healthSystem {get; private set; }
    
    [Header ("Health")]
    public int Maxhealth = 10;

    [Header ("Health Bar")]
    public HealthBar healthBar;
    //
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Maxhealth;
        healthBar.SetMaxHealth(Maxhealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
        healthBar.SetHealth(currentHealth);
    }
}
