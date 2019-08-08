using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MachinePortal : MonoBehaviour
{
    public GameManager manager;
    public string[] scenes = new string[4] { "Clear", "OnionOnly", "WheatOnly", "nothing" };

    //플레이어 닿았나 체크
    private bool check_player = false;

    //초기화
    private void Start()
    {
        check_player = false;
    }

    //업데이트
    private void Update()
    {
        if (check_player)
        {
            SceneManager.LoadScene(scenes[manager.status]);
        }
    }

    #region 충돌 체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어 들어왔다 표시
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("machine Stay");
            check_player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //플레이어 나갔다 표시
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("machine Exit");
            check_player = false;
        }
    }

    #endregion

    //플레이어 닿음 여부 반환
    public bool GetCheckPlayer()
    {
        return check_player;
    }

}
