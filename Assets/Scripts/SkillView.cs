using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charaNameText;
    [SerializeField] TextMeshProUGUI skillNameText;
    [SerializeField] TextMeshProUGUI appealAtText;
    [SerializeField] TextMeshProUGUI attentionPerText;
    [SerializeField] TextMeshProUGUI attentionTurnText;
    [SerializeField] TextMeshProUGUI damageCutPerText;
    [SerializeField] TextMeshProUGUI damageCutTurnText;
    [SerializeField] TextMeshProUGUI intererstPerText;
    [SerializeField] TextMeshProUGUI interestTurnText;
    [SerializeField] TextMeshProUGUI buffPerText;
    [SerializeField] TextMeshProUGUI buffTurnText;
    [SerializeField] Image iconImage;
    //多分使わない。スキルが使用可能かを表示するのに使う
    [SerializeField] GameObject selectablePanel;



    public void Show(SkillModel skillModel) {
        charaNameText.text = skillModel.charaName;
        skillNameText.text = skillModel.skillName;
        appealAtText.text = skillModel.appealAt.ToString() + "倍";
        attentionPerText.text = skillModel.attentionPer.ToString()+"%";
        attentionTurnText.text = skillModel.attentionTurn.ToString() + "ターン";
        damageCutPerText.text = skillModel.damageCutPer.ToString() + "%";
        damageCutTurnText.text = skillModel.damageCutTurn.ToString() + "ターン";
        intererstPerText.text = skillModel.interestPer.ToString() + "%";
        interestTurnText.text = skillModel.interestTurn.ToString() + "ターン";
        buffPerText.text = skillModel.buffPer.ToString() + "%";
        buffTurnText.text = skillModel.buffTurn.ToString() + "ターン";
        iconImage.sprite = skillModel.icon;
    }

    public void Refresh(SkillModel skillModel)
    {
        charaNameText.text = skillModel.charaName;
        skillNameText.text = skillModel.skillName;
        appealAtText.text = skillModel.appealAt.ToString();
        attentionPerText.text = skillModel.attentionPer.ToString();
        attentionTurnText.text = skillModel.attentionTurn.ToString();
        damageCutPerText.text = skillModel.damageCutPer.ToString();
        damageCutTurnText.text = skillModel.damageCutTurn.ToString();
        intererstPerText.text = skillModel.interestPer.ToString();
        interestTurnText.text = skillModel.interestTurn.ToString();
        buffPerText.text = skillModel.buffPer.ToString();
        buffTurnText.text = skillModel.buffTurn.ToString();
        iconImage.sprite = skillModel.icon;
    }


    //アクティブの表示非表示切り替え
    public void SetActiveSelectablePanel(bool flag) {
        //selectablePanel.SetActive(flag);
    }

}
