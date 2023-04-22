using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private float countdown=3f;
    public GameManager myManager;

    public GameObject rUI1;
    public GameObject rUI2;
    public GameObject rUI3;
    public GameObject gUI1;
    public GameObject gUI2;
    public GameObject gUI3;
    public GameObject bUI1;
    public GameObject bUI2;
    public GameObject bUI3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0)
        {
            for (int i = 0; i < myManager.Aims.Count; i++)
            {
                if (i == 0)
                {
                    if (myManager.Aims[i] == null)
                    {
                        rUI1.SetActive(false);
                        gUI1.SetActive(false);
                        bUI1.SetActive(false);
                    }
                    if (myManager.Aims[i] == "RItem")
                    {
                        rUI1.SetActive(true);
                        gUI1.SetActive(false);
                        bUI1.SetActive(false);
                    }
                    if (myManager.Aims[i] == "GItem")
                    {
                        rUI1.SetActive(false);
                        gUI1.SetActive(true);
                        bUI1.SetActive(false);
                    }
                    if (myManager.Aims[i] == "BItem")
                    {
                        rUI1.SetActive(false);
                        gUI1.SetActive(false);
                        bUI1.SetActive(true);
                    }
                }

                if (i == 1)
                {
                    if (myManager.Aims[i] == null)
                    {
                        rUI2.SetActive(false);
                        gUI2.SetActive(false);
                        bUI2.SetActive(false);
                    }
                    if (myManager.Aims[i] == "RItem")
                    {
                        rUI2.SetActive(true);
                        gUI2.SetActive(false);
                        bUI2.SetActive(false);
                    }
                    if (myManager.Aims[i] == "GItem")
                    {
                        rUI2.SetActive(false);
                        gUI2.SetActive(true);
                        bUI2.SetActive(false);
                    }
                    if (myManager.Aims[i] == "BItem")
                    {
                        rUI2.SetActive(false);
                        gUI2.SetActive(false);
                        bUI2.SetActive(true);
                    }
                }

                if (i == 2)
                {
                    if (myManager.Aims[i] == null)
                    {
                        rUI3.SetActive(false);
                        gUI3.SetActive(false);
                        bUI3.SetActive(false);
                    }
                    if (myManager.Aims[i] == "RItem")
                    {
                        rUI3.SetActive(true);
                        gUI3.SetActive(false);
                        bUI3.SetActive(false);
                    }
                    if (myManager.Aims[i] == "GItem")
                    {
                        rUI3.SetActive(false);
                        gUI3.SetActive(true);
                        bUI3.SetActive(false);
                    }
                    if (myManager.Aims[i] == "BItem")
                    {
                        rUI3.SetActive(false);
                        gUI3.SetActive(false);
                        bUI3.SetActive(true);
                    }
                }
                else
                {
                    rUI3.SetActive(false);
                    gUI3.SetActive(false);
                    bUI3.SetActive(false);
                }
            }
        }
    }
}
