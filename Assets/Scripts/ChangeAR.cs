using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAR : MonoBehaviour
{
    [SerializeField] private GameObject AR_Camera;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject Object;
    [SerializeField] private GameObject Object_1;
    [SerializeField] private GameObject Object_2;
    [SerializeField] private GameObject Object_3;
    [SerializeField] private GameObject Object_4;
    [SerializeField] private GameObject Object_5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CameraUpdate(){
        Vector3 posicion;
        Vector3 forward;
        Vector3 objectPosition;

        if (AR_Camera.activeSelf)
        {
            AR_Camera.SetActive(false);
            Manager.SetActive(false);
            Camera.SetActive(true);
            //Debug.Log("ENTRO AR");
            posicion = Camera.transform.position;
            forward = Camera.transform.forward;
            objectPosition = posicion + forward * 0.7f;


            Object.transform.position   = objectPosition;
            Object_1.transform.position = objectPosition;
            Object_2.transform.position = objectPosition;
            Object_3.transform.position = objectPosition;
            Object_4.transform.position = objectPosition;
            Object_5.transform.position = objectPosition;
        }
        else
        {
            //Debug.Log("Posicon cambiada");

            AR_Camera.SetActive(true);
            Manager.SetActive(true);
            Camera.SetActive(false);
           

        }
    }
}
