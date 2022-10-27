using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3[] vector3s=new Vector3[4];
   public int ThisCount;

    public AudioClip[] audioClips;

    public int FenShu;
    public float FenShuTime;
    public Text text;

    public static int ZhuangTai;
    private int hour;
    private int minute;
    private int second;
    public Text text2;

    public Text text3;
   public float WeakTime;

    public bool Move { get; private set; }

    public Vector2[] vector2s=new Vector2[2];

    int hp;
    public Text text4;
    public Text text5;
   public static float Kaishi;

    public GameObject JieShuImg;
   public int AllCount;
    public static bool JieShu;
    float JieShuTime;


    public GameObject ZiDan;
    void Start()
    {
        JieShu = false;
        Time.timeScale = 1;
        hp = 3;
        Kaishi = 4;
        vector2s[0] = new Vector2(1, 1);
        vector2s[1] = new Vector2(1, 1);
        ZhuangTai = 0;
        ThisCount = 0;
        vector3s[0]= new Vector3(-14 * 0.31f + 6 * 0.31f, 17 * 0.31f - 1 * 0.31f, 0);
        vector3s[1] = new Vector3(-14 * 0.31f + 6 * 0.31f, 17 * 0.31f - 5 * 0.31f, 0);
        vector3s[2] = new Vector3(-14 * 0.31f + 1 * 0.31f, 17 * 0.31f - 5 * 0.31f, 0);
        vector3s[3] = new Vector3(-14 * 0.31f + 1 * 0.31f, 17 * 0.31f - 1 * 0.31f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Kaishi > 0)
        {
            Kaishi -= Time.deltaTime;
            if (Kaishi >= 0)
            {
                text5.text = "GO";
            }
            if (Kaishi >= 1)
            {
                text5.text = "1";
            }
            if (Kaishi >= 2)
            {
                text5.text = "2";
            }
            if (Kaishi >= 3)
            {
                text5.text = "3";
            }
            return;
        }
        else
        {
            text5.gameObject.SetActive(false);
        }
        if (JieShu)
        {
            JieShuTime += Time.deltaTime;
            if (JieShuTime >= 3)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (AllCount >= 56 * 4)
        {
            JieShuImg.SetActive(true);
            JieShu = true;
            if (StartScene.BestFenShu < FenShu)
            {
                PlayerPrefs.SetInt("BestFenShu", FenShu);
            }
            if (StartScene.BestTime > FenShuTime)
            {
                PlayerPrefs.SetFloat("BestTime", FenShuTime);
            }
            return;

        }
        if (hp <= 0)
        {
            JieShu = true;
            JieShuImg.SetActive(true);
           
            if (StartScene.BestFenShu < FenShu)
            {
                PlayerPrefs.SetInt("BestFenShu", FenShu);
            }
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject gameObject2 = GameObject.Instantiate(ZiDan);
                gameObject2.transform.position = this.transform.position;
            }
        }
        text4.text = hp.ToString();

        FenShuTime += Time.deltaTime;
        hour = (int)FenShuTime / 3600;
        minute = ((int)FenShuTime - hour * 3600) / 60;
        second = (int)FenShuTime - hour * 3600 - minute * 60;
        text2.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        if (WeakTime > 0)
        {
            text3.gameObject.SetActive(true);
            WeakTime -= Time.deltaTime;
            text3.text = ((int)WeakTime).ToString();
        }
        else
        {
            text3.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        MyMove();
        text.text = FenShu.ToString();
        Debug.Log(ThisCount);
       // this.transform.position = Vector2.Lerp(this.transform.position, vector3s[ThisCount], Time.deltaTime );
      //  this.transform.localEulerAngles = new Vector3(0, 0, -90 * ThisCount);
      //  if (ThisCount == 2)
       // {
          //  this.transform.localEulerAngles = new Vector3(180, 0, -180);
    //    }
        //if (Vector2.Distance(this.transform.position, vector3s[ThisCount]) <= 0.05f)
       // {
         //   ThisCount++;
         //   if (ThisCount >3)
         //   {
          //      ThisCount = 0;
          //  }
          //  this.GetComponent<Animator>().SetInteger("State", ThisCount);
       // }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1")
        {
            FenShu += 1;
            AllCount += 1;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "2")
        {
            FenShu += 1;
            ZhuangTai = 1;
            WeakTime = 10;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "4")
        {
            FenShu += 100;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            Destroy(collision.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "3")
        {
           // FenShu += 1;
            this.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
          //  Destroy(collision.gameObject);
        }
        if (collision.gameObject. tag == "5")
        {
            if (collision.gameObject.GetComponent<Ghost>().ThisYiDong1 == 1 && collision.gameObject.GetComponent<Ghost>().ThisYiDong != 6)
            {
                collision.gameObject.GetComponent<Ghost>().ThisYiDong = 6;
                FenShu += 300;
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
            }
            else
            {
                hp -= 1;
                vector2s[0] = new Vector2(1, 1);
                vector2s[1] = new Vector2(1, 1);
                this.transform.position= new Vector3(-14 * 0.31f + 1 * 0.31f, 17 * 0.31f - 1 * 0.31f, 0);
                this.GetComponent<AudioSource>().PlayOneShot(audioClips[3]);
            }
        }
    }
    public void MyMove()
    {
        if (Input.GetKeyDown(KeyCode.A) && !Move)
        {
            int temp = LevelGenerator.GuanKa4[(int)vector2s[0].x, (int)vector2s[0].y - 1];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x, (int)vector2s[0].y - 1);
                Move = true;
                this.GetComponent<Animator>().SetInteger("State", 1);
                this.GetComponent<AudioSource>().Play();
            }
          
        }
        if (Input.GetKeyDown(KeyCode.D) && !Move)
        {
            int temp = LevelGenerator.GuanKa4[(int)vector2s[0].x, (int)vector2s[0].y + 1];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x, (int)vector2s[0].y + 1);
                Move = true;
                this.transform.localEulerAngles = new Vector3(0, 0, -90);
                this.GetComponent<Animator>().SetInteger("State",3);
                this.GetComponent<AudioSource>().Play();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.W) && !Move)
        {
            int temp = LevelGenerator.GuanKa4[(int)vector2s[0].x - 1, (int)vector2s[0].y];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x - 1, (int)vector2s[0].y);
                Move = true;
                this.GetComponent<Animator>().SetInteger("State", 2);
                this.GetComponent<AudioSource>().Play();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.S) && !Move)
        {
            int temp = LevelGenerator.GuanKa4[(int)vector2s[0].x + 1, (int)vector2s[0].y];
            if (temp == 5 || temp == 6 || temp == 0 || temp == 8)
            {
                vector2s[1] = new Vector2((int)vector2s[0].x + 1, (int)vector2s[0].y);
                Move = true;
                this.GetComponent<Animator>().SetInteger("State", 0);
                this.GetComponent<AudioSource>().Play();
            }
           
        }
        
        Vector3 vector3temp = new Vector3(-14 * 0.31f  + vector2s[1].y * 0.31f , 17 * 0.31f  - vector2s[1].x * 0.31f , 0);
        this.transform.position = Vector2.Lerp(this.transform.position, vector3temp, Time.deltaTime * 3);
        if (Vector2.Distance(this.transform.position, vector3temp) <= 0.05f)
        {
            this.GetComponent<AudioSource>().Pause();
            vector2s[0] = vector2s[1];
            Move = false;


        }
     
    }
    public void ZhuYe()
    {
        SceneManager.LoadScene(0);
    }
}
