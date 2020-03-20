using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{  
    public RectTransform canvas;//所在canvas     
    private RectTransform curRecTran;
    private Vector3 offet;
    [SerializeField]
    private GameObject aim;

    private void Start()    
    {        
        curRecTran = transform.GetComponent<RectTransform>();
        canvas = transform.GetComponentInParent<RectTransform>();    }      
 
  
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
        if ((Input.touchCount == 1|| Input.GetMouseButton(0))&& curRecTran .anchoredPosition .y == 1077f)        
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(canvas, eventData.position))      
            {
                Vector3 globalMousePos;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(curRecTran, eventData.position,        eventData.pressEventCamera, out globalMousePos))          
                {
                    if (globalMousePos.x <= 415)
                    {
                        globalMousePos.x = 415;
                        aim.SetActive(true);
                        aim.GetComponent<RectTransform>().anchoredPosition = new Vector2(704f, 1080f);
                    }
                    else
                    {
                        aim.SetActive(false);
                    }
                    if(globalMousePos .x>=540)
                        globalMousePos.x = 540;
                    curRecTran.anchoredPosition = new Vector2(globalMousePos.x, curRecTran.anchoredPosition.y);           
                }        
            }      
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
