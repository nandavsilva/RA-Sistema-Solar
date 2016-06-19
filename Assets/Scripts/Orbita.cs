using UnityEngine;
using System.Collections;

public class Orbita : MonoBehaviour {
    public int particula;
    public float raioX;
    public float raioY;
    public static LineRenderer linha;
    public static Transform target;

    void Start () {
        linha = gameObject.GetComponent<LineRenderer>();
        linha.SetVertexCount(particula + 1);
        linha.useWorldSpace = false;
        CreatePoints();
        transform.Rotate(270, 0, 0);
    }
	
	void Update () {
        
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angulo = 20f;

        for (int i = 0; i < (particula + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angulo) * raioX;
            y = Mathf.Cos(Mathf.Deg2Rad * angulo) * raioY;

            linha.SetPosition(i, new Vector3(x, y, z) );

            angulo += (360f / particula);

        }

    }
}
