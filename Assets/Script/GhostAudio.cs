using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudio : MonoBehaviour
{
    public AudioClip[] audioClips;

    int YinXiao;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audioClips[0];
        this.GetComponent<AudioSource>().Play();
    }
    //鬼音效控制
    // Update is called once per frame
    void Update()
    {
        if (YinXiao == 1)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                this.GetComponent<AudioSource>().clip = audioClips[1];
                this.GetComponent<AudioSource>().Play();

            }

        }
        if (YinXiao == 2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                this.GetComponent<AudioSource>().clip = audioClips[2];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (YinXiao == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[3])
            {
                this.GetComponent<AudioSource>().clip = audioClips[3];
                this.GetComponent<AudioSource>().Play();

            }
        }
        if (this.GetComponent<AudioSource>().clip == audioClips[0] && !this.GetComponent<AudioSource>().isPlaying)
        {

            this.GetComponent<AudioSource>().loop = true;

            YinXiao = 1;

        }
        int Temp = 0;
        for (int i = 0; i < 4; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Ghost>().HasDie)
            {
                if (this.GetComponent<AudioSource>().clip != audioClips[3])
                {
                    YinXiao = 2;

                }
                else
                {
                    Temp++;
                }

            }
        }
        if (Temp == 4)
        {
            YinXiao = 1;
        }
        if (MainMove.ZhuangTai == 1 && YinXiao != 2)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[2])
            {
                YinXiao = 3;
            }

        }
        if (MainMove.ZhuangTai == 0 && YinXiao == 3)
        {
            if (this.GetComponent<AudioSource>().clip != audioClips[1])
            {
                YinXiao = 1;
            }

        }
    }
}
