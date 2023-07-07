using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ObjectPosition : MonoBehaviour
{
    [SerializeField] private TMP_Text Weeks_text;
    [SerializeField] private TMP_Text Size_text;
    [SerializeField] private TMP_Text Size_text_2;
    [SerializeField] private ManoPositionSolver handPositionSolver;
    [SerializeField] private Button_Date tiempo_inicial;
    [SerializeField] private Button_Date tiempo_update;
    [SerializeField] private GameObject celula;
    [SerializeField] private GameObject embrion;
    [SerializeField] private GameObject embrion_2;
    [SerializeField] private GameObject feto;
    [SerializeField] private GameObject feto_2;
    [SerializeField] private GameObject feto_3;

    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    //[SerializeField] private float speedMovement = 0.5f;
    //[SerializeField] private float speedRotation = 25.0f;

    //private float minDistancer = 0.5f;
    //private float minAngleMagnitude = 2.0f;
    //private bool shouldAjustRotation;

    private TimeSpan tiempo_init;
    private TimeSpan tiempo_up;
    private int Weeks = 0;
    private float Size = 0f;
    private Vector3 celula_size;
    private Vector3 embrion_size;
    private Vector3 feto_size;
    private Vector3 aux_size;
    private float factor;
    private float factor_aux;
    private bool[] colores = new bool[5];
    private string[] hex_colores = new string[5];

    //private Renderer celula_render;
    //private Renderer embrion_render;
    //private Renderer embrion_2_render;
    //private Renderer feto_render;
    //private Renderer feto_2_render;
    //private Renderer feto_3_render;

    void Start()
    {
        Weeks_text.text = Weeks.ToString();
        Size_text.text = Size.ToString();
        Size_text_2.text = Size.ToString();
        //feto_size = feto.transform.localScale;

        celula_size = new Vector3(0.004f, 0.004f, 0.004f);
        embrion_size = new Vector3(0.04f, 0.04f, 0.04f);
        feto_size = new Vector3(0.07f, 0.07f, 0.07f);
        aux_size = new Vector3(0.04f, 0.4f, 0.4f);

        celula.transform.localScale = celula_size;
        embrion.transform.localScale = embrion_size;
        embrion_2.transform.localScale = embrion_size;
        feto.transform.localScale = feto_size;
        feto_2.transform.localScale = feto_size;
        feto_3.transform.localScale = feto_size;

        celula.SetActive(true);

        colores[0] = true;
        colores[1] = false;
        colores[2] = false;
        colores[3] = false;
        colores[4] = false;

        //hex_colores[0] = "#E8BEAC";
        hex_colores[0] = "#FFFFFF";
        hex_colores[1] = "#F1C27D";
        hex_colores[2] = "#C68642";
        hex_colores[3] = "#8D5524";
        hex_colores[4] = "#321B0F";

    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectOnHand(handPositionSolver.HandPosition, handPositionSolver.Flag);

    }

    private void PlaceObjectOnHand(Vector3 handPosition, bool flag)
    {
        if (flag)
        {
            celula.SetActive(false);
            embrion.SetActive(false);
            embrion_2.SetActive(false);
            feto.SetActive(false);
            feto_2.SetActive(false);
            feto_3.SetActive(false);
        }
        else
        {
            UpdateObject();
        }

        int speed = 2;
        celula.transform.position = Vector3.MoveTowards(celula.transform.position , handPosition, speed * Time.deltaTime);
        embrion.transform.position = Vector3.MoveTowards(embrion.transform.position, handPosition, speed * Time.deltaTime);
        embrion_2.transform.position = Vector3.MoveTowards(embrion_2.transform.position, handPosition, speed * Time.deltaTime);
        feto.transform.position = Vector3.MoveTowards(feto.transform.position, handPosition, speed * Time.deltaTime);
        feto_2.transform.position = Vector3.MoveTowards(feto_2.transform.position, handPosition, speed * Time.deltaTime);
        feto_3.transform.position = Vector3.MoveTowards(feto_3.transform.position, handPosition, speed * Time.deltaTime);

    }

    public void IncrementWeeks()
    {
        if (Weeks >= 40)
        {
            Weeks = 40;
        }
        else
        {
            Weeks++;
            Weeks_text.text = Weeks.ToString();
        }
        UpdateObject();
    }

    public void DecrementWeeks()
    {
        if (Weeks <= 0)
        {
            Weeks = 0;
        }
        else
        {
            Weeks--;
            Weeks_text.text = Weeks.ToString();
        }
        UpdateObject();
    }

    public void IncrementSize()
    {
        if (Size >= 60)
        {
            Size = 60;
        }
        else
        {
            Size = Size + 0.1f;
            Size_text.text = Size.ToString("F1");
            Size_text_2.text = Size_text.text;
        }

        ApplyChanges();
    }

    public void DecrementSize()
    {
        if (Size < 0.1)
        {
            Size = 0;
        }
        else
        {
            Size = Size - 0.1f;
            Size_text.text = Size.ToString("F1");
            Size_text_2.text = Size_text.text;
        }

        ApplyChanges();
    }

    public void ButtonDate(bool flag)
    {
        if (flag)
        {
            //Debug.Log("se inicializo");
            tiempo_init = tiempo_inicial.timeDifference;
            //Debug.Log(tiempo_init.Days);
            if (tiempo_init.Days > 0)
            {
                //Debug.Log(tiempo_init.Days);
                Weeks = (int)(tiempo_init.Days / 7);
                Weeks_text.text = Weeks.ToString();
                UpdateObject();
            }
        }
        else
        {
            //Debug.Log("se actualizo");
            tiempo_up = tiempo_update.timeDifference;
            //Debug.Log(tiempo_up.Days);
            if (tiempo_up.Days > 0)
            {
                //Debug.Log(tiempo_init.Days);
                Weeks = (int)(tiempo_up.Days / 7);
                Weeks_text.text = Weeks.ToString();
                UpdateObject();
            }
        }

        
    }

    public void UpdateObject()
    {
        if (Weeks >= 0 && Weeks < 4)
        {
            celula.SetActive(true);
            embrion.SetActive(false);
            embrion_2.SetActive(false);
            feto.SetActive(false);
            feto_2.SetActive(false);
            feto_3.SetActive(false);
            celula_size = new Vector3(0.004f, 0.004f, 0.004f);
            factor = 0.004f;
            //print(celula.transform.localScale);
        }
        else if (Weeks >= 4 && Weeks <=5)
        {
            celula.SetActive(false);
            embrion.SetActive(true);
            embrion_2.SetActive(false);
            feto.SetActive(false);
            feto_2.SetActive(false);
            feto_3.SetActive(false);
            factor = 0.004f;
            embrion_size = new Vector3(factor, factor, factor);
            embrion.transform.localScale = embrion_size;
        }
        //else if (Weeks > 5 && Weeks <= 11)
        else if (Weeks > 5 && Weeks < 10)
        {
            celula.SetActive(false);
            embrion.SetActive(false);
            embrion_2.SetActive(true);
            feto.SetActive(false);
            feto_2.SetActive(false);
            feto_3.SetActive(false);

            if (Weeks < 7)
            {
                factor = -((Weeks * -0.001f) + 0.001f);
                embrion_size = new Vector3(factor, factor, factor);
            }
            //else if (Weeks >= 7 && Weeks < 10)
            else
            {
                factor = 0.007f * (Weeks - 6);
                embrion_size = new Vector3(factor, factor, factor);
            }
            //else
            //{
            //    factor = ((Weeks * 0.01f) - 0.06f) + ((Weeks - 10) * 0.01f);
            //    embrion_size = new Vector3(factor, factor, factor);
            //}
            embrion_2.transform.localScale = embrion_size;
            //print(embrion.transform.localScale);
        }
        else if(Weeks >= 10 && Weeks < 12)
        {
            celula.SetActive(false);
            embrion.SetActive(false);
            embrion_2.SetActive(false);
            feto.SetActive(true);
            feto_2.SetActive(false);
            feto_3.SetActive(false);

            if (Weeks == 10)
            {
                factor = ((Weeks * 0.01f) - 0.06f) + ((Weeks - 10) * 0.01f);
                feto_size = new Vector3(factor/2f, factor/2f, factor/2f);
            }
            else
            {
                factor = (Weeks - 5) * 0.01f;
                feto_size = new Vector3(factor / 2f, factor / 2f, factor / 2f);
            }

            feto.transform.localScale = feto_size;
        }
        else if(Weeks >= 12 && Weeks < 20) 
        {
            celula.SetActive(false);
            embrion.SetActive(false);
            embrion_2.SetActive(false);
            feto.SetActive(false);
            feto_2.SetActive(true);
            feto_3.SetActive(false);

            if(Weeks < 16)
            {
                factor = (Weeks - 5) * 0.01f;
                feto_size = new Vector3(factor / 2f, factor / 2f, factor / 2f);
            }
            else
            {
                factor = (Weeks - 3) * 0.01f;
                feto_size = new Vector3(factor / 2f, factor / 2f, factor / 2f);
            }

            feto_2.transform.localScale = feto_size;
        }
        else
        {
            celula.SetActive(false);
            embrion.SetActive(false);
            embrion_2.SetActive(false);
            feto.SetActive(false);
            feto_2.SetActive(false);
            feto_3.SetActive(true);

            //if (Weeks < 16)
            //{
            //    factor = (Weeks - 5) * 0.01f;
            //    feto_size = new Vector3(factor, factor, factor);
            //}
            
            if (Weeks < 25)
            {
                factor = (Weeks - 3) * 0.01f;
                factor_aux = factor / 3f + 0.02f;
                feto_size = new Vector3(factor_aux, factor_aux, factor_aux);
            }
            else
            {
                factor = (Weeks - 2) * 0.01f;
                factor_aux = factor / 3f + 0.02f;
                feto_size = new Vector3(factor_aux, factor_aux, factor_aux);
            }

            feto_3.transform.localScale = feto_size;
            //print(feto.transform.localScale);
        }
        Size = factor * 100;
        Size_text.text = Size.ToString("F1");
        Size_text_2.text = Size_text.text;
    }

    public void ApplyChanges()
    {
        factor = Size / 100f;
        factor_aux = factor / 3f + 0.02f;

        if (celula.activeSelf || embrion.activeSelf || embrion_2.activeSelf)
        {
            aux_size = new Vector3(factor, factor, factor);
            celula.transform.localScale = aux_size;
            embrion.transform.localScale = aux_size;
            embrion_2.transform.localScale = aux_size;
        }
        else if (feto.activeSelf || feto_2.activeSelf || feto_3.activeSelf)
        {
            aux_size = new Vector3(factor / 2f, factor / 2f, factor / 2f);
            feto.transform.localScale = aux_size;
            feto_2.transform.localScale = aux_size;
            if (feto_3.activeSelf)
            {
                aux_size = new Vector3(factor_aux, factor_aux, factor_aux);
                feto_3.transform.localScale = aux_size;
            }
            
        }
    }

    public void UpdateColor(int num)
    {
        for (int i = 0; i < colores.Length; i++)
        {
            if (i == num)
            {
                colores[i] = true;
                SetColor(hex_colores[i]);
                //SetColor(embrion_render, hex_colores[i]);
                //SetColor(embrion_2_render, hex_colores[i]);
                //SetColor(feto_render, hex_colores[i]);
                //SetColor(feto_2_render, hex_colores[i]);
                //SetColor(feto_3_render, hex_colores[i]);
            }
            else
            {
                colores[i] = false;
            }
        }
    }

    public void SetColor(string color)
    {
        Color newColor;
        ColorUtility.TryParseHtmlString(color, out newColor);

        //render.material.color = newColor;
        Material1.color = newColor;
        Material2.color = newColor;
        Material3.color = newColor;
        Material4.color = newColor;
        Material5.color = newColor;

    }

}
