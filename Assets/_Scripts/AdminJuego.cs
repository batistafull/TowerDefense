using UnityEngine;

public class AdminJuego : MonoBehaviour
{
    public int EnemigosBaseDerrotados;
    public int enemigosJefeDerrotados;
    public int recursos;

    public delegate void RecursosModificados();
    public event RecursosModificados EnRecursosModificados;

    public void ModificarRecursos(int modificacion)
    {
        recursos += modificacion;
        if(EnRecursosModificados != null)
        {
            EnRecursosModificados();
        }
    }

    public void ResetValores()
    {
        EnemigosBaseDerrotados = 0;
        enemigosJefeDerrotados = 0;
    }
}
