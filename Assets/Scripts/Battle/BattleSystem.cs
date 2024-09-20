using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
public class BattleSystem : MonoBehaviour
{
   
    enum State
    {
        Start,
        ActionSelection,
        Moveselection,
        RunTurns,
        BattleOver,

    }

    State state;
    [SerializeField] ActionSelection actionselectionui;
    [SerializeField] MoveSelection moveselectionui;
    [SerializeField] BattleDialog BattleDialog;

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    public UnityAction OnBattleOver;


   public void BattleStart(Battler player, Battler enemy)
    {
        moveselectionui.Close();
        state = State.Start;
        Debug.Log("�o�g���J�n");
        actionselectionui.Init();
        moveselectionui.Init(player.Moves);
        actionselectionui.Close();
        StartCoroutine(SetupBattle(player, enemy));
    }

    IEnumerator SetupBattle(Battler player, Battler enemy)
    {
        playerUnit.Setup(player);
        enemyUnit.Setup(enemy);

        yield return BattleDialog.TypeDialog($"{enemy.Base.Name}�����ꂽ!\n�ǂ�����H");
        ActionSelection();
    }

    void BattleOver()
    {
        moveselectionui.DeleteMoveTexts();
        //gamecontroller.EndBattle();
        OnBattleOver?.Invoke();
    }

    private void ActionSelection()
    {
        state = State.ActionSelection;
        actionselectionui.Open();
    }

    private void MoveSelection()
    {
        state = State.Moveselection;
        moveselectionui.Open();
    }

    IEnumerator RunTurns()
    {
        state = State.RunTurns;
        Move playerMove = playerUnit.Battler.Moves[moveselectionui.SelectedIndex];
        yield return RunMove(playerMove, playerUnit, enemyUnit);
        if(state == State.BattleOver)
        {
            yield return BattleDialog.TypeDialog($"{enemyUnit.Battler.Base.Name}��|����", auto: false);
            playerUnit.Battler.hasExp += enemyUnit.Battler.Base.Exp;
            yield return BattleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�͌o���l{enemyUnit.Battler.Base.Exp}�𓾂�", auto: false);


            if (playerUnit.Battler.IsLevelUp())
            {
                playerUnit.UpdateUI();
                yield return BattleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�̓��x��{playerUnit.Battler.Level}�ɂȂ����I", auto: false);

                Move learnedMove = playerUnit.Battler.LearnedMove();
                if (learnedMove != null)
                {
                    yield return BattleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}��{learnedMove.Base.Name} ���o����");
                }
            }
            
            BattleOver();
            yield break;
        }

        Move enemyMove = enemyUnit.Battler.GetRandomMove();
        yield return RunMove(enemyMove, enemyUnit, playerUnit);
        if (state == State.BattleOver)
        {
            yield return BattleDialog.TypeDialog($"{playerUnit.Battler.Base.Name}�͓|��Ă��܂���");
            BattleOver();
            yield break;
        }

        yield return BattleDialog.TypeDialog("�ǂ�����H", auto: false);
        ActionSelection();
    }

    IEnumerator RunMove(Move move, BattleUnit sourceUnit, BattleUnit targetUnit)
    {
        string resultText = move.Base.RunMoveResult(sourceUnit, targetUnit);
        yield return BattleDialog.TypeDialog(resultText, auto: false);
        //int damage = targetUnit.Battler.TakeDamage(move, sourceUnit.Battler);
        //yield return BattleDialog.TypeDialog($"{sourceUnit.Battler.Base.Name}��{move.Base.Name}\n{targetUnit.Battler.Base.Name}��{damage}�̃_���[�W", auto: false);
        sourceUnit.UpdateUI();
        targetUnit.UpdateUI();

        if(targetUnit.Battler.HP <= 0)
        {
            state = State.BattleOver;
        }
    }

    private void Update()
    {
        switch(state)
        {
            case State.Start:
                break;
            case State.ActionSelection:
                HandleActionSelection();
                break;
            case State.Moveselection:
                HandleMoveSelection();
                break;
            case State.BattleOver:
                break;  
        }
    }

    void HandleActionSelection()
    {
        actionselectionui.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(actionselectionui.SelectedIndex == 0)
            {
                MoveSelection();
            }
            else if (actionselectionui.SelectedIndex == 1)
            {
                BattleOver();
            }
        }
    }

    void HandleMoveSelection()
    {
        moveselectionui.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveselectionui.Close();
            actionselectionui.Close();
            StartCoroutine(RunTurns());
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            moveselectionui.Close();
            ActionSelection();
        }
     
    }

}
