using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public GameObject player;
    public Animator zombie_animator;

    public float damage = 24f;
    public float health = 100f;

    void Start()
    {
        Animator zombie_animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");


    }


    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            zombie_animator.SetBool("isAwake", true);
        }
        else
        {
            zombie_animator.SetBool("isAwake", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //destroy zombie object
            Destroy(gameObject);
        }
    }
}
