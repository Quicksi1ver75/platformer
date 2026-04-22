using TMPro;
using UnityEngine;

public class UI_Coin_Display : MonoBehaviour
{
    public Coin_Component coinComponent;

    public TextMeshProUGUI textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

       coinComponent.OnCoinChanged += OnCoinChanged;

       coinComponent.OnCoinInitialized += OnCoinInitialized;

    }

    private void OnCoinInitialized(float newCoin)

    {

        textComponent.text = newCoin.ToString();

    }

    private void OnCoinChanged(float newCoin, float amountChanged)

    {

        //Debug.Log(newHealth + ":" + amountChanged);

        textComponent.text = newCoin.ToString();

    }



    // Update is called once per frame

    void Update()

    {

    }

}
