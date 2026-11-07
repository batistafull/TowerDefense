using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject objetivo;
    public int vida = 100;

    public Animator Anim;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
    }

    private void OnDisable()
    {

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();

        // El objetivo ya fue destruido: el enemigo se queda quieto
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

    public void Danar()
    {
        if (objetivo == null || objetivo.GetComponent<Objetivo>().vida <= 0)
        {
            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjectiveReached");
        }
        else
        {
            objetivo.GetComponent<Objetivo>().RecibirDano(40);
        }
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
