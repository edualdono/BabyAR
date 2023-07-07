using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotaion : MonoBehaviour
{
    [SerializeField] private GameObject embrion;
    private float rotationSpeed = 10f;
    private bool isRotating = false;
    private Vector2 rotationStartPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                rotationStartPos = touch.position;
                isRotating = true;
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector2 currentPos = touch.position;
                float rotationAmount = (currentPos.x - rotationStartPos.x) * rotationSpeed * Time.deltaTime;

                transform.Rotate(Vector3.up, rotationAmount, Space.World);

                rotationStartPos = currentPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }
    }
}
