using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class MapManager : WindowsManager, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Camera MapCamera;
    bool inMap = false;
    Vector3 _dis;
    bool opneMap;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dis = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pointOnTheScreen = Input.mousePosition;
        var dis = Input.mousePosition - _dis;
        dis.Normalize();
        Debug.Log(dis);
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }
    private void Start()
    {
        OpneWindow();
    }

    void Update()
    {
        opneMap = isVisble;
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isVisble)
            {
                CloseWindow();
            }
            else
            {
                OpneWindow();
            }      
        } 
        
        MapCamera.orthographicSize -= Input.mouseScrollDelta.y;
        MapCamera.orthographicSize = Mathf.Clamp(MapCamera.orthographicSize, 20, 80);
    }
}
