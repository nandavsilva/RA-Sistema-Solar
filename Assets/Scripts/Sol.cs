using UnityEngine;
using System.Collections;

public class Sol : MonoBehaviour {
	public float VelRot;
	public Transform pai;
	public float VelTrans;
	public static float valorPadraoRot = 10f;
	public static float valorPadraoTrans = 20f;

	void Start () {
	
	}

	void Update () {
		transform.Rotate(0, VelRot * Time.deltaTime, 0);
		transform.RotateAround(pai.position, transform.up, VelTrans * Time.deltaTime);	
	}
}
