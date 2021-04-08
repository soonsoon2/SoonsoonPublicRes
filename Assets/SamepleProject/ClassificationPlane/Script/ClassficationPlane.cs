using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ClassficationPlane : MonoBehaviour
{
    // Start is called before the first frame update

    public ARPlane _ARPlane;
    public MeshRenderer _PlaneMeshRenderer;
    public TextMesh _TextMesh;
    public GameObject _TextObj;
    GameObject _mainCam;

    void Start()
    {
        _mainCam = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabel();
        UpdatePlaneColor();
    }

    void UpdateLabel()
    {
        _TextMesh.text = _ARPlane.classification.ToString();
        _TextObj.transform.position = _ARPlane.center;
        _TextObj.transform.LookAt(_mainCam.transform);
        _TextObj.transform.Rotate(new Vector3(0, 180, 0));
    }

    void UpdatePlaneColor()
    {
        Color planeMatColor = Color.cyan;

        switch (_ARPlane.classification)
        {
            case PlaneClassification.None:
                planeMatColor = Color.cyan;
                break;
            case PlaneClassification.Wall:
                planeMatColor = Color.white;
                break;
            case PlaneClassification.Floor:
                planeMatColor = Color.green;
                break;
            case PlaneClassification.Ceiling:
                planeMatColor = Color.blue;
                break;
            case PlaneClassification.Table:
                planeMatColor = Color.yellow;
                break;
            case PlaneClassification.Seat:
                planeMatColor = Color.magenta;
                break;
            case PlaneClassification.Door:
                planeMatColor = Color.red;
                break;
            case PlaneClassification.Window:
                planeMatColor = Color.clear;
                break;
        }

        planeMatColor.a = 0.33f;
        _PlaneMeshRenderer.material.color = planeMatColor;
    }
}
