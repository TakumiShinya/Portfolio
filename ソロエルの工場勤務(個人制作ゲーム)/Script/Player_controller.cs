using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_controller : MonoBehaviour
{
    public GameManager myManager;

    public float speed = 0.01f;
    private float countdown=3f;
    private float time = 80;
    private int count;
    public GameObject countText = null;

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

        TextMeshProUGUI count_text = countText.GetComponent<TextMeshProUGUI>();
        count_text.text = string.Format("{0}", count);
        if (countdown <= 0)
        {
            countText.SetActive(true);
            if (time <= 0)
            {
                countText.SetActive(false);
                //return;
            }
            time -= Time.deltaTime;
            if (Input.GetKey(KeyCode.W) && time >= 0)
            {
                if (this.transform.position.z - this.transform.localScale.z / 2 < 10.0)
                    transform.position += new Vector3(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.A) && time >= 0)
            {
                if (this.transform.position.x - this.transform.localScale.x / 2 > -10.0)
                    transform.position += new Vector3(speed * -1.0f, 0, 0);
            }
            if (Input.GetKey(KeyCode.S) && time >= 0)
            {
                if (this.transform.position.z - this.transform.localScale.z / 2 > -10.0 && this.transform.position.x - this.transform.localScale.x / 2 < 7.5
                    || this.transform.position.x - this.transform.localScale.x / 2 > -7.5)
                    transform.position += new Vector3(0, 0, speed * -1.0f);
            }
            if (Input.GetKey(KeyCode.D) && time >= 0)
            {
                if (this.transform.position.x - this.transform.localScale.x / 2 < 10.0)
                    transform.position += new Vector3(speed, 0, 0);
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RItem"|| collision.gameObject.tag == "GItem"|| collision.gameObject.tag == "BItem")
        {
            if (count < 3)
            {
                myManager.AddName(collision.gameObject.tag);
                Destroy(collision.gameObject);
                speed -= 0.01f;
                count++;
            }
           
        }
    }
    public void ResetCount()
    {
        count = 0;
        speed = 0.2f;
    }
}
