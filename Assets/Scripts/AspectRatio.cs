using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    public GameObject gameOverPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Screen.width / Screen.height >= 1.3)
        {
            
            if (Screen.width / Screen.height >= 1.7)
            {
                
                if (Screen.width / Screen.height >= 2.2)
                {
                    // 20:9 == 2.2222  1280x576
                }
                else
                {
                    // 19:6 == 1.7777  1280x720
                }

            }
            else
            {
                // 4:3  == 1.3333  1280x960
            }
        }            
        }        
        //Solved the problem by making canvas scale with height only
        //Kept the code just in case
    }

