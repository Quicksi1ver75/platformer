

using UnityEngine;

public class Health_Component : MonoBehaviour

{

    private float health = 10;

    public float maxHealth = 10;

    public delegate void OnHealthInitializedHandler(float newHealth);

    public delegate void OnHealthChangeHandler(float newHealth, float amountChanged);

    public event OnHealthChangeHandler OnHealthChanged;

    public event OnHealthInitializedHandler OnHealthInitialized;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        OnHealthInitialized?.Invoke(health);

    }

    // Update is called once per frame

    void Update()

    {

    }

    public void AddDamage(float damage)

    {

        health -= damage;

        //Debug.Log(health);

        if (health <= 0)

        {

            Destroy(gameObject);

        }

        OnHealthChanged?.Invoke(health, damage);

    }

    public void AddHealth(float HealingValue)

    {

        health += HealingValue;

        if (health >= maxHealth)

        {

            health = maxHealth;

        }

        OnHealthChanged?.Invoke(health, HealingValue);

        Debug.Log(health);

    }

}

