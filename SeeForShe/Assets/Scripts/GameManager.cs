using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScreenChangement screen;

    // Start is called before the first frame update
    void Start()
    {
        screen.My_Status = ScreenChangement.Status.UpdateIn;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLevel();
    }

    void ChangeLevel()
    {
        if(screen != null &&screen.My_Status == ScreenChangement.Status.UpdateOut && screen.GetComponent<Image>().color.a <= 0.12f)
        {
            Destroy(GameObject.Find(ID.CANVAS));
            screen = null;
            Instantiate(Resources.Load(ID.CANVAS02)).name = ID.CANVAS;
        }
    }
}
