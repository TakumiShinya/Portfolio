using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemFloor : MonoBehaviour
{
    public GameManager myManager;
    public Player_controller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        myManager.CheckItem();
        player.ResetCount();
    }
}
