using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    //원하는 씬
    public string SceneName = "";

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
                //빈칸 아니면 씬 로드
                if (SceneName.Trim() != "")
                {
                    SceneManager.LoadScene(SceneName);
                }      
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

}
