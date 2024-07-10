using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임을 직접 시작 했을 때의 스크립트. 어딜 가나 붙어있어야 하니 게임 오브젝트에 넣어서 DontDestory화 시켜놓기.
    //도대체 게임매니저에는 뭐가 들어가야하는거죠.?/................

    public GameObject gamemanager;      //이 스크립트를 넣을 게임 매니저를 가지고 온다.
    public GameObject ground;         //움직일 땅을 가져온다.
    public GameObject player;         //플레이어를 가져온다.
    public Rigidbody rig;            //플레이어의 리지드바디를 가지고 온다.
    public TextMeshPro startText;    //시작하기 전 텍스트를 띄운다.
    private bool GameStart;          //게임을 시작했는지에 대한 불 값을 가져온다.
    private bool Die;               //플레이어가 죽었는지 판별하기 위해 가져온다.
    private bool CLear;             //플레이어가 클리어 했는지 판별하기 위해 가져온다.
    

    void Awake()
    {
        player.SetActive(false);        //움직이지 못하게 false로 만들어준다.
        GameStart = false;              //Start 함수를 False로 만든다.
        DontDestroyOnLoad(gamemanager); //이 스크립트를 넣을 게임매니저 오브젝트를 사라지지 않게 한다.
    }
    void Start()
    {

    }

    void GamePlay()             //시작 했을 때 상황
    {
        if(Input.anyKeyDown)            //아무키나 누르면
        { 
            GameStart = true;            //게임 스타트를 true로 만들어준다.
            player.SetActive(true);      //움직일 수 있게 true로 만들어준다.
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Ground")        //장애물에 닿으면
        {
            player.SetActive(false);                    //플레이어의 움직임 끝
            SceneManager.LoadScene("GameOver");         //게임 오버씬으로 가!
        }
    }

    void Update()
    {
        GamePlay();
    }
}
