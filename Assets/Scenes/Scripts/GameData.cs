using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public bool[] isGet = new bool[4] { false, false, false, false };        //Onion, Wheat, , 
    public int status = 0;              // 0: nothing, 1: onion, 2: wheat, 3: clear

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        status = checkStatus();

    }

    private int checkStatus()
    {
        // nothing
        if (isGet[0] == false && isGet[1] == false)
        {
            return 0;
        }
        // onion only
        else if (isGet[0] == false && isGet[1] == true)
        {
            return 1;
        }
        // wheat only
        else if (isGet[0] = true && isGet[1] == false)
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
