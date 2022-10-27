using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ghost : MonoBehaviour
{
   public int ThisYiDong;
   public int ThisYiDong1;
    public Sprite[] sprites;

    float XuRuo;
    float SiWang;

    Vector2 Startvec;

    public bool HasDie;
   
    // Start is called before the first frame update
    void Start()
    {
        ThisYiDong = Random.Range(1, 5);
        XuRuo = 10;
        SiWang = 3;
        Startvec = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MainMove.Kaishi > 0)
        {
            return;
        }
        if (MainMove.JieShu )
        {
            return;
        }
        if (MainMove.ZhuangTai == 1)
        {
            ThisYiDong1 = 1;
            this.GetComponent<Animator>().SetBool("Weak", true);
        }
        if (ThisYiDong1 == 1)
        {
            XuRuo -= Time.deltaTime;
            if (XuRuo <= 0)
            {
                XuRuo = 10;
                MainMove.ZhuangTai = 0;
                this.GetComponent<Animator>().SetBool("Weak", false);
              
            }
        }
        if (ThisYiDong == 6)
        {
            SiWang -= Time.deltaTime;
            if (SiWang <= 0)
            {
              this.transform.position = Startvec;
                SiWang = 3;
                ThisYiDong = Random.Range(1, 5);
                this.GetComponent<Animator>().SetBool("Die", false);
                HasDie = false;
            }
        }
        if (ThisYiDong == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
            if (ThisYiDong1 == 1)
            {
                this.transform.Translate(Vector2.up * Time.deltaTime * 0.5f);
            }
            else
            {
                this.transform.Translate(Vector2.up * Time.deltaTime);
            }
           
        }
        if (ThisYiDong == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
            if (ThisYiDong1 == 1)
            {
                this.transform.Translate(Vector2.down * Time.deltaTime * 0.5f);
            }
            else
            {
                this.transform.Translate(Vector2.down * Time.deltaTime);
            }

        }
        if (ThisYiDong == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
            if (ThisYiDong1 == 1)
            {
                this.transform.Translate(Vector2.left * Time.deltaTime * 0.5f);
            }
            else
            {
                this.transform.Translate(Vector2.left * Time.deltaTime);
            }
        }
        if (ThisYiDong == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[3];
            if (ThisYiDong1 == 1)
            {
                this.transform.Translate(Vector2.right * Time.deltaTime * 0.5f);
            }
            else
            {
                this.transform.Translate(Vector2.right * Time.deltaTime);
            }
        }
        if (ThisYiDong <= 4&& ThisYiDong1==0)
        {
            this.GetComponent<Animator>().enabled = false;
        }
        else
        {
            this.GetComponent<Animator>().enabled = true;
        }
    }
    public void EndWeak()
    {

        ThisYiDong1 = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "3")
        {
            if (ThisYiDong == 1)
            {
                this.transform.position = this.transform.position - Vector3.up*Time.deltaTime*2;
            }
            if (ThisYiDong == 2)
            {
                this.transform.position = this.transform.position - Vector3.down * Time.deltaTime*2;
            }
            if (ThisYiDong == 3)
            {
                this.transform.position = this.transform.position - Vector3.left * Time.deltaTime*2;
            }
            if (ThisYiDong == 4)
            {
                this.transform.position = this.transform.position - Vector3.right * Time.deltaTime*2;
            }
            int temp = ThisYiDong;
            while (ThisYiDong == temp)
            {
                ThisYiDong = Random.Range(1, 5);
            }
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        int temp = ThisYiDong;
        while (ThisYiDong == temp)
        {
            ThisYiDong = Random.Range(1, 5);
        }
    }
}
