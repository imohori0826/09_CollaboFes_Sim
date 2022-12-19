using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //��D�ɃJ�[�h�𐶐�
    [SerializeField] Transform HandSkillTansform;
    [SerializeField] SkillController SkillPrefab;

    void Start()
    {
        CreateSkill(HandSkillTansform);

    }

    void CreateSkill(Transform space) {
        SkillController skill = Instantiate(SkillPrefab, space, false);
        skill.Init(3);
    }

}
