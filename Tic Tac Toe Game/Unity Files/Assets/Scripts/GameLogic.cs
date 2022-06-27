using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject o,x;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip_O,audioClip_X;

    //To change O - X one by one
    [SerializeField] int i = 0;

    [SerializeField] GameObject X_WinPanel,O_WinPanel,TiePanel;

    //List variable to Store the positions of X and O
    public List<Vector2> PosVec_O = new List<Vector2>();
    public List<Vector2> PosVec_X = new List<Vector2>();

    void Update()
    {
        InstantiateWhenTouch();
        TieLogic();
    }


/*
    Instantiate X-O Logic

        -We will instantiate X or O based on the value of i 
        -If i is even we will instantiate O on touch position inside the Tic Tac Toe Grid Only
        -If i is odd we will instantieate X on touch position inside the Tic Tac Toe Grid Only
*/
    private void InstantiateWhenTouch()
    {
        foreach (Touch touch in Input.touches)
        {
            //getting the touch position of the screen and change it to world points
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPos.x<1.5f && touchPos.x>-1.5f && touchPos.y<1.5f && touchPos.y>-1.5f && O_WinPanel.activeSelf == false && X_WinPanel.activeSelf == false)
            {
                //rounding off the touch position for equivalent world position
                Vector2 instantiatePos = new Vector2(Mathf.Round(touchPos.x), Mathf.Round(touchPos.y));

                if (touch.phase == TouchPhase.Began)
                {
                    if (i % 2 == 0 && i < 9)
                    {
                        if(PosVec_O.Contains(instantiatePos) == false && PosVec_X.Contains(instantiatePos) == false)
                        {
                            //instantiating O at the touch position
                            Instantiate(o, instantiatePos, Quaternion.identity);

                            //playing the sound
                            audioSource.PlayOneShot(audioClip_O);

                            //We are adding this position in the list PosVec_O
                            PosVec_O.Add(instantiatePos);
                            WinLogic_O();
                            i++;       
                        } 
                        
                    }
                    else if (i < 9)
                    {
                        if(PosVec_O.Contains(instantiatePos) == false && PosVec_X.Contains(instantiatePos) == false)
                        {
                            //Instantiating X at the touch position
                            Instantiate(x, instantiatePos, Quaternion.identity);

                            //playing the sound
                            audioSource.PlayOneShot(audioClip_X);

                            //We are adding this position in the list PosVec_X
                            PosVec_X.Add(instantiatePos);
                            WinLogic_X();
                            i++;
                        }
                        
                    }
                    
                }
            }

        }
    }

 /* Win Logic

        -We are storing the position of the X and O in the List PosVec_X and PosVec_O lists variables respectively
        -Then we will check if the list contains wining positions or not
        -If it contains Then We Will activate the Win Panel
        -If it doesn't contain then We will activate the TiePanel

*/ 
    private void WinLogic_X()
    {
        if (i > 3)
        {
            for (int j = -1; j <= 1; j++)
            {

                if (PosVec_X.Contains(new Vector2(-1, j)) && PosVec_X.Contains(new Vector2(0, j)) && PosVec_X.Contains(new Vector2(1, j)))
                {
                    X_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_X.Contains(new Vector2(j, -1)) && PosVec_X.Contains(new Vector2(j, 0)) && PosVec_X.Contains(new Vector2(j, 1)))
                {
                    X_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_X.Contains(new Vector2(-1, -1)) && PosVec_X.Contains(new Vector2(0, 0)) && PosVec_X.Contains(new Vector2(1, 1)))
                {
                    X_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_X.Contains(new Vector2(1, -1)) && PosVec_X.Contains(new Vector2(0, 0)) && PosVec_X.Contains(new Vector2(-1, 1)))
                {
                    X_WinPanel.SetActive(true);
                    break;
                }

            }

        }
    }

    private void WinLogic_O()
    {
        if (i > 3)
        {
            for (int j = -1; j <= 1; j++)
            {

                if (PosVec_O.Contains(new Vector2(-1, j)) && PosVec_O.Contains(new Vector2(0, j)) && PosVec_O.Contains(new Vector2(1, j)))
                {
                    O_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_O.Contains(new Vector2(j, -1)) && PosVec_O.Contains(new Vector2(j, 0)) && PosVec_O.Contains(new Vector2(j, 1)))
                {
                    O_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_O.Contains(new Vector2(-1, -1)) && PosVec_O.Contains(new Vector2(0, 0)) && PosVec_O.Contains(new Vector2(1, 1)))
                {
                    O_WinPanel.SetActive(true);
                    break;
                }
                else if (PosVec_O.Contains(new Vector2(1, -1)) && PosVec_O.Contains(new Vector2(0, 0)) && PosVec_O.Contains(new Vector2(-1, 1)))
                {
                    O_WinPanel.SetActive(true);
                    break;
                }

            }

        }
       
    }


/*
    Tie Logic

        -First We check all The win conditions
        -If no win condition was true then we are declaring the game is TIE
*/
    private void TieLogic()
    {
        if (i == 9 && O_WinPanel.activeSelf == false && X_WinPanel.activeSelf == false)
        {
            //activating TiePanel
            TiePanel.SetActive(true);
            i++;
        }
    }


}
