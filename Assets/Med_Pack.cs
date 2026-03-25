using UnityEngine;

public class Med_Pack : MonoBehaviour
{
    public float heal = 2;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<health_component>().AddHealth(heal);
        Destroy(gameObject);
    }
   
}
