using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDrawLine : MonoBehaviour
{
    public Transform _pivotPoint;
    public GameObject _lineRenderePrefabs;
    private LineRenderer _lineRendere;
    public List<LineRenderer> _lineList = new List<LineRenderer>();
    public Transform _linePool;

    public bool _use; //
    public bool _startLine;

    public List<Color> _colorList = new List<Color>();
    public Color _nowColor;
    public int _colorNumber;
    public Image _colorButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_use)
        {
            if(_startLine)
            {
                DrawLineContinue();
            }
        }
    }

    public void MakeLineRendere()
    {
        GameObject tLine = Instantiate(_lineRenderePrefabs);
        tLine.transform.SetParent(_linePool);
        tLine.transform.position=Vector3.zero;
        tLine.transform.localScale = new Vector3(1,1,1);
        
        _lineRendere = tLine.GetComponent<LineRenderer>();
        _lineRendere.positionCount = 1;
        _lineRendere.SetPosition(0,_pivotPoint.position);

        _lineRendere.startColor = _nowColor;
        _lineRendere.endColor = _nowColor;

        _startLine = true;
        _lineList.Add(_lineRendere);

    }

    public void DrawLineContinue()
    {
        _lineRendere.positionCount = _lineRendere.positionCount+1;
        _lineRendere.SetPosition(_lineRendere.positionCount-1,_pivotPoint.position);
    }

    public void StartDrawLine()
    {
        _use = true;
        if(!_startLine)
        {
            MakeLineRendere();
        }
    }

    public void StopDrawLine()
    {
        _use = false;
        _startLine = false;
        _lineRendere = null;
    }

    public void ChangeColor()
    {
        _colorNumber++;
        if(_colorNumber >= _colorList.Count) _colorNumber =0;

        _nowColor  = _colorList[_colorNumber];
        _colorButton.color = _nowColor;
    }

}
