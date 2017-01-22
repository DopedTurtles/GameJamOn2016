using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CMovimientoAguja : MonoBehaviour {

	public Transform mReferencia;
	private RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rectTransform)
			rectTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, -mReferencia.rotation.eulerAngles.x);
		else
			Debug.LogWarning ("No hay cuchara !!!");
	}
}
