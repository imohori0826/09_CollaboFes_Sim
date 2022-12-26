using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI resultText;


    [SerializeField] Transform StockSkilllTansform;    //�X�g�b�N�ɃJ�[�h�𐶐�
    [SerializeField] Transform HandSkillTansform;    //��D�ɃX�L���𐶐�
    [SerializeField] Transform TrashSkillTansform;    //��D�ɃX�L���𐶐�
    //    [SerializeField] Transform PlayerFieldTansform;    //��D�ɃX�L���𐶐�

    [SerializeField] SkillController SkillPrefab;
    bool isPlayerTurn;

    List<int> handSkillList  = new List<int>() { 1,2,3 },
              stockSkillList = new List<int>() { 4,5,6,7,8,9,0 };



    [SerializeField] TextMeshProUGUI playerHeroHpText;
    [SerializeField] TextMeshProUGUI enemyHeroHpText;

    double playerHeroHp;
    double enemyHeroHp;


    //�V���O���g����(�ǂ�����ł��A�N�Z�X�o����悤�ɂ���)
    public static GameManager instance;


    //�V���O���g���g�����̂��܂��Ȃ��B
    //�G���[����o����
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }


    void Start()
    {
        StartGame();

    }

    void StartGame() {
        resultPanel.SetActive(false);
        playerHeroHp = 100.0;
        enemyHeroHp = 10;
        ShowHeroHP();
        SettingInitHand();
        isPlayerTurn = true;
        TurnCalc();
    }


    public void Restart()
    {
        //hand��field�̍폜
        //�n���h�̎q�v�f��skkill�ɓ����Ă���
        foreach (Transform skill in HandSkillTansform) {
            Destroy(skill.gameObject);
        }
        //�X�g�b�N��j��
        foreach (Transform skill in StockSkilllTansform)
        {
            Destroy(skill.gameObject);
        }
        //�S�~�����j�󂵂���
        
        foreach (Transform skill in TrashSkillTansform)
        {
            Destroy(skill.gameObject);
        }
        


        //�f�b�L�̐���
        handSkillList = new List<int>() { 1, 2, 3 };
 �@�@�@ stockSkillList = new List<int>() { 4, 5, 6, 7, 8, 9, 0 };

        StartGame();

    }

    void SettingInitHand()
    {
        //�J�[�h��2���z��
        for (int i = 0; i < 3; i++)
        {
            GiveSkillToHand(handSkillList,HandSkillTansform);
        }


        //�X�g�b�N�X�y�[�X�Ɏc���7���z��
        for (int i = 0; i < 7; i++)
        {
            GiveSkillToHand(stockSkillList,StockSkilllTansform);
        }
    }

    void GiveSkillToHand(List<int> stock, Transform hand) {
        if (stock.Count==0) {
            return;
        }

        int skillID = stock[0];
        stock.RemoveAt(0);
        CreateSkill(skillID, hand);
    }

    void CreateSkill(int skillID,Transform space)
    {
        SkillController skill = Instantiate(SkillPrefab, space, false);
        skill.Init(skillID);
    }

    //�X�g�b�N����ɂȂ������Ƀ^�[���G���h�����ꍇ�A�S�~������X�g�b�N�ɍĈړ������郁�\�b�h
    //�I���W�i�����\�b�h�B
    void skillReset()
    {

    }





    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        if (isPlayerTurn)
        {
//            GiveSkillToHand(playerDeck, playerHandTransform);
            //CreateSkill(HandSkillTansform);
        }
        else {
//            GiveSkillToHand(enemyDeck, enemyHandTransform);

        }

        TurnCalc();
    }

    void TurnCalc()
         {
            if (isPlayerTurn)
            {
                  PlayerTurn();
             }
             else {
              EnemyTurn();
             }
         }


        public void PlayerTurn() {

        Debug.Log("PlayerTurn");
        //�t�B�[���h�J�[�h���U���\�ɂ���
        //�X�g�b�N�̃J�[�h�ꗗ���擾�擾
        /**
        SkillController[] handSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();

        foreach (SkillController skill in handSkillList) {
            //�J�[�h���U���\�ɂ���
            skill.SetCanAttack(true);
        }
        */


    }


        public void EnemyTurn()
        {
        Debug.Log("EnemyTurn");
        //�t�B�[���h�J�[�h���U���\�ɂ���

        /*��ɃJ�[�h���o��*/
        //�X�g�b�N��ɂ���J�[�h���X�g���擾�B�v�f��S���W�߂Ă���
        SkillController[] handSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();


        //��ɏo���J�[�h���X�g���擾
        SkillController enemySkill = handSkillList[0];

        //�X�L�����ړ�
        enemySkill.movement.SetSkillTransform(HandSkillTansform);

        /*�U��         **/
        //�t�B�[���h�̃J�[�h���X�g���擾
        SkillController[] fieldSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();
        //�U���\�J�[�h���擾
        //card��card.model.canAttack��true�������獶�ӂ�enemyCanAttackCardList�ɓ���Ă���
        SkillController[] enemyCanAttackCardList = Array.FindAll(fieldSkillList,card =>card.model.canAttack);   //�z��̒��̗v�f��������ɍ������̂������FArray.FindAll
         //defender�J�[�h�ꗗ���擾
//        SkillController[] PlayerFieldCardList = StockSkilllTansform.GetComponentsInChildren<SkillController>();

        if (enemyCanAttackCardList.Length>0&& fieldSkillList.Length>0) {
            //attacker�J�[�h��I��(�X�g�b�N����I��)
            SkillController attacker = fieldSkillList[0];


            //        SkillController defender = PlayerFieldCardList[0];
            //attacker��defender���킹��
            //SkillBattle(attacker,defender);
        }



        ChangeTurn();

        }


    public void SkillBattle(SkillController attacker, SkillController defender) {
        Debug.Log("attacker HP:" + attacker.model.hp);
        Debug.Log("defender HP:" + defender.model.hp);
        attacker.Attack(defender);
        defender.Attack(attacker);

        attacker.CheckAlive();
        defender.CheckAlive();

    }

    void ShowHeroHP() {

        playerHeroHpText.text = playerHeroHp.ToString();
        enemyHeroHpText.text = enemyHeroHp.ToString();
    }


    public void AttackedToHero(SkillController attacker, bool isHandSkill) {

        if (isHandSkill)
        {
            enemyHeroHp -= attacker.model.appealAt;

        }
        else {
            playerHeroHp -= attacker.model.appealAt;
        }
        ShowHeroHP();
        CheckHeroHP();
    }

    void CheckHeroHP() {
        if (playerHeroHp<=0||enemyHeroHp<=0) {

            resultPanel.SetActive(true);
            if (playerHeroHp == 0)
            {
                resultText.text = "LOSE";

            }
            else {
                resultText.text = "WIN";
            }


        }
    }


}
