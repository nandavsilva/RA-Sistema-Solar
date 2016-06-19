using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Planeta : MonoBehaviour
{
    public Transform pai;
    public Transform planeta;
	Transform planeta2, planeta3;
    public float velRotacao;
    public float velTranslacao;
	bool zoom = false;
    public bool voltarAtivado = false;
    public Camera cam;
    bool label = false;
	bool label2 = false;
	bool texto = false;
	public Texture image;
	Texture image2;
    GUIStyle estilo;
    float delay = 5f;
	float inicioZoom;
	float maximoZoom;
	float valorZoom;
	bool verTrans = true;
	string nome;
	public static GameObject[] planetas;

    //Informar o nome do planeta - ok
    //Fazer o zoom quando clicar uma vez no planeta e se aproximar do planeta exibindo as suas informações - ok
    //Clicando novamente fazer o zoom de volta ao sistema solar - ok
    //Tratar a rotacão e translacao aqui - ok

	void Awake() {
		inicioZoom = cam.orthographicSize;
		valorZoom = inicioZoom;
	}

    void Start() {
        estilo = new GUIStyle();
        estilo.fontSize = 30;
		estilo.normal.textColor = Color.white;
		maximoZoom = 25f;
    }

    void Update() {

		transform.Rotate(0, (1/velRotacao * Sol.valorPadraoRot) * Time.deltaTime, 0);
        
		if(verTrans)
			transform.RotateAround(pai.position, transform.up, (365/velTranslacao * Sol.valorPadraoTrans) * Time.deltaTime);

		//Debug.Log(planeta.name + ": " + (365/velTranslacao) * Rotacao.valorPadraoTrans);
		//verificarZoom ();
    }
		
	void OnCollisionEnter(Collision collider) {
		AtivarProp ();
		if(collider.gameObject.tag == "Player") {
			zoom = true;
			//verificarZoom ();
			Nave.rb.velocity = Nave.velocidadeAtual * 0f;
		}
	}

	void OnCollisionExit(Collision collider) {
		DesativarProp ();
		zoom = false;
		//verificarZoom ();
	}

	void OnMouseOver() {
		//AtivarProp ();
	}

    void OnMouseExit() {
		//DesativarProp ();
    }

	void OnMouseEnter() {
		//AtivarProp ();
	}

	void OnMouseDown() {
	}

    void OnGUI() {
        if(label) 
			GUI.Box(new Rect(500, 50, 100, 50), nome, estilo);
		if(label2) 
			GUI.Box(new Rect(500, 50, 100, 50), planeta.name, estilo);
		if (texto)
			GUI.Label(new Rect(0,10,256,512), image2);
    }

	/*
	void verificarZoom() {
		/*
		if (Input.GetMouseButtonDown(0)) {
			if (transform.tag == "Planeta")
				zoom = !zoom;
			else
				zoom = false;
		}

		Debug.Log (zoom);
		PerformanceZoom ();
		ZoomPlaneta ();
	}

	void ZoomPlaneta() {
		if (zoom) {
			valorZoom = Mathf.Lerp(valorZoom, maximoZoom, delay * Time.deltaTime);
			Debug.Log ("Com Zoom: " + valorZoom);
			cam.transform.LookAt(planeta2);
			verTrans = false;
			label = true;
			texto = true;
			voltarAtivado = true;
		} else {
			voltarAtivado = false;
			valorZoom = Mathf.Lerp(valorZoom, inicioZoom, delay * Time.deltaTime);
			Debug.Log ("Sem Zoom: " + valorZoom);
			cam.transform.LookAt (pai);
			verTrans = true;
			label = false;
			texto = false;
		}
	}

	void PerformanceZoom() {
		cam.orthographicSize = valorZoom;
		Debug.Log ("Camera: " + cam.orthographicSize);
		valorZoom = Mathf.Clamp (valorZoom, maximoZoom, inicioZoom);
	}
*/
	void AtivarProp() {
		//label = true;
		label2 = true;
		texto = true;
		//zoom = true;
		verTrans = false;
		voltarAtivado = true;
		planeta2 = planeta;
		image2 = image;
		nome = planeta2.name;
	}

	void DesativarProp() {
		//label = false;
		label2 = false;
		texto = false;
		//zoom = false;
		verTrans = true;
		voltarAtivado = false;
		planeta2 = null;
		image2 = null;
		nome = null;
	}
		
}