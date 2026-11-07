using UnityEngine;
using UnityEngine.AI;

public class Sierra : EnemigoBase
{

    public void Awake()
    {
        vida = 100;
        _dano = 40;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.EnemigosBaseDerrotados++;
    }

}
