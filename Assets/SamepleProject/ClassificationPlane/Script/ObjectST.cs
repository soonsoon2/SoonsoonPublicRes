using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectST : MonoBehaviour
{
    public enum ObjectType
    {
        None,
        Wall,
        Floor,
        Ceiling,
        Table,
        Seat,
        Door,
        Window
    }
    public ObjectType _nowObject = ObjectType.None;
}
