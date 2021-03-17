using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerObjST : MonoBehaviour
{
    public List<Transform> _objList = new List<Transform>();
    public LineRenderer _lineObj;
    public Transform _textObj;
    public TextMesh _text;
    public Transform _mainCam;

    public void SetInit(Vector3 pos)
    {
        _objList[0].transform.position = pos;
        _lineObj.SetPosition(0,pos);
    }

    public void SetObj(Vector3 pos)
    {
        _objList[1].transform.position = pos;
        _lineObj.SetPosition(1,pos);
    }

    void Update()
    {
        Vector3 tVec = _objList[1].position - _objList[0].position;
        _textObj.position = _objList[0].position + tVec*0.5f;

        float tDis = tVec.magnitude;
        string tDisText = string.Format("{0}mm",tDis.ToString("N2"));
        _text.text = tDisText;

        _textObj.LookAt(_mainCam);
    }

}
