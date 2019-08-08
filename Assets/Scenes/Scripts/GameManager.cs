using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public Image Wheat_UI;
    public Sprite wheat;

    public Image Onion_UI;
    public Sprite onion;

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
       if(PlayerPrefs.GetInt("Wheat") == 1)
        {
            Wheat_UI.sprite = wheat;
        }
        else if(PlayerPrefs.GetInt("Onion") == 1)
        {
            Onion_UI.sprite = onion;
        }
	}

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Wheat", 0);
        PlayerPrefs.SetInt("Onion", 0);
        PlayerPrefs.Save();
    }

}
