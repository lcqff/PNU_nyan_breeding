using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject LoadSlotPage;
    public GameObject Shadow;
    private Player playerData = new Player();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickLoadGameButton()
    {
        Shadow.SetActive(true);
        LoadSlotPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
