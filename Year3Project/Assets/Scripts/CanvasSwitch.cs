using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    public Canvas canvas;
    bool canvasOff;
    // Start is called before the first frame update
    void Start()
    {
        canvasOff = false;
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canvasOff)
            {
                canvasOff = false;
                canvas.gameObject.SetActive(true);
            }
            else if (!canvasOff)
            {
                canvasOff = true;
                canvas.gameObject.SetActive(false);
            }
        }
    }
}
