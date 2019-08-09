using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Image Wheat_UI;
    public Sprite wheat;

    public Image Onion_UI;
    public Sprite onion;

    public Image Trophy_UI;
    public Sprite trophy;

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("W: "+ PlayerPrefs.GetInt("Wheat")+" O: "+ PlayerPrefs.GetInt("Onion")+ " T: "+ PlayerPrefs.GetInt("Trophy"));

        if (PlayerPrefs.GetInt("Wheat") == 1)
        {
            Wheat_UI.sprite = wheat;
        }
        if(PlayerPrefs.GetInt("Onion") == 1)
        {
            Onion_UI.sprite = onion;
        }
        if (PlayerPrefs.GetInt("Trophy") == 1)
        {
            Trophy_UI.sprite = trophy;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Wheat", 0);
        PlayerPrefs.SetInt("Onion", 0);
        PlayerPrefs.SetInt("trophy", 0);
        PlayerPrefs.Save();
    }

}
