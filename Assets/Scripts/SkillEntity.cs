using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SkillEntity",menuName ="Create SkillEntity")]

//ライブスキルデータそのものと処理
public class SkillEntity : ScriptableObject
{
    public string charaName;
    public string skillName;
    public double appealAt;
    public double attentionPer;
    public int attentionTurn;
    public double damageCutPer;
    public int damageCutTurn;
    public double interestPer;
    public int interestTurn;
    public double buffPer;
    public int buffTurn;
    public Sprite icon;
}
