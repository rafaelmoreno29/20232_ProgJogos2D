using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.right * 20, ForceMode2D.Impulse);

        InvokeRepeating("RemoverTiro", 3f, 3f);
    }

    void RemoverTiro()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "inimigo")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);       
            NaveController.pontuacao++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
