using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour, IAtacante, IAtacable
{

    public GameObject objetivo;
    public int vida = 100;
    public int _dano = 5;
    public int RecursosGanados = 200;

    public AdminJuego referenciaAdminJuego;
    public SpawnerEnemigos referenciaSpawner;
    public Animator Anim;

    private Objetivo scriptObjetivo;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
        referenciaAdminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        referenciaSpawner = GameObject.Find("SpawnerEnemigos").GetComponent<SpawnerEnemigos>();

        if (objetivo != null)
        {
            scriptObjetivo = objetivo.GetComponent<Objetivo>();
            scriptObjetivo.EnObjetivoDestruido += Detener;
        }
    }

    private void OnDisable()
    {
        if (scriptObjetivo != null)
        {
            scriptObjetivo.EnObjetivoDestruido -= Detener;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();

        if (objetivo == null)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            Anim.SetBool("IsMoving", false);
            return;
        }

        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Anim.SetTrigger("OnDeath");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(gameObject, 3);
        }
    }

    public virtual void OnDestroy()
    {
        if (referenciaAdminJuego != null) referenciaAdminJuego.ModificarRecursos(RecursosGanados);
        if (referenciaSpawner != null) referenciaSpawner.EnemigosGenerados.Remove(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshAgent>().isStopped = true;
            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjectiveReached");
        }
    }

    public void Danar(int dano)
    {
        if(dano == 0) dano = _dano;
        if (scriptObjetivo != null) scriptObjetivo.RecibirDano(dano);
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }

    private void Detener()
    {
        if (Anim == null) Anim = GetComponent<Animator>();

        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        if (agente.isOnNavMesh)
        {
            agente.isStopped = true;
            agente.ResetPath();
        }
        agente.velocity = Vector3.zero;

        Anim.SetBool("IsMoving", false);
        Anim.SetTrigger("OnObjectiveDestroyed");
    }

}
