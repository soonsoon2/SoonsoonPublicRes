using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaceObject : MonoBehaviour
{
    public List<GameObject> _prefabs = new List<GameObject>();
    public ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    public Transform _objectPool;
    Vector2 _centerVec;
    GameObject nowObject;
    PlaneClassification nowTypeTag;
    // Start is called before the first frame update
    void Start()
    {
        _centerVec = new Vector2( Screen.width * 0.5f, Screen.height * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(nowObject!=null)
        {
            if(m_RaycastManager.Raycast(_centerVec, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                ARPlane tPlane = s_Hits[0].trackable.GetComponent<ARPlane>();
                if(nowTypeTag == tPlane.classification)
                {
                    nowObject.transform.position = s_Hits[0].pose.position;
                    nowObject.transform.localScale = new Vector3(1,1,1);
                }
                else
                {
                    nowObject.transform.localScale = new Vector3(0,0,0);
                }
            }
            else
            {
                nowObject.transform.localScale = new Vector3(0,0,0);
            }
        }
        
    }


    public void SetObject (int type)
    {
        if(nowObject!=null) 
        {
            Destroy(nowObject);
            nowObject= null;
        }
        
        GameObject tObj = null;
        switch(type)
        {
            case 0:
            tObj = _prefabs[0];
            nowTypeTag = PlaneClassification.Floor;
            break;

            case 1:
            tObj = _prefabs[1];
            nowTypeTag = PlaneClassification.Table;
            break;
        }

        nowObject = Instantiate(tObj);
        nowObject.transform.SetParent(_objectPool);
        nowObject.transform.localScale = new Vector3(1,1,1);
    }

    public void SetObjectDone()
    {
        nowObject = null;
    }
}
