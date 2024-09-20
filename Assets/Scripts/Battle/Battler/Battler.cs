using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battler
{
    [SerializeField] BattlerBase _base;
    [SerializeField] int level;
    public int hasExp { get; set; }

    public BattlerBase Base { get => _base; }
    public int Level { get => level; }

    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int AT {  get; set; }

    public List<Move> Moves { get; set; }

    public void Init()
    {
        Moves = new List<Move>();
        foreach (var learnableMove in Base.LearnableMove)
        {
            if(learnableMove.Level <= level)
            {
                Moves.Add(new Move(learnableMove.MoveBase));
            }
        }
        Debug.Log(Moves.Count);

        MaxHP = _base.MaxHP;
        HP = MaxHP;
        AT = _base.AT;
    }

    public int TakeDamage(int movePower, Battler attacker)
    {
        int damage = attacker.AT+ movePower; // + move.Base.Power;
        HP = Mathf.Clamp(HP - damage, 0, MaxHP);
        return damage;
    }

    public void Heal(int healPoint)
    {
        HP = Mathf.Clamp(HP + healPoint,0, MaxHP);
 
    }

    public Move GetRandomMove()
    {
        int r= Random.Range(0, Moves.Count);
        Debug.Log(r);   
        return Moves[r];
    }

    public bool IsLevelUp()
    {
        if(hasExp >= 100)
        {
            hasExp -= 100;
            level++;
            return true;
        }
        return false;
    }

    public Move LearnedMove()
    {
        foreach (var learnableMove in Base.LearnableMove)
        {
            if (learnableMove.Level <= level && !Moves.Exists(move => move.Base == learnableMove.MoveBase))
            {
                Move move = new Move(learnableMove.MoveBase);
                Moves.Add(move);
                return move;
            }
        }
        return null;
    }
}
