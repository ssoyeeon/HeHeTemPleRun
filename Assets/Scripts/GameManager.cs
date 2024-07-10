using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //������ ���� ���� ���� ���� ��ũ��Ʈ. ��� ���� �پ��־�� �ϴ� ���� ������Ʈ�� �־ DontDestoryȭ ���ѳ���.
    //����ü ���ӸŴ������� ���� �����ϴ°���.?/................

    public GameObject gamemanager;      //�� ��ũ��Ʈ�� ���� ���� �Ŵ����� ������ �´�.
    public GameObject ground;         //������ ���� �����´�.
    public GameObject player;         //�÷��̾ �����´�.
    public Rigidbody rig;            //�÷��̾��� ������ٵ� ������ �´�.
    public TextMeshPro startText;    //�����ϱ� �� �ؽ�Ʈ�� ����.
    private bool GameStart;          //������ �����ߴ����� ���� �� ���� �����´�.
    private bool Die;               //�÷��̾ �׾����� �Ǻ��ϱ� ���� �����´�.
    private bool CLear;             //�÷��̾ Ŭ���� �ߴ��� �Ǻ��ϱ� ���� �����´�.
    

    void Awake()
    {
        player.SetActive(false);        //�������� ���ϰ� false�� ������ش�.
        GameStart = false;              //Start �Լ��� False�� �����.
        DontDestroyOnLoad(gamemanager); //�� ��ũ��Ʈ�� ���� ���ӸŴ��� ������Ʈ�� ������� �ʰ� �Ѵ�.
    }
    void Start()
    {

    }

    void GamePlay()             //���� ���� �� ��Ȳ
    {
        if(Input.anyKeyDown)            //�ƹ�Ű�� ������
        { 
            GameStart = true;            //���� ��ŸƮ�� true�� ������ش�.
            player.SetActive(true);      //������ �� �ְ� true�� ������ش�.
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Ground")        //��ֹ��� ������
        {
            player.SetActive(false);                    //�÷��̾��� ������ ��
            SceneManager.LoadScene("GameOver");         //���� ���������� ��!
        }
    }

    void Update()
    {
        GamePlay();
    }
}
