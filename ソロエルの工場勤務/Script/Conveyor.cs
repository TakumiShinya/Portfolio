using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * 0.5f;
        mesh.material.SetTextureOffset("_MainTex",new Vector2(0,offset));
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.Translate(transform.forward * 2.0f * Time.deltaTime);
    }
}
