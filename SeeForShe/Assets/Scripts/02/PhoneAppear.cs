using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneAppear : MonoBehaviour
{
    [SerializeField]
    private ScreenChangement[] my_render = new ScreenChangement[6];

    private int status;

    private Vector2 pos;
    private Vector2 pos1;
    private Vector2 pos0;

    private float move_Speed;
    private float time;
    private int index;
    [SerializeField]
    private GameObject aim;

    // Start is called before the first frame update
    void Start()
    {
        my_render[0].Upadate_Speed *= 4;
        my_render[0].My_Status = ScreenChangement.Status.UpdateIn;
        status = -1;
        time = 0;
        index = 4;
        pos = new Vector2(540, 960);
        pos1 = new Vector2(540, 843);
        pos0 = new Vector2(540, 1077);
        move_Speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            UpdateStatus();
            OnAppear();
        }
    }

    void UpdateStatus()
    {
        if (my_render[1].Filished)
        {
            status = 1;
            my_render[1].Filished = false;
            my_render[5].Filished = false;
        }
        if (my_render[2].Filished)
        {
            status = 3;
            my_render[2].Filished = false;
        }
        if(my_render[3].Filished)
        {
            status = 6;
            my_render[3].Filished = false;
        }
    }

    void OnAppear()
    {
        if(status == 8 && index == 3)
        {
            my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition =
               Vector2.Lerp(my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition, pos, move_Speed * Time.deltaTime);
            my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition =
               Vector2.Lerp(my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition, pos0, move_Speed * Time.deltaTime);
            if (my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition.y >=1067)
            {
                status = 9;
                my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
                my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition = pos0;
            }
        }
        if(status == 9 && index == 2)
        {
            my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition =
                Vector2.Lerp(my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition, pos0, move_Speed * Time.deltaTime);
            if (my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition.y >=1067)
            {
                my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition = pos0;
                status = 10;
            }
        }
        if(index == 1 && my_render[0].Filished) //下一关
        {
            Destroy(GameObject.Find(ID.CANVAS));
            Instantiate(Resources.Load(ID.CANVAS03)).name = ID.CANVAS;

        }
        if(my_render[0].Filished && status == -1)
        {
            my_render[1].My_Status = ScreenChangement.Status.UpdateIn;
            my_render[5].My_Status = ScreenChangement.Status.UpdateIn;
            status = 0;
        }
        if(status == 1)
        {
            my_render[2].My_Status = ScreenChangement.Status.UpdateIn;
            status = 2;
        }
        if(status == 3)
        {
            my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition =
                Vector2.Lerp(my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition, pos, move_Speed * Time.deltaTime);
            if (my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition.y <= 970)
            {
                my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
                status = 4;
            }
        }
        if(status == 4)
        {
            my_render[3].My_Status = ScreenChangement.Status.UpdateIn;
            status = 5;
        }
        if(status == 6)
        {
            my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition =
                Vector2.Lerp(my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition, pos1, move_Speed * Time.deltaTime);
            my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition =
               Vector2.Lerp(my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition, pos, move_Speed * Time.deltaTime);
            if (my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition.y <= 970)
            {
                status = 7;
                my_render[2].gameObject.GetComponent<RectTransform>().anchoredPosition = pos1;
                my_render[3].gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
            }
        }
        if(status == 7)
        {
            my_render[4].My_Status = ScreenChangement.Status.UpdateIn;
            status = 8;
        }
    }

    public void OnButtonClick()
    {
        my_render[index].gameObject.SetActive(false);
        aim.SetActive(false);
        index--;
        if(index == 1)
        {
            my_render[0].My_Status = ScreenChangement.Status.UpdateOut;
            my_render[1].My_Status = ScreenChangement.Status.UpdateOut;
            my_render[5].My_Status = ScreenChangement.Status.UpdateOut;
        }
    }
}
