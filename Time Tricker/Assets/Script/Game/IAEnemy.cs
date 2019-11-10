﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float forceJump;
    public float delayJump;
    public float delayStarMoving;
    public float forceMove;

    private Transform positionPlayer;
    private float directionMove;
    private bool canJump;
    private Rigidbody2D rb;

    void Start()
    {
        positionPlayer = player.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayMoving());
        if (GetComponent<Animator>().GetBool("isMoving"))
        {
            Move();
        }
    }

    private void Move()
    {
        directionMove = positionPlayer.position.x - GetComponent<Transform>().position.x;
        if (directionMove < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //rb.AddForce(-transform.right * forceMove, ForceMode2D.Force);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //rb.AddForce(transform.right * forceMove, ForceMode2D.Force);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canJump)
        {
            canJump = false;
            StartCoroutine(DelayJump());
            Debug.Log("Jump because collision with" + collision.gameObject.name);
            rb.AddForce(transform.up * forceJump, ForceMode2D.Impulse);
        }
    }

    private IEnumerator DelayMoving()
    {
        yield return new WaitForSeconds(delayJump);
        GetComponent<Animator>().SetBool("isMoving", true);
    }

    private IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(delayStarMoving);
        canJump = true;
    }
}