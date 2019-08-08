using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour {

    public string SceneName;

    private float timer;
    public float waitingTime;

	// Use this for initialization
	void Start () {
        timer = 0f;
        waitingTime = 2f;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            //Action
            timer = 0;
        }
     
    }

    private void LateUpdate()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
