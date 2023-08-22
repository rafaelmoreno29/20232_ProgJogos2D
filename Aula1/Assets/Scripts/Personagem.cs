using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    [SerializeField]
    KeyCode teclaPular;
    [SerializeField]
    float velocidade;
    [SerializeField]
    int qtdeMoedas;

    Vector3 posicaoInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
        qtdeMoedas = 0;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal,vertical,0)
            * velocidade * Time.deltaTime);

        /*
        if (Input.GetKeyDown(teclaPular))
        {
            Debug.Log("Space down");
        }
        if (Input.GetKey(teclaPular))
        {
            Debug.Log("Space pressed");
        }
        if (Input.GetKeyUp(teclaPular))
        {
            Debug.Log("Space up");
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entrou na colisão");
        if(collision.gameObject.tag == "moeda")
        {
            qtdeMoedas++;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "inimigo")
        {
            transform.position = posicaoInicial;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Está colidindo");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Saiu da colisão");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrou trigger");
        posicaoInicial = collision.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Está na trigger");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Saiu trigger");
    }
}
