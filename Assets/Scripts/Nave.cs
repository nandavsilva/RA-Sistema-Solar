using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour {
	/*
	Fazer:
	1 - Movimentar a nave para qualquer lado; - ok
	2 - Colocar uma colisao com o planeta quando chegar la - no Planeta ok
	*/
	Camera cam;
	float velocidade;
	float velocidadeLateral;
	float velocidadeRotacao;
	float velocidadeTranslacao;
	//Vector3 teste;
	public static Rigidbody rb;
	public static Vector3 velocidadeAtual;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		velocidade = 30f;
		velocidadeLateral = 30f;
		//velocidadeRotacao = 50 * Time.deltaTime;
		//velocidadeTranslacao = 10 * Time.deltaTime;
	}

	void Update () {
		//teste = transform.forward;
		velocidadeAtual = velocidadeAtual * 0f;
		mover ();
	}

	void mover() {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
			velocidadeAtual = velocidadeAtual + (-velocidade * transform.up);
			transform.eulerAngles = new Vector3 (180, 270, 0);
			//transform.Translate(Vector3.forward * velocidadeTranslacao);
		} else {
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
				velocidadeAtual = velocidadeAtual + (velocidade * transform.up);
				transform.eulerAngles = new Vector3 (-90, 270, 0);
				//transform.Translate(-Vector3.forward * velocidadeTranslacao);
			}
		}

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			velocidadeAtual = velocidadeAtual + (-velocidadeLateral * transform.right);
			transform.eulerAngles = new Vector3 (270, 180, 0);
			//transform.Rotate(Vector3.right, velocidadeRotacao);
		} else {
			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
				velocidadeAtual = velocidadeAtual + velocidadeLateral * transform.right;
				transform.eulerAngles = new Vector3 (270, 360, 0);
				//transform.Rotate(Vector3.right, -velocidadeRotacao);
			}
		}

		if (Input.GetKey (KeyCode.Space)) {
			velocidadeAtual = velocidadeAtual * 0f;
		}
			
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) ||
			Input.GetKeyDown(KeyCode.UpArrow) ||  Input.GetKeyDown(KeyCode.DownArrow) ||  Input.GetKeyDown(KeyCode.LeftArrow) ||  
			Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey (KeyCode.Space)) {
				rb.velocity = velocidadeAtual;
		}
			
	}
		
	void OnCollisionEnter(Collision collider) {
		if(collider.gameObject.tag == "Planeta") {
			//collider.gameObject.SendMessage ("verficarZoom", SendMessageOptions.DontRequireReceiver);
			collider.gameObject.SendMessage ("AtivarProp", SendMessageOptions.DontRequireReceiver);
			rb.velocity = velocidadeAtual * 0f;
		}
	}

	void OnCollisionExit(Collision collider) {
		collider.gameObject.SendMessage ("DesativarProp", SendMessageOptions.DontRequireReceiver);
	}

}
