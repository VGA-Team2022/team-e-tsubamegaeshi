using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum BattleState
    {
        //�Ƃ肠��������񂯂����
        NONE = 0,
        Rock = 1,//�O�[/Right
        Scissors = 2,//�`���L/Light
        Paper = 3,//�p�[/Down
        Special = 4 // �K�E!���Ԃ�!!
    }

    public BattleState _playerState = BattleState.NONE;

    public BattleState _enemyState = BattleState.NONE;

    public enum BattleEndState//���s
    {
        NONE = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
        Special = 4,
    }
    public BattleEndState battleEndState = BattleEndState.NONE;

    public float _interval = 1f;

    bool BattleCheck = false;

    [SerializeField]//�m�F�p
    private FlickManager _flickTest;//�t���b�N����

    [SerializeField]//�m�F�p
    private DistanceManager _distanceManager;//�o�g������

    [SerializeField]
    private ActionOnDisplay _actionOnDisplay; // �U���\��

    [SerializeField]
    private float _attackTimer = 1f;

    private float _timer;

    public PlayerStateController _playerStateController;
    public EnemyStateController _enemyStateController;

    [SerializeField]
    Animator _playerAnim;
    [SerializeField]
    Animator _enemyAnim;

    private void Start()
    {
        switch(LevelController.Instance.LevelState)
        {
            case LevelState.EASY:
                {
                    _attackTimer = LevelController.Instance._easyPlayerStatus[4];
                }
                break;
            case LevelState.NORMAL:
                {
                    _attackTimer = LevelController.Instance._normalPlayerStatus[4];
                }
                break;
            case LevelState.HARD:
                {
                    _attackTimer = LevelController.Instance._hardPlayerStatus[4];
                }
                break;
            case LevelState.EXPART:
                {
                    _attackTimer = LevelController.Instance._expartPlayerStatus[4];
                }
                break;
        }
    }

    private void Update()
    {
        if (!_playerAnim || !_enemyAnim)
        {
            _playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
            _enemyAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
        }
        if (!_distanceManager._isBattleCheck)
        {
            PlayerStateSet();
        }

        _playerAnim.SetInteger("ActionState", ((int)_flickTest.NowSwipe));
        _playerAnim.SetInteger("BattleState", ((int)battleEndState));

        _enemyAnim.SetInteger("ActionState", ((int)_enemyState));
        _enemyAnim.SetInteger("BattleState", ((int)battleEndState));

    }

    /// <summary>
    /// �퓬�J�n���ɌĂԏ���
    /// </summary>
    public void BattleStart()
    {
        Debug.Log("�퓬�J�n");
        EnemyStateSet();
    }

    public void AttackTimer()
    {
        StartCoroutine(AttackTimerCoroutine());
    }

    IEnumerator AttackTimerCoroutine()
    {
        yield return new WaitForSeconds(_attackTimer);
        ChangeBattleEndState(BattleEndState.Lose);
    }

    /// <summary>
    /// �G�l�~�[�̏o��������߂ĕύX���鏈��
    /// </summary>
    public void EnemyStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch (rdm)
        {
            case 1:
                _enemyState = BattleState.Rock;
                _enemyStateController.OnEnemyChangeMode(BattleState.Rock);
                _actionOnDisplay.OnDisplay(0, _attackTimer);
                Debug.Log($"�G:{BattleState.Rock}");
                break;
            case 2:
                _enemyState = BattleState.Scissors;
                _enemyStateController.OnEnemyChangeMode(BattleState.Scissors);
                _actionOnDisplay.OnDisplay(1, _attackTimer);
                Debug.Log($"�G:{BattleState.Scissors}");
                break;
            case 3:
                _enemyState = BattleState.Paper;
                _enemyStateController.OnEnemyChangeMode(BattleState.Paper);
                _actionOnDisplay.OnDisplay(2, _attackTimer);
                Debug.Log($"�G:{BattleState.Paper}");
                break;
        }
    }

    public void EnemyStateSpecial()
    {
        _enemyState = BattleState.Special;
        _enemyStateController.OnEnemyChangeMode(BattleState.Special);
        _actionOnDisplay.OnDisplay(3, 10f);
        BattleCheck = false;
        Debug.Log($"�G:{BattleState.Special}");
    }

    /// <summary>
    /// �f�o�b�N�p
    /// </summary>
    void PlayerStateSet()
    {
        switch (_flickTest.NowSwipe)
        {
            case FlickManager.FlickState.LEFT:
                _playerState = BattleState.Rock;
                _playerStateController.OnPlayerChangeMode(BattleState.Rock);
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Rock}");
                break;
            case FlickManager.FlickState.RIGHT:
                _playerState = BattleState.Scissors;
                _playerStateController.OnPlayerChangeMode(BattleState.Scissors);
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Scissors}");
                break;
            case FlickManager.FlickState.DOWN:
                _playerState = BattleState.Paper;
                _playerStateController.OnPlayerChangeMode(BattleState.Paper);
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Paper}");
                break;
            case FlickManager.FlickState.UP:
                _playerState = BattleState.Special;
                _playerStateController.OnPlayerChangeMode(BattleState.Special);
                Battle();
                Debug.Log($"�v���C���[:{BattleState.Special}");
                break;
            case FlickManager.FlickState.NONE:
                _playerState = BattleState.NONE;
                //Debug.Log($"�v���C���[:{BattleState.NONE}");
                break;

        }
    }
    /// <summary>
    /// �f�o�b�N�p�X�e�[�g���Z�b�g
    /// </summary>
    void StateReSet()
    {
        Debug.Log("���Z�b�g");
        BattleCheck = true;
        StartCoroutine(BattleInterval());
    }

    /// <summary>
    /// ���s�𔻒肷�鏈��
    /// </summary>
    void Battle()
    {
        switch (_playerState)
        {
            case BattleState.Rock:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }

                }
                break;
            case BattleState.Scissors:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                }
                break;
            case BattleState.Paper:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("����");
                        ChangeBattleEndState(BattleEndState.Lose);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("������");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                }
                break;
            case BattleState.Special:
                {
                    if (_enemyState == BattleState.Special)
                    {
                        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaa");
                        ChangeBattleEndState(BattleEndState.Special);
                    }
                }
                break;
            case BattleState.NONE:
                {
                }
                break;
        }

    }

    /// <summary>
    /// �����ɏ��s�̌�̏����������������͌Ăяo��
    /// </summary>
    /// <param name="next"></param>
    public void ChangeBattleEndState(BattleEndState next)
    {
        //_isBattele = false;

        if (BattleCheck) { return; }

        var prev = battleEndState;
        battleEndState = next;
        switch (battleEndState)
        {
            case BattleEndState.NONE:
                {

                }
                break;
            case BattleEndState.Win:
                {
                    Debug.Log($"�퓬����{next}");
                    _distanceManager?.SetUp(BattleEndState.Win);
                    StateReSet();
                }
                break;
            case BattleEndState.Lose:
                {
                    Debug.Log($"�퓬����{next}");
                    _distanceManager?.SetUp(BattleEndState.Lose);
                    StateReSet();
                }
                break;
            case BattleEndState.Draw:
                {
                    Debug.Log($"�퓬����{next}");
                    _distanceManager?.SetUp(BattleEndState.Draw);
                    StateReSet();
                }
                break;
            case BattleEndState.Special:
                {
                    Debug.Log($"�퓬����{next}");
                    _distanceManager?.SetUp(BattleEndState.Special);
                    //StateReSet();
                }
                break;
        }
    }
    IEnumerator BattleInterval()
    {
        yield return new WaitForSeconds(_interval);
        _enemyState = BattleState.NONE;
        BattleCheck = false;
    }
}
