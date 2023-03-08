using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBattle 
{
    public CharcterData PlayerData;
    public CharcterData EnemyData;

    public TurnBattle(CharcterData PlayerData, CharcterData EnemyData){
        this.PlayerData = PlayerData;
        this.EnemyData = EnemyData;
    }

    public TurnData TurnAction(){
        int playerDmg=0;
        int enemyDmg=0;
        if(PlayerData.IsFirstAttack(EnemyData.Speed)){
            enemyDmg = EnemyData.AddDamage(PlayerData.Strength,PlayerData.myItem);
            if(!EnemyData.IsDead()){
                playerDmg = PlayerData.AddDamage(EnemyData.Strength,EnemyData.myItem);
            }
        }
        else{
            playerDmg = PlayerData.AddDamage(EnemyData.Strength,EnemyData.myItem);
            if(!PlayerData.IsDead()){
                enemyDmg = EnemyData.AddDamage(PlayerData.Strength,PlayerData.myItem);
            }
        }

        TurnData returnData = new TurnData(playerDmg,enemyDmg,PlayerData.IsDead(),EnemyData.IsDead());
        return returnData;

    }
}

public class TurnData{
    public int PlayerDmg;
    public int EnemyDmg;

    public bool PlayerIsDead;
    public bool EnemyIsDead;

    public TurnData(int PlayerDmg,int EnemyDmg,bool PlayerIsDead,bool EnemyIsDead)
    {
        this.PlayerDmg = PlayerDmg;
        this.EnemyDmg = EnemyDmg;
        this.PlayerIsDead  = PlayerIsDead;
        this.EnemyIsDead = EnemyIsDead;
    }
}
