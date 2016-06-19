using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Painel : MonoBehaviour {

	public Toggle caixaOrbita;
	public Toggle caixaTrans;
	public Text textoValor;
	public InputField valor;
	public Button botaoOk;
	public Button botaoVoltar;
	public static GameObject meorb;
	public static GameObject vnorb;
	public static GameObject trorb;
	public static GameObject mtorb;
	public static GameObject jporb;
	public static GameObject storb;
	public static GameObject urorb;
	public static GameObject neorb;
	float VelTransPadrao, VelTransAtual, NovaVelTranslacao;
	string Trans;

	void Awake() {
		meorb = GameObject.Find("Rotacionar/MercurioOrbita");
		vnorb = GameObject.Find("Rotacionar/VenusOrbita");
		trorb = GameObject.Find("Rotacionar/TerraOrbita");
		mtorb = GameObject.Find("Rotacionar/MarteOrbita");
		jporb = GameObject.Find("Rotacionar/JupiterOrbita");
		storb = GameObject.Find("Rotacionar/SaturnoOrbita");
		urorb = GameObject.Find("Rotacionar/UranoOrbita");
		neorb = GameObject.Find("Rotacionar/NetunoOrbita");
		meorb.SetActive (true);
		vnorb.SetActive (true);
		trorb.SetActive (true);
		mtorb.SetActive (true);
		jporb.SetActive (true);
		storb.SetActive (true);
		urorb.SetActive (true);
		neorb.SetActive (true);
	}

	void Start () {
		caixaOrbita.isOn = true;
		caixaTrans.isOn = false;
		textoValor.gameObject.SetActive (false);
		valor.gameObject.SetActive (false);
		botaoOk.gameObject.SetActive (false);
		botaoVoltar.gameObject.SetActive (false);

		VelTransPadrao = 20f;
	}

	void Update () {
		if (caixaOrbita.isOn == true) {
			meorb.SetActive (true);
			vnorb.SetActive (true);
			trorb.SetActive (true);
			mtorb.SetActive (true);
			jporb.SetActive (true);
			storb.SetActive (true);
			urorb.SetActive (true);
			neorb.SetActive (true);
		} else {
			meorb.SetActive (false);
			vnorb.SetActive (false);
			trorb.SetActive (false);
			mtorb.SetActive (false);
			jporb.SetActive (false);
			storb.SetActive (false);
			urorb.SetActive (false);
			neorb.SetActive (false);
		}

		if (caixaTrans.isOn == true) {
			textoValor.gameObject.SetActive (true);
			valor.gameObject.SetActive (true);
			botaoOk.gameObject.SetActive (true);
			botaoVoltar.gameObject.SetActive (true);
		} else {
			textoValor.gameObject.SetActive (false);
			valor.gameObject.SetActive (false);
			botaoOk.gameObject.SetActive (false);
			botaoVoltar.gameObject.SetActive (false);
		}
	}

	public void calcularTranslacao() {
		if (valor.text == "")
			NovaVelTranslacao = Sol.valorPadraoTrans;
		else
			Trans = CleanStringForFloat (valor.text);

		NovaVelTranslacao = float.Parse(Trans);
		Sol.valorPadraoTrans = NovaVelTranslacao;
	}

	public void resetarTranslacao() {
		valor.text = "";
		Sol.valorPadraoTrans = VelTransPadrao;
		textoValor.gameObject.SetActive (false);
		valor.gameObject.SetActive (false);
		botaoOk.gameObject.SetActive (false);
		botaoVoltar.gameObject.SetActive (false);
		caixaTrans.isOn = false;
	}

	public static string CleanStringForFloat(string input) {
		if (Regex.Match (input, @"^-?[0-9]*(?:\.[0-9]*)?$").Success)
			return input;
		else {
			Debug.LogError ("Erro, Float ruim " + input);
			return "0";
		}
	}

	public void MudarCena(string nomeCena) {
		SceneManager.LoadScene(nomeCena);
	}
		
}
