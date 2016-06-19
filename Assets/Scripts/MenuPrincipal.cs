using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public void MudarCena(string nomeCena) {
        SceneManager.LoadScene(nomeCena);
    }

    public void Sair() {
        Application.Quit();
    }



}
