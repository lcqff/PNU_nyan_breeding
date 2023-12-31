using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public static Player playerData;
    public static PlayerInfo playerInfoData;
    public static PlayerStat playerStatData;

    public static List<int> playerStat = new List<int>();
    public static Dictionary<int, NPC> npcData;

    public static int flag = 0;

    void Awake()
    {
        playerData = Managers.Player.playerData;
        playerInfoData = Managers.Player.playerInfoData;  
        playerStatData = Managers.Player.playerStatData;  
        playerStat = playerStatData.GetStatList();
        npcData = Managers.Data.npcData;  
 
    }

    void Start()
    {
       // ModalManager.instance.OpenModal("1번째 튜토리얼입니다~",  YesOrNoButton );
        if (playerInfoData.month == 3 && playerInfoData.grade == 1 && flag == 0){
            ModalManager.instance.YesOrNoOpenModal("튜토리얼 볼것인가 말것인가!",YesButton,NoButton);
            flag = 1;  
        }
    }

    public void YesButton()
    {
        Debug.Log("네");
        SceneManager.LoadScene("TutorialHomeScene");
    }

    public void NoButton()
    {
        Debug.Log("아니오");
        
    }

}
