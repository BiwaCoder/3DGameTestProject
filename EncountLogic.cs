using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncountLogic 
{
    public enum TimeState{
        Morning=0,
        Day=1,
        Night=2
    }

    //dummy logic 後で、時間を渡して時間帯を返すようにする
    public static TimeState GetTimeState(double currentTimeValue){
        return TimeState.Morning;
    }

    public static CharcterData Encount(TimeState currentTime){
        CharcterData EnemyData;
        if(currentTime == TimeState.Morning){
            EnemyData = new CharcterData(15,1,2,CharcterData.ItemTyepe.None);
        }
        else if(currentTime == TimeState.Day){
            EnemyData = new CharcterData(30,5,5,CharcterData.ItemTyepe.None);
        }
        else if(currentTime == TimeState.Night){
            EnemyData = new CharcterData(80,15,9,CharcterData.ItemTyepe.None);
        }
        else{
            EnemyData = new CharcterData(15,1,2,CharcterData.ItemTyepe.None);
        }

        return EnemyData;
    }
}
