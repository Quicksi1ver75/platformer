using UnityEngine;

public class money : MonoBehaviour
{
    public float steal = 1;
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
        collision.GetComponent<Coin_Component>().AddCoin(steal);
        Destroy(gameObject);
    }
}
