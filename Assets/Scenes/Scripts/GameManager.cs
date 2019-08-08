using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class GameManager : MonoBehaviour {

    public static int ingredients = 4;

    public bool[] isGet = new bool[4];        //Onion, Wheat, , 
    public int status = 0;              // 0: nothing, 1: onion, 2: wheat, 3: clear

	// Use this for initialization
	void Start () {
        status = 0;

        for (int i = 0; i < 4; i++){
            isGet[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        status = checkStatus();
        //Debug.Log("status "+status);
	}

    private int checkStatus()
    {
        // nothing
        if (!isGet[0] && !isGet[1])
        {
            return 0;
        }
        // onion only
        else if (!isGet[0] && isGet[1])      
        {
            return 1;
        }
        // wheat only
        else if (isGet[0] && isGet[1])
        {
            return 2;
        }
        //clear
        else
        {
            return 3;
        }
    }
}
