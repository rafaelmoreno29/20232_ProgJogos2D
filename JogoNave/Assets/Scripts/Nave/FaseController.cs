using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseController : MonoBehaviour
{
    public static int faseAtual;

    // Start is called before the first frame update
    void Start()
    {
        faseAtual = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mudarFase")
        {
            faseAtual++;
            GetComponent<NaveController>().mudarPosicaoSpawn(collision.transform.position);
            if (faseAtual == 3)
                SceneManager.LoadScene(faseAtual, LoadSceneMode.Additive);
            else
                SceneManager.LoadScene(faseAtual, LoadSceneMode.Single);
        }
    }
}
