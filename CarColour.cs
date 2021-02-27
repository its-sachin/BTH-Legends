using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColour : MonoBehaviour
{
    public static int CarType;//0-Blue, 1-Red

    public static int GameMode; //0-Race, 1-Score, 2-Time

    public void RedCar(){
        CarType = 1;
    }

    public void BlueCar(){
        CarType = 0;
    }

    public void RaceMode() {
        GameMode = 0;
    }

    public void ScoreMode() {
        GameMode = 1;
    }

    public void TimeMode() {
        GameMode = 2;
    }
}
