using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellLightHandler : MonoBehaviour
{

    public GameObject lightSource = null;
    private Light lightComponent = null;

    public bool destroyOnProb = true;
    [Range(0.0f, 1.0f)]
    public float probToDestroy = 0.5f;

    //https://docs.unity3d.com/Manual/ExecutionOrder.html
    private void Awake()
    {

        if (this.lightSource == null) 
            throw new MissingComponentException("CellLightHandler requiere un GameObject con componente 'Light' adjunto ");
        lightComponent = lightSource.GetComponentInChildren<Light>();
        if(this.lightComponent == null) 
            throw new MissingComponentException("CellLightHandler requiere un GameObject con componente 'Light' adjunto.El GameObject existe pero no se encuentra en él ningún componente 'Light'");

        if (Random.value < probToDestroy && destroyOnProb)
            this.lightSource.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
