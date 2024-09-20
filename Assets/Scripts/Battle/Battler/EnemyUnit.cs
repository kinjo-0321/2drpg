using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : BattleUnit
{
    [SerializeField] Image image;
    [SerializeField] Text nametext;
    public override void Setup(Battler battler)
    {
        base.Setup(battler);
        image.sprite = battler.Base.Sprite;
        nametext.text = battler.Base.Name;
    }
}
