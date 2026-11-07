using UnityEngine;
using UnityEngine.AI;

public class Sandi : EnemigoBase
{

    public void Awake()
    {
        vida = 45;
        _dano = 50;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.EnemigosBaseDerrotados++;
    }

}
