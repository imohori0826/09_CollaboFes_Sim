using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    SkillView view;// 見かけ(view)に関することを操作
    SkillModel model; //データ(model)に関することを操作


    private void Awake()
    {
        view = GetComponent<SkillView>();
    }

    public void Init(int skillID) {
        model = new SkillModel(skillID);
        view.Show(model);
    }
}
