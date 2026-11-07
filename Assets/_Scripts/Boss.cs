using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{

    public void Awake()
    {
        vida = 250;
        _dano = 50;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigosJefeDerrotados++;
    }
}
