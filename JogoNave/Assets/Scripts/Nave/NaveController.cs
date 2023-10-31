using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NaveController : MonoBehaviour
{
    public static int pontuacao;
    private Rigidbody2D rigidbody;
    private Animator animator;
    [SerializeField]
    float velocidadeNave;
    [SerializeField]
    GameObject tiroPrefab;
    [SerializeField]
    GameObject spawnTiro;
    private Vector3 posicaoSpawn;
    private GameObject canvas;

    [SerializeField]
    private AudioClip clipExplosao;
    [SerializeField]
    private AudioClip clipTiro;
    private AudioSource audioSource;
    private GameObject eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        eventSystem = GameObject.Find("EventSystem");
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSystem);
        pontuacao = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        posicaoSpawn = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public static void AtualizarPontuacao()
    {
        pontuacao++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "inimigo")
        {
            animator.Play("Destroying");
            audioSource.PlayOneShot(clipExplosao, 1f);
            Destroy(collision.gameObject);
        }
    }

    public void Reiniciar()
    {
        transform.position = posicaoSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        float velocidade = Mathf.Abs(Input.GetAxis("Horizontal"))
            + Mathf.Abs(Input.GetAxis("Vertical"));
        animator.SetFloat("velocidade", velocidade);


        //Rotação da Nave
        if (Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Fire1")
            && canvas.GetComponent<FaseCanvasController>().PanelMenuVisivel() == false)
        {
            Atirar();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            canvas.GetComponent<FaseCanvasController>().ChamarPanelMenu();

            if (canvas.GetComponent<FaseCanvasController>().PanelMenuVisivel())
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void Atirar()
    {
        Instantiate(tiroPrefab, spawnTiro.transform.position, transform.rotation);
        audioSource.PlayOneShot(clipTiro, 1f);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * velocidadeNave,
            Input.GetAxis("Vertical") * velocidadeNave);
    }

    public void mudarPosicaoSpawn(Vector3 novaPosicaoSpawn)
    {
        posicaoSpawn = novaPosicaoSpawn;
    }

}
