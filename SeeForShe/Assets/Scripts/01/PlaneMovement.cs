using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform paperPlane;
    private RectTransform shadow;

    private Image screen_Alpha;

    private float speedX;
    private float speedY;
    private float upadate_Speed;
    private float posX;
    private float posY;

    public bool move;
    private bool flicker;
    private Vector2 change_Scale;
    private Vector2 pos;

    void Start()
    {
        move = false;
        flicker = false;
        speedX = 2.28f;
        speedY = 0f;
        upadate_Speed = 2.2f;
        screen_Alpha = GameObject.Find(ID.CANVAS).transform.Find(ID.SCREEN).GetComponent<Image>();
        paperPlane = this.GetComponent<RectTransform>();
        shadow = GameObject.Find(ID.CANVAS).transform.Find(ID.SHADOW).GetComponent<RectTransform>();
        posX = paperPlane.anchoredPosition.x;
        posY = paperPlane.anchoredPosition.y;
        change_Scale = shadow.sizeDelta;
        pos = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Judge();
        Movement();
    }

    void Movement()
    {
        if (!move)
        {
            return;
        }
        posX -= speedX;
        speedY += upadate_Speed * Time.deltaTime;
        posY -= speedY;
        pos.x = posX;
        pos.y = posY;
        change_Scale.x += 36f * Time.deltaTime;
        change_Scale.y += 12f * Time.deltaTime;
        paperPlane.anchoredPosition = pos;
        pos.x -= 8f;
        pos.y = shadow.anchoredPosition.y;
        shadow.anchoredPosition = pos;
        shadow.sizeDelta = change_Scale;
        if (posX < 0)
        {
            move = false;
            flicker = true;  //出现下一步
            paperPlane.GetComponent<ScreenChangement>().My_Status = ScreenChangement.Status.UpdateOut;
            shadow.GetComponent<ScreenChangement>().My_Status = ScreenChangement.Status.UpdateOut;
            screen_Alpha.GetComponent<ScreenChangement>().My_Status = ScreenChangement.Status.UpdateOut;
            posX = 0f;
        }
    }

    void Judge()
    {
        if (!move&&!flicker)
        {
            if(screen_Alpha.color.a >= 1)
            {
                move = true;
            }
        }
    }
}
