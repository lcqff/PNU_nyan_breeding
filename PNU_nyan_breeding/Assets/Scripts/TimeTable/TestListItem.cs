using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;

public class TestListItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IScrollHandler
{
    public TMP_Text text;
    
    private Activity activity;
    private ScrollRect scrollRect;
    public void Init(Activity activity){
        this.activity=activity;
        text.text=activity.name;
        scrollRect=transform.parent.parent.parent.GetComponent<ScrollRect>();
    }
    public void OnBeginDrag(PointerEventData e){
        scrollRect.OnBeginDrag(e);
    }
    public void OnDrag(PointerEventData e){
        scrollRect.OnDrag(e);
    }
    public void OnEndDrag(PointerEventData e){
        scrollRect.OnEndDrag(e);
    }
    public void OnScroll(PointerEventData e){
        scrollRect.OnScroll(e);
    }
     public void OnClickItem(){ //Activity Type에 따른 텍스트 업데이트
        //text.text=TypeButton.GetActivityType().ToString();
        //Debug.Log(img_path);
        if(CalenderController.scheduleCount<3){
            if(TimeTableManager.curMoney+TimeTableManager.selectedMoney+activity.money_stat<0){
                ModalManager.instance.OpenModal("돈이 부족해!");
                return;
            }
            CalenderController.scheduleList.Add(activity);
            CalenderController.scheduleCount=CalenderController.scheduleList.Count;
            TimeTableManager.selectedMoney+=activity.money_stat;
            Debug.Log(CalenderController.scheduleCount);
        }
    }
    public void OnHoverItem(){
        TimeTableManager.tooltip.SetActive(true);
        TimeTableManager.tooltip.transform.Find("Title").gameObject.GetComponent<TMP_Text>().text=activity.name;
        
        var stats=TimeTableManager.tooltip.transform.Find("Stats").gameObject.GetComponent<TMP_Text>();
        Tuple<string, string> stat=GetStat();
        stats.text="<color=blue>"+stat.Item1+"</color>\n";
        stats.text+="<color=red>"+stat.Item2+"</color>";
        
        var money=TimeTableManager.tooltip.transform.Find("Amount").gameObject.GetComponent<TMP_Text>();
        if(activity.money_stat==0){
            money.text="";
            return;
        }
        if(activity.money_stat>0){
            money.text="<color=blue>"+activity.money_stat+"냥 수입</color>";
        }else if(activity.money_stat<0){
            money.text="<color=red>"+Mathf.Abs(activity.money_stat)+"냥 지출</color>";
        }
        
        
    }
    public void OnLeaveItem(){
        TimeTableManager.tooltip.SetActive(false);
    }
    private Tuple<string,string> GetStat(){
        var upStr="";
        var downStr="";
        if(activity.coding_stat>0) upStr+="코딩 ▲ ";
        else if(activity.coding_stat>0) downStr+="코딩 ▼ ";
        if(activity.know_stat>0) upStr+="이론 ▲ ";
        else if(activity.know_stat>0) downStr+="이론 ▼ ";
        if(activity.security_stat>0) upStr+="보안 ▲ ";
        else if(activity.security_stat>0) downStr+="보안 ▼ ";
        if(activity.sociality_stat>0) upStr+="사회성 ▲ ";
        else if(activity.sociality_stat>0) downStr+="사회성 ▼ ";
        if(activity.interest_stat>0) upStr+="흥미 ▲ ";
        else if(activity.interest_stat>0) downStr+="흥미 ▼ ";
        if(activity.stress_stat<0) upStr+="스트레스 ▼ ";
        else if(activity.stress_stat>0) downStr+="스트레스 ▲ ";

        return new Tuple<string,string>(upStr,downStr);
    } 
}
