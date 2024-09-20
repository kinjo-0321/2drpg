using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{


    public Battler Battler { get; set; }

    public virtual void Setup(Battler battler)
    {
        Battler = battler;

        //enemy:画像と名前の設定
        //player:  ステータスの設定
    }

    public virtual void UpdateUI()
    {

    }
}
