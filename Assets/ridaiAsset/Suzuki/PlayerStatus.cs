using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus //: MonoBehaviour
{
    //Unityjou de tukawanai nara MonoBehaviour ha tukawanai

    //field
    public Collision touchCol;
    public bool footOn;

        //method
    public PlayerStatus(Collision col1, bool boo)
       {
            touchCol = col1;
            //stepCol = col2;
            footOn = boo;
       }

    public Collision GetTouchCol()
        {
            return touchCol;
        }

    /*public Collision GetStepCol()
       {
            return stepCol;
       }*/


    public bool GetFooton()
        {
            return footOn;
        }


}
