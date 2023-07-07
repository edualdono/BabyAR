using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotable : MonoBehaviour
{
	[SerializeField] private InputAction pressed, axis;
	[SerializeField] private GameObject Camara;
	[SerializeField] private GameObject Camara_AR;
	[SerializeField] private GameObject objecto;
	[SerializeField] private GameObject objecto_1;
	[SerializeField] private GameObject objecto_2;
	[SerializeField] private GameObject objecto_3;
	[SerializeField] private GameObject objecto_4;


	private Camera camara_AR;
	private Camera camara;
	private Transform cam;
	private Transform cam_1;
	private Transform cam_2;
	[SerializeField] private float speed = 1;
	[SerializeField] private bool inverted;
	private Vector2 rotation;
	private bool rotateAllowed;

	private void Awake()
	{
		camara = Camara.GetComponent<Camera>();
		camara_AR = Camara_AR.GetComponent<Camera>();
		//StopAllCoroutines();
		cam_1 = camara_AR.transform;
		cam_2 = camara.transform;
		pressed.Enable();
		axis.Enable();
		//Debug.Log("Esto es awake");
		pressed.performed += _ => { StartCoroutine(Rotate()); };
		
		pressed.canceled += _ => { rotateAllowed = false; };
		axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
	}

    private IEnumerator Rotate()
	{
		rotateAllowed = true;
        
		while (rotateAllowed)
		{
			// apply rotation
			rotation *= speed;
            if (Camara_AR.activeSelf)
            {
				cam = cam_1;
            }
            else
            {
				cam = cam_2;
			}
            if (objecto.activeSelf)
            {
				objecto.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
				objecto.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
			}
            if (objecto_1.activeSelf)
            {
				objecto_1.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
				objecto_1.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
			}
			if (objecto_2.activeSelf)
            {
				objecto_2.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
				objecto_2.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
			}
			if (objecto_3.activeSelf)
			{
				objecto_3.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
				objecto_3.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
			}
			if (objecto_4.activeSelf)
			{
				objecto_4.transform.Rotate(Vector3.up * (inverted ? 1 : -1), rotation.x, Space.World);
				objecto_4.transform.Rotate(cam.right * (inverted ? -1 : 1), rotation.y, Space.World);
			}


			yield return null;
		}
	}
}
