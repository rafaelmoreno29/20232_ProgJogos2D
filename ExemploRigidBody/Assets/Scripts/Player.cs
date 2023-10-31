using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float velocidade = 10f;
    Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject check = GameObject.Find("checkground");
        Debug.DrawRay(check.transform.position, Vector2.down, Color.green, 0.2f);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rg.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }

        //rotacionando o player
        if (Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

    }

    private bool IsGrounded()
    {
        GameObject check = GameObject.Find("checkground");
        var groundCheck = Physics2D.Raycast(check.transform.position, Vector2.down, 0.2f);

        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }

    private void FixedUpdate()
    {
        rg.velocity = new Vector3(Input.GetAxis("Horizontal") * velocidade, rg.velocity.y, 0);
    }

}
