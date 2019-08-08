using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MachinePortal : MonoBehaviour
{
    public GameManager manager;

    //플레이어 닿았나 체크
    private bool check_player = false;
    private string scene = "";
    private int status;

    //초기화
    private void Start()
    {
        check_player = false;
    }

    //업데이트
    private void Update()
    {
        status = checkStatus();
        if (check_player)
        {
            switch (status) {
                case 0:
                    scene = "nothing";
                    break;
                case 1:
                    scene = "OnionOnly";
                    break;
                case 2:
                    scene = "WheatOnly";
                    break;
                case 3:
                    scene = "Clear";
                    break;
            }

            SceneManager.LoadScene(scene);
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

    private int checkStatus()
    {
        int[] isGet = new int[2];
        isGet[0] = PlayerPrefs.GetInt("Wheat");
        isGet[1] = PlayerPrefs.GetInt("Onion");

        // nothing
        if (isGet[0] != 1 && isGet[1] != 1)
        {
            return 0;
        }
        // onion only
        else if (isGet[0] != 1 && isGet[1] == 1)
        {
            return 1;
        }
        // wheat only
        else if (isGet[0] == 1 && isGet[1] != 1)
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
