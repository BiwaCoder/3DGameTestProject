using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharcterData
{
    public int Hp;
    public int Strength;
    public int Speed;

    public enum ItemTyepe{
        //アイテム未所持
        None=0,
        //HP０になっても蘇生
        Revive=1,
        //絶対に先行
        MustFirstAttack=2,
        //HP2倍だけど攻撃力0.5倍
        HP2Attack05=3,
        //攻撃力1.5倍
        ATTACK15=4,
        //攻撃力3倍だけどミス30%
        ATTACK3_MISS30=5,
    }

    public ItemTyepe myItem;


    public CharcterData(int _Hp,int _Str,int _Speed,ItemTyepe _currentItem){
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        myItem = _currentItem;

        if(myItem == ItemTyepe.HP2Attack05){
            Hp = _Hp*2;
        }
        else{
            Hp = _Hp;
        }

        Strength = _Str;
        Speed = _Speed;
    }

    public int AddDamage(int dmg,ItemTyepe useItem){
        if(useItem == ItemTyepe.HP2Attack05){
            Hp -= (int)(dmg*0.5);
        }
        else if(useItem == ItemTyepe.ATTACK15){
            Hp -= (int)(dmg*1.5);
        }
        else if(useItem == ItemTyepe.ATTACK3_MISS30){
            int RandomValue = UnityEngine.Random.Range (0, 10);
            if(RandomValue <= 2){
                //miss
            }
            else{
                Hp -= (int)(dmg*3);
            }
        }
        else{
            Hp -= dmg;
        }
        return Hp;
    }

    public bool IsDead(){
        if(Hp <= 0){
            return true;
        }
        else{
            return false;
        }
    }

    public bool IsFirstAttack(int Enemy_Speed){

        int AllSpeed = Speed + Enemy_Speed;
        int RandomValue = UnityEngine.Random.Range (0, AllSpeed);
        if(RandomValue <= Speed){
            return true;
        }
        else{
            return false;
        }
    }
}
