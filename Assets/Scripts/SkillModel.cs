using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�X�L���f�[�^���̂��̂Ƃ��̏���
public class SkillModel
{
    //�ꎞ�I�ɍ쐬�����v���C���[��HP
    /// <summary>
    /// //�I���W�i���v�f
    /// </summary>
    public double hp;


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

    public bool isAlive;
    public bool canAttack=true; 

    public SkillModel(int cardID) {
        SkillEntity skillEntity = Resources.Load<SkillEntity>("SkilEntityList/Skill"+cardID);
        charaName = skillEntity.charaName;
        skillName = skillEntity.skillName;
        appealAt = skillEntity.appealAt;
        attentionPer = skillEntity.attentionPer;
        attentionTurn = skillEntity.attentionTurn;
        damageCutPer = skillEntity.damageCutPer;
        damageCutTurn = skillEntity.damageCutTurn;
        interestPer = skillEntity.interestPer;
        interestTurn = skillEntity.interestTurn;
        buffPer = skillEntity.buffPer;
        buffTurn = skillEntity.buffTurn;
        icon = skillEntity.icon;
        isAlive = true;
    }

    void Damage(double dmg) {

        hp -= dmg;
        if (hp <= 0) {
            hp = 0;
            isAlive = false;
        }

    }


    public void Attack(SkillController skill) {
        skill.model.Damage(appealAt);
    }




}
