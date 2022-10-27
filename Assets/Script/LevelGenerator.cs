using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Sprite[] Thissprites;
    public GameObject[] gameMap;
    int[,] GuanKa =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {1,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {2,0,0,0,0,0,5,0,0,0,4,0,0,0},             
    };
   public static  int[,] GuanKa4 = new int[29, 28];
    // Start is called before the first frame update
    void Start()
    {
        int[,] GuanKa1=new int[14,14];
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GuanKa1[i,j] = GuanKa[13 - i,j];
            }
        }
        int[,] GuanKa2 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (i < 15)
                    GuanKa2[i, j] = GuanKa[i, j];
                else
                {
                    GuanKa2[i, j] = GuanKa1[i-15, j];
                }
            }
        }
        int[,] GuanKa3 = new int[29, 14];
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                GuanKa3[i, j] = GuanKa2[i, 13-j];
            }
        }
       

        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                if (j < 14)
                    GuanKa4[i, j] = GuanKa2[i, j];
                else
                {
                    GuanKa4[i, j] = GuanKa3[i , j-14];
                }
            }
        }
        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 28; j++)
            {
                bool BTrue = false;

                if (GuanKa4[i, j] == 0)
                {

                }
                else
                {
                    GameObject gameObject1 = GameObject.Instantiate(gameMap[GuanKa4[i, j] - 1]);
                    //gameObject1.GetComponent<SpriteRJieShuerer>().sprite = Thissprites[GuanKa4[i, j] - 1];


                    gameObject1.transform.position = new Vector3(-14 * 0.31f + j * 0.31f, 17 * 0.31f - i * 0.31f, 0);
                    if (GuanKa4[i, j] == 1)
                    {
                        if (i - 1 >= 0)
                        {
                            if (GuanKa4[i - 1, j] == 2 || GuanKa4[i - 1, j] == 1)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (GuanKa4[i, j - 1] == 2 || GuanKa4[i, j - 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (GuanKa4[i, j + 1] == 2 || GuanKa4[i, j + 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);

                                    }
                                }


                            }
                        }
                        if (i + 1 <= 28)
                        {
                            if (GuanKa4[i + 1, j] == 2 || GuanKa4[i + 1, j] == 1)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (GuanKa4[i, j - 1] == 2 || GuanKa4[i, j - 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (GuanKa4[i, j + 1] == 2 || GuanKa4[i, j + 1] == 1)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);

                                    }
                                }

                            }
                        }
                    }
                    if (GuanKa4[i, j] == 2)
                    {
                        if (i - 1 >= 0)
                        {
                            if (GuanKa4[i - 1, j] == 2 || GuanKa4[i - 1, j] == 1 || GuanKa4[i - 1, j] == 7)
                            {

                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);




                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (GuanKa4[i, j - 1] == 2 || GuanKa4[i, j - 1] == 1 || GuanKa4[i, j - 1] == 7)
                            {

                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);




                            }
                        }
                    }
                    if (GuanKa4[i, j] == 3)
                    {
                        if (i - 1 >= 0)
                        {
                            if (GuanKa4[i - 1, j] == 4 || GuanKa4[i - 1, j] == 3)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (GuanKa4[i, j - 1] == 4 || GuanKa4[i, j - 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                        if (GuanKa4[i - 1, j] == 4 && GuanKa4[i, j - 1] == 4)
                                        {
                                            BTrue = true;
                                        }
                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (GuanKa4[i, j + 1] == 4 || GuanKa4[i, j + 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                        if (GuanKa4[i - 1, j] == 4 && GuanKa4[i, j + 1] == 4)
                                        {
                                            BTrue = true;
                                        }

                                    }
                                }



                            }
                        }
                        if (j + 1 <= 27 && j - 1 >= 0 && i - 1 >= 0 && i + 1 <= 28)
                        {
                            if (GuanKa4[i - 1, j] == 4 || GuanKa4[i - 1, j] == 3)
                            {
                                if (GuanKa4[i + 1, j] == 4 || GuanKa4[i + 1, j] == 3)
                                {
                                    if (GuanKa4[i, j - 1] == 4 || GuanKa4[i, j - 1] == 3)
                                    {
                                        if (GuanKa4[i, j + 1] == 4 || GuanKa4[i, j + 1] == 3)
                                        {
                                            if (GuanKa4[i - 1, j] == 4 && GuanKa4[i, j - 1] == 4)
                                            {
                                                if (GuanKa4[i - 2, j] == 4 && GuanKa4[i, j - 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                                                    BTrue = true;
                                                }
                                            }
                                            if (GuanKa4[i - 1, j] == 4 && GuanKa4[i, j + 1] == 4)
                                            {
                                                if (GuanKa4[i - 2, j] == 4 && GuanKa4[i, j + 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                                    BTrue = true;
                                                }
                                            }
                                            if (GuanKa4[i + 1, j] == 4 && GuanKa4[i, j + 1] == 4)
                                            {
                                                if (GuanKa4[i + 2, j] == 4 && GuanKa4[i, j + 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                                    BTrue = true;
                                                }
                                            }
                                            if (GuanKa4[i + 1, j] == 4 && GuanKa4[i, j - 1] == 4)
                                            {
                                                if (GuanKa4[i + 2, j] == 4 && GuanKa4[i, j - 2] == 4)
                                                {
                                                    gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                                                    BTrue = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (i + 1 <= 28 && !BTrue)
                        {
                            if (GuanKa4[i + 1, j] == 4 || GuanKa4[i + 1, j] == 3)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (GuanKa4[i, j - 1] == 4 || GuanKa4[i, j - 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);

                                    }
                                }
                                if (j + 1 <= 27)
                                {
                                    if (GuanKa4[i, j + 1] == 4 || GuanKa4[i, j + 1] == 3)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);

                                    }
                                }

                            }
                        }

                    }
                    if (GuanKa4[i, j] == 4)
                    {
                        if (i - 1 >= 0)
                        {
                            if (GuanKa4[i - 1, j] == 3 || GuanKa4[i - 1, j] == 4 || GuanKa4[i - 1, j] == 7)
                            {
                                if (i + 1 <= 28)
                                {
                                    if (GuanKa4[i + 1, j] == 3 || GuanKa4[i + 1, j] == 4 || GuanKa4[i + 1, j] == 7)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                                    }
                                }



                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (GuanKa4[i, j - 1] == 3 || GuanKa4[i, j - 1] == 4 || GuanKa4[i, j - 1] == 7)
                            {
                                if (j + 1 <= 27)
                                {
                                    if (GuanKa4[i, j + 1] == 4 || GuanKa4[i, j + 1] == 3 || GuanKa4[i, j + 1] == 7)
                                    {
                                        gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                                    }
                                }



                            }
                        }
                    }
                    if (GuanKa4[i, j] == 7)
                    {
                        if (i - 1 >= 0)
                        {
                            if (GuanKa4[i - 1, j] == 3 || GuanKa4[i - 1, j] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 180);
                            }
                        }
                        if (i + 1 <= 27)
                        {
                            if (GuanKa4[i + 1, j] == 3 || GuanKa4[i + 1, j] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (GuanKa4[i, j - 1] == 3 || GuanKa4[i, j - 1] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 270);
                            }
                        }
                        if (j + 1 <= 27)
                        {
                            if (GuanKa4[i, j + 1] == 3 || GuanKa4[i, j + 1] == 4)
                            {
                                gameObject1.transform.localEulerAngles = new Vector3(0, 0, 90);
                            }
                        }

                    }
                }
            }
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
