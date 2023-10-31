using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField]
    GameObject inimigoPrefab;
    [SerializeField]
    int tempoSpawn;
    [SerializeField]
    int tempoInicialSpawn;
    [SerializeField]
    float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CriarInimigo", tempoInicialSpawn, tempoSpawn);
    }
    void CriarInimigo()
    {
        GameObject inimigo = Instantiate(inimigoPrefab, gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rg = inimigo.GetComponent<Rigidbody2D>();
        rg.AddForce(transform.right * -1 * velocidade, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
