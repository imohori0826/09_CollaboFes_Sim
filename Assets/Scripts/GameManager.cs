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


    [SerializeField] Transform StockSkilllTansform;    //ストックにカードを生成
    [SerializeField] Transform HandSkillTansform;    //手札にスキルを生成
    [SerializeField] Transform TrashSkillTansform;    //手札にスキルを生成
    //    [SerializeField] Transform PlayerFieldTansform;    //手札にスキルを生成

    [SerializeField] SkillController SkillPrefab;
    bool isPlayerTurn;

    List<int> handSkillList  = new List<int>() { 1,2,3 },
              stockSkillList = new List<int>() { 4,5,6,7,8,9,0 };



    [SerializeField] TextMeshProUGUI playerHeroHpText;
    [SerializeField] TextMeshProUGUI enemyHeroHpText;

    double playerHeroHp;
    double enemyHeroHp;


    //シングルトン化(どこからでもアクセス出来るようにする)
    public static GameManager instance;


    //シングルトン使う時のおまじない。
    //エラー回避出来る
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
        //handとfieldの削除
        //ハンドの子要素がskkillに入ってくる
        foreach (Transform skill in HandSkillTansform) {
            Destroy(skill.gameObject);
        }
        //ストックを破壊
        foreach (Transform skill in StockSkilllTansform)
        {
            Destroy(skill.gameObject);
        }
        //ゴミ箱も破壊したい
        
        foreach (Transform skill in TrashSkillTansform)
        {
            Destroy(skill.gameObject);
        }
        


        //デッキの生成
        handSkillList = new List<int>() { 1, 2, 3 };
 　　　 stockSkillList = new List<int>() { 4, 5, 6, 7, 8, 9, 0 };

        StartGame();

    }

    void SettingInitHand()
    {
        //カードを2枚配る
        for (int i = 0; i < 3; i++)
        {
            GiveSkillToHand(handSkillList,HandSkillTansform);
        }


        //ストックスペースに残りの7枚配る
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

    //ストックが空になった時にターンエンドした場合、ゴミ箱からストックに再移動させるメソッド
    //オリジナルメソッド。
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
        //フィールドカードを攻撃可能にする
        //ストックのカード一覧を取得取得
        /**
        SkillController[] handSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();

        foreach (SkillController skill in handSkillList) {
            //カードを攻撃可能にする
            skill.SetCanAttack(true);
        }
        */


    }


        public void EnemyTurn()
        {
        Debug.Log("EnemyTurn");
        //フィールドカードを攻撃可能にする

        /*場にカードを出す*/
        //ストック上にあるカードリストを取得。要素を全部集めてくる
        SkillController[] handSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();


        //場に出すカードリストを取得
        SkillController enemySkill = handSkillList[0];

        //スキルを移動
        enemySkill.movement.SetSkillTransform(HandSkillTansform);

        /*攻撃         **/
        //フィールドのカードリストを取得
        SkillController[] fieldSkillList = StockSkilllTansform.GetComponentsInChildren<SkillController>();
        //攻撃可能カードを取得
        //cardのcard.model.canAttackがtrueだったら左辺のenemyCanAttackCardListに入れていく
        SkillController[] enemyCanAttackCardList = Array.FindAll(fieldSkillList,card =>card.model.canAttack);   //配列の中の要素から条件に合うものを検索：Array.FindAll
         //defenderカード一覧を取得
//        SkillController[] PlayerFieldCardList = StockSkilllTansform.GetComponentsInChildren<SkillController>();

        if (enemyCanAttackCardList.Length>0&& fieldSkillList.Length>0) {
            //attackerカードを選択(ストックから選択)
            SkillController attacker = fieldSkillList[0];


            //        SkillController defender = PlayerFieldCardList[0];
            //attackerとdefenderを戦わせる
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
