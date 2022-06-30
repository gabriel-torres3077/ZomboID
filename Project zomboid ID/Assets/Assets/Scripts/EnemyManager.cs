using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        Animator zombie_animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        zombie_animator.SetBool("isAwake", true);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
