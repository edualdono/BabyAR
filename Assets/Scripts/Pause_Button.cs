using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Button : MonoBehaviour
{
    public Button Boton;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        Boton.onClick.AddListener(Activar);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activar()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
        
}
