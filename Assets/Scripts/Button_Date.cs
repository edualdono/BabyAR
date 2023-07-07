using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Button_Date : MonoBehaviour
{
    [SerializeField] private TMP_Text Fecha;
    [SerializeField] private Button ButtonDate;
    [SerializeField] private TMP_Text Comentarios;
    [SerializeField] private GameObject Panel;

    //private bool flag;
    private DateTime currentDate;
    private DateTime fecha;
    public TimeSpan timeDifference;
    //public bool flag;

    // public TimeSpan TimeDifference { get => timeDifference; }
    // Start is called before the first frame update
    void Start()
    {
        //ButtonDate.onClick.AddListener(ObtenerDate);
        //flag = false;
        currentDate = DateTime.Now;
        timeDifference = currentDate - currentDate;
    }

    // Update is called once per frame
    void Update()
    {
        timeDifference = currentDate - fecha;
        Debug.Log(timeDifference);
    }

    public void ObtenerDate()
    {
        //string format = "yyyy-MM-dd";
        string aux_date = Fecha.text.ToString();
        string aux_date1 = aux_date.Substring(0, 10); 
        //string aux_date = "2023-06-06";
        
        try
        {
            fecha = DateTime.Parse(aux_date1);
            //Debug.Log("Fecha convertida: " + fecha.ToShortDateString());
            timeDifference = currentDate - fecha;

            //Debug.Log(timeDifference.Days);

            if(timeDifference.Days > 280 || timeDifference.Days <= 0)
            {
                Comentarios.text = "ESCOGE UNA FECHA VALIDA";
                //Debug.Log("HAY MAS DE 9 MESES");
            }
            else
            {
                Comentarios.text = " ";
                if (Panel.activeSelf)
                {
                    Panel.SetActive(false);
                }
                
                //Debug.Log("HAY MENOS DE 9 MESES");
            }
            
        }
        catch (FormatException)
        {
            Comentarios.text = "ESCOGE UNA FECHA VALIDA";
            //Debug.LogError("El formato de la cadena de fecha no es válido.");
        }

    }
}
