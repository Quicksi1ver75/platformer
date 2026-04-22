using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Coin_Component : MonoBehaviour
{
    private float wallet = 0;

    public float maxcoin = 10;

    public delegate void CoinInitializedHandler(float newCoin);

    public delegate void CoinChangeHandler(float newCoin, float amountChanged);

    public event CoinChangeHandler OnCoinChanged;

    public event CoinInitializedHandler OnCoinInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {

        OnCoinInitialized?.Invoke(wallet);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddCoin(float StealValue)

    {

        wallet += StealValue;

        if (wallet >= maxcoin)

        {

            wallet = maxcoin;

        }
    }

}
