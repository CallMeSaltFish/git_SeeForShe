using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChangement : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Status
    {
        UpdateIn,
        UpdateOut,
        None
    }

    private Image my_Image;  //获取图片
    private float my_Alpha;  //获取Alpha值
    private float upadate_Speed; //变化速度
    public float Upadate_Speed { get { return upadate_Speed; } set { upadate_Speed = value; } }
    private Color temp;

    private Status my_Status;
    public Status My_Status { get { return my_Status; } set { my_Status = value; } }
    private bool filished;
    public bool Filished { get { return filished; } set { filished = value; } }
    void Awake()
    {
        filished = false;
        my_Status = Status.None;
        my_Alpha = 0f;
        upadate_Speed = 0.75f;
        my_Image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        if(my_Status == Status.None)
        {
            return;
        }
        if(my_Status == Status.UpdateIn)
        {
            UpdateIn();
        }
        else if(my_Status == Status.UpdateOut)
        {
            UpdateOut();
        }
    }

    void UpdateIn()
    {
        if(my_Alpha > 1)
        {
            filished = true;
            my_Status = Status.None;
            my_Alpha = 1f;
        }
        my_Alpha += upadate_Speed * Time.deltaTime;
        temp = my_Image.color;
        temp.a = my_Alpha;
        my_Image.color = temp;
    }

    void UpdateOut()
    {
        if (my_Alpha < 0)
        {
            filished = true;
            my_Status = Status.None;
            my_Alpha = 0f;
        }
        my_Alpha -= upadate_Speed * Time.deltaTime;
        temp = my_Image.color;
        temp.a = my_Alpha;
        my_Image.color = temp;
    }
}
