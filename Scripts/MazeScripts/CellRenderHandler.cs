using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRenderHandler : MonoBehaviour
{
    private Renderer render = null;
    private MeshRenderer meshRender = null;
    // Start is called before the first frame update
    void Start()
    {
        render = this.GetComponentInChildren<Renderer>();
        meshRender = this.GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
