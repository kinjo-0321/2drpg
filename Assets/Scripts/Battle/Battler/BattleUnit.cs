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

        //enemy:�摜�Ɩ��O�̐ݒ�
        //player:  �X�e�[�^�X�̐ݒ�
    }

    public virtual void UpdateUI()
    {

    }
}
