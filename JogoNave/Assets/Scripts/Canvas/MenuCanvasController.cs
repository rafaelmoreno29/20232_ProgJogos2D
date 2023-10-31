using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject panelPrincipal;
    [SerializeField]
    GameObject panelSobre;

    // Start is called before the first frame update
    void Start()
    {
        panelPrincipal.SetActive(true);
        panelSobre.SetActive(false);
    }
    public void AbrirPanelPrincipal()
    {
        panelPrincipal.SetActive(true);
        panelSobre.SetActive(false);
    }
    public void AbrirPanelSobre()
    {
        panelPrincipal.SetActive(false);
        panelSobre.SetActive(true);
    }
    public void AbrirFase1()
    {
        SceneManager.LoadScene(1);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
