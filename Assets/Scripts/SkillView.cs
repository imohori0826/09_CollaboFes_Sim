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

    public void Show(SkillModel skillModel) {
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
}
