using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    CharcterData PlayerData;

    CharcterData EnemyData;

    TurnBattle turnBattleData;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = new CharcterData(100,10,7,CharcterData.ItemTyepe.None);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEncount(){
        if(EnemyData == null){
            EnemyData = EncountLogic.Encount(EncountLogic.GetTimeState(0.0f));
        }
        else{
            Debug.Log("すでに敵にエンカウントしています！");
        }
    }

    public void OnClicksNextTurn(){
        TurnData tempTurnData;
         if(EnemyData != null){
            if(turnBattleData==null){
                turnBattleData = new TurnBattle(PlayerData,EnemyData);
            }
            else{
                tempTurnData = turnBattleData.TurnAction();
                Debug.Log($"PlayerDmg:{tempTurnData.PlayerDmg} EnemyDmg:{tempTurnData.EnemyDmg} PlayerIsDead:{tempTurnData.PlayerIsDead} EnemyIsDead:{tempTurnData.EnemyIsDead}");
            
            }
         }
         else{
            Debug.Log("敵とエンカウントしてください");
         }
    }
}
