using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseCanvasController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPontuacao;
    [SerializeField]
    GameObject panelCentral;

    void Start()
    {

        panelCentral.SetActive(false);
    }
    void Update()
    {
        textPontuacao.SetText("Score: " + NaveController.pontuacao);
    }
    public void Sair()
    {
        Destroy(GameObject.Find("nave").gameObject);
        Destroy(GameObject.Find("Canvas").gameObject);
        Destroy(GameObject.Find("EventSystem").gameObject);

        Time.timeScale = 1;
        NaveController.pontuacao = 0;
        SceneManager.LoadScene(0);
    }
    public void ChamarPanelMenu()
    {
        if (PanelMenuVisivel())
        {
            Time.timeScale = 1;
        }
        panelCentral.SetActive(!panelCentral.activeSelf);

    }
    public bool PanelMenuVisivel()
    {
        return panelCentral.activeSelf;
    }

}
