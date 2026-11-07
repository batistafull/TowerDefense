using UnityEngine;

public class Objetivo : MonoBehaviour
{

    public int vida = 100;

    public delegate void ObjetivoDestruido();
    public event ObjetivoDestruido EnObjetivoDestruido;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            if (EnObjetivoDestruido != null)
            {
                EnObjetivoDestruido();
            }
            Destroy(this.gameObject, 0.2f);
        }
    }

    public void RecibirDano(int dano = 20)
    {
        vida -= dano;
    }
}
