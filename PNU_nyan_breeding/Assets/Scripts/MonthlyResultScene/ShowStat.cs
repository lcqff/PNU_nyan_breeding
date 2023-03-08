using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowStat : MonoBehaviour
{
    public GameObject stat; // stat prefabs
    public TextMeshProUGUI statChange; //
     public TextMeshProUGUI statOrigin; 
    
    void Start()
    {
          for(int i=0;i<7;i++){//money stat제외
            
            var statItem=Instantiate(stat,transform); //자식 객체 생성
            statItem.name = "statObj";//자식객체 이름 설정
            statItem.transform.localScale = new Vector3(1.29f, 1.29f, 0f);
         
            statItem.transform.localPosition=new Vector3(0f, 1f -i*90f , 0f); 
            var origin = MonthlyResultManager.playerStat[i] + MonthlyResultManager.Diff[i];
            
            statOrigin.text += origin+"\n";
            
      
            if(MonthlyResultManager.Diff[i]>0){
                statItem.transform.Find("Origin").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i];
                statItem.transform.Find("Change").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i] + MonthlyResultManager.Diff[i];
                statItem.transform.Find("Change").Find("Fill Area").Find("Fill").GetComponent<Image>().color  = new Color(0,0,255); //파란색

                statChange.text += "<color=blue>+" + MonthlyResultManager.Diff[i] + "</color>\n" ;
                
            }
            else if (MonthlyResultManager.Diff[i]<0){
                statItem.transform.Find("Change").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i];
                statItem.transform.Find("Origin").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i] + MonthlyResultManager.Diff[i];

                //statItem.transform.Find("Change").Find("Fill Area").Find("Fill").GetComponent<Image>().color  = new Color(0,0,255); //파란색
                
                statChange.text += "<color=red>" + MonthlyResultManager.Diff[i] + "</color>\n" ;
            
            }
            else{ 
                statItem.transform.Find("Origin").GetComponent<Slider>().value = MonthlyResultManager.playerStat[i];
                statChange.text += "" + MonthlyResultManager.Diff[i] + "\n" ;
          
            }
        }

        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
