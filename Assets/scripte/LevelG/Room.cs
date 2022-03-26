using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[ExecuteInEditMode]
public class Room : MonoBehaviour
{
    public GameObject room;
    public List<Transform> SpownPoint = new List<Transform>();
    private LayerMask _layerMask;

    [Button]
    [GUIColor(0, 1, 0)]
    public void setAllObject()
    {
        room = this.gameObject;
        Snap();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!SpownPoint.Contains(transform.GetChild(i)))
            {
                SpownPoint.Add(transform.GetChild(i));
                transform.GetChild(i).gameObject.AddComponent(typeof(SnapToGrounnd));
            }
        }
    }

    
    [Button]
    void Snap()
    {


        foreach (var item in SpownPoint)
        {
            item.rotation = Quaternion.identity;
            RaycastHit hit;
            
            if (Physics.Raycast(item.position, Vector3.down, out hit, 1000))
            {
                Debug.Log(hit.point.y);
                item.position =
                    new Vector3(transform.position.x, hit.point.y, item.position.z);
            }
        }
    }
    
}