using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredient : MonoBehaviour {

    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 0.02f;

    public string ingredientName = "";
    private bool check_player;

    public GameObject ingredients;

    private AudioSource audio;
    public AudioClip collectSound;

    void Start () {

        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = collectSound;
        audio.loop = false;

        check_player = false;
        if(PlayerPrefs.GetInt(ingredientName) == 1)
        {
            Destroy(ingredients);
        }
	}
	
	void Update () {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, pos.y + newY * height, pos.z);

        // when collision happens
        if (check_player)
        {
            audio.Play();
            convertManager();
            Destroy(ingredients);
        }
    }

    #region 충돌 체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어 들어왔다 표시
        if (collision.CompareTag("Player"))
        {
            check_player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //플레이어 나갔다 표시
        if (collision.CompareTag("Player"))
        {
            check_player = false;
        }
    }

    #endregion

    //플레이어 닿음 여부 반환
    public bool GetCheckPlayer()
    {
        return check_player;
    }

    private void convertManager()
    {
        PlayerPrefs.SetInt(ingredientName, 1);
    }
}

