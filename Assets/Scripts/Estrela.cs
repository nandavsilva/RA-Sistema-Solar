using UnityEngine;
using System.Collections;

public class Estrela : MonoBehaviour {
    public Light lt;
    public float duracao = 1.0F; 

	void Start () {
        lt = GetComponent<Light>();
    }
	
	void Update () {
        float pi = Time.time / duracao * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(pi) * 0.5F + 0.5F;
        lt.intensity = amplitude;
	}
}
