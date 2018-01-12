using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Utility/TextBillboard")]
public class TextBillboard : MonoBehaviour {
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update () {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
	}
}
