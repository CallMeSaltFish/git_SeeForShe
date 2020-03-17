using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o3Controller : MonoBehaviour
{
    [SerializeField]
    private ScreenChangement sc1;
    [SerializeField]
    private ScreenChangement sc2;
    [SerializeField]
    private ScreenChangement sc3;
    [SerializeField]
    private ScreenChangement sc4;

    private int status;
    // Start is called before the first frame update
    void Start()
    {
        sc1.My_Status = ScreenChangement.Status.UpdateIn;
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        My_Update();
    }

    void My_Update() // 图片显示顺序
    {
        if (sc1.Filished && status == 0)
        {
            sc2.Upadate_Speed = 1f;
            sc2.My_Status = ScreenChangement.Status.UpdateIn;
            sc1.Filished = false;
            status++;
        }

        if (sc3.Filished && status == 1)
        {
            Destroy(sc2.gameObject);
            sc4.Upadate_Speed = 1f;
            sc4.My_Status = ScreenChangement.Status.UpdateIn;
            sc3.Filished = false;
        }
    }
}
