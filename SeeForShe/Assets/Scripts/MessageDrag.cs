using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    private Transform image;//所要控制的UI    
    public RectTransform canvas;//所在canvas     
    private RectTransform curRecTran;
    private Vector3 offet;

    private void Start()    
    {        
        curRecTran = transform.GetComponent<RectTransform>();    
    }      
 
  
    public void OnPointerDown(PointerEventData eventData)    
    {
        if (Input.touchCount == 1|| Input.GetMouseButtonDown(0))        
        {            
            Vector3 mouseDown;            //屏幕坐标转世界坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(curRecTran, eventData.position,    eventData.pressEventCamera, out mouseDown)) 
            {
                Debug.Log(1);
                offet = curRecTran.position - mouseDown;           
            }        
        }    
    }/// <summary>
     /// 移动
     /// </summary>
     /// <param name="eventData"></param>    
     public void OnDrag(PointerEventData eventData)   
     {
        if (Input.touchCount == 1|| Input.GetMouseButton(0))        
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(canvas, eventData.position))      
            {
                Debug.Log(1);
                Vector3 globalMousePos;     
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(curRecTran, eventData.position,        eventData.pressEventCamera, out globalMousePos))          
                {
                    curRecTran.position = globalMousePos + offet;           
                }        
            }      
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
