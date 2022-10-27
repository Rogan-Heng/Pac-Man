using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    float Xianshi;
    public GameObject ThisObj;
    // Start is called before the first frame update
    void Start()
    {
        Xianshi = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Xianshi -= Time.deltaTime;
        if (Xianshi <= 0)
        {
            Xianshi = 30;
            GameObject gameObject2 = GameObject.Instantiate(ThisObj);
            gameObject2.transform.position = new Vector3(10, 0.8f, 0);
        }
    }
}
