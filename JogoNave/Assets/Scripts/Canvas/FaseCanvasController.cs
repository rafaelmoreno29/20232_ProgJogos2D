using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FaseCanvasController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPontuacao;
    [SerializeField]
    GameObject panelCentral;
    [SerializeField]
    Toggle mudo;
    [SerializeField]
    Slider volume;

    public void SalvarPreferencias()
    {
        PlayerPrefs.SetInt("mudo", mudo.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("volume", volume.value);
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("mudo"))
            mudo.isOn = PlayerPrefs.GetInt("mudo") == 1 ? true : false;
        if (PlayerPrefs.HasKey("volume"))
            volume.value = PlayerPrefs.GetFloat("volume");
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
            SalvarPreferencias();
        }
        panelCentral.SetActive(!panelCentral.activeSelf);

    }
    public bool PanelMenuVisivel()
    {
        return panelCentral.activeSelf;
    }

}
