using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeButton : MonoBehaviour
{   
    public int type;
    public Button button;
    private Vector3 originPos;
    private Vector3 selectedPos;

    public void Start(){
        originPos=button.transform.localPosition;
        selectedPos=originPos;
        selectedPos.x += 30f; 
        selectedPos.y += 15f;
    }
    public void Update(){
        //button.image.color=((int)TestGUI.currentType==type)?Color.yellow:Color.white;
        if((int)TestGUI.currentType==type){
            button.transform.localPosition=selectedPos;
        }else{
            button.transform.localPosition=originPos;
        }
    }
    public void OnClickTypeButton(){
        TestGUI.currentType=(ActivityType)type; //type 업데이트
        
        //testGUI.onTypeChange(); //목록 업데이트
        Debug.Log(type);    
    }
}
