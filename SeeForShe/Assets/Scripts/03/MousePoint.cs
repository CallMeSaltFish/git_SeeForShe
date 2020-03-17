using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MousePoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ScreenChangement sc1;
    [SerializeField]
    private ScreenChangement sc2;
    private int status;
    void Start()
    {
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown1()
    {
        if (status == 0)
        {
            Debug.Log(1);
            status++;
            this.GetComponent<ScreenChangement>().My_Status = ScreenChangement.Status.UpdateOut;
            sc1.Upadate_Speed = 1f;
            sc1.My_Status = ScreenChangement.Status.UpdateOut;
            sc2.My_Status = ScreenChangement.Status.UpdateIn;
        }
    }

    public void PointerDown2()
    {
        if (status == 0)
        {
            status++;
            this.GetComponent<ScreenChangement>().My_Status = ScreenChangement.Status.UpdateOut;
            sc2.Upadate_Speed = 1f;
            sc2.My_Status = ScreenChangement.Status.UpdateOut;
            //sc2.My_Status = ScreenChangement.Status.UpdateIn;
        }
    }
}
