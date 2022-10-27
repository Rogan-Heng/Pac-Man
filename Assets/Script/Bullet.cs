using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int Thisone;
    void Start()
    {
        Destroy(this.gameObject, 5);
        Thisone = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Thisone == 0)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * 2);
        }
        if (Thisone == 1)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * 2);
        }
        if (Thisone == 2)
        {
            this.transform.Translate(Vector2.up * Time.deltaTime * 2);
        }
        if (Thisone == 3)
        {
            this.transform.Translate(Vector2.down * Time.deltaTime * 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1")
        {
           GameObject.FindGameObjectWithTag("Player").GetComponent<MainMove>(). FenShu += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<MainMove>().AllCount += 1;
           // this.GetComponent<AudioSource>().PlayOneShot(YinXiao[0]);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.tag == "2")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MainMove>().FenShu += 1;
            MainMove.ZhuangTai = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<MainMove>().WeakTime = 10;
           
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.tag == "4")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MainMove>().FenShu += 100;
           
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
