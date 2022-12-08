using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //手札にカードを生成
    [SerializeField] Transform HandSkillTansform;
    [SerializeField] GameObject skillPrefab;

    void Start()
    {
        CreateSkill(HandSkillTansform);

    }

    void CreateSkill(Transform space) {
        Instantiate(skillPrefab, space, false);
    }

}
