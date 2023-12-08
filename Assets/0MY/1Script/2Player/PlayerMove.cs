using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    SlimeSoulInputSystem inputActionsSystem;
    Rigidbody2D rb;
    Vector2 movementInput;
    [SerializeField] private float speed = 5f;
    [SerializeField] PlayerAnimCon playerAnimCon;

    public UnityEngine.Events.UnityEvent onButtonClickEat;
    public UnityEngine.Events.UnityEvent onButtonClickEatStop;


    void Awake()
    {
        inputActionsSystem = new SlimeSoulInputSystem(); // Input System�̃A�N�V������������
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
    }

    void OnEnable()
    {
        inputActionsSystem.Enable(); // Input System�̃A�N�V������L����

        // �ړ��A�N�V�����̃R�[���o�b�N��ݒ�
        inputActionsSystem.Player.Move.performed += OnMovePerformed; // �ړ��A�N�V���������s���ꂽ�Ƃ��̏�����ݒ�
        inputActionsSystem.Player.Move.canceled += OnMoveCanceled; // �ړ��A�N�V�������L�����Z�����ꂽ�Ƃ��̏�����ݒ�
        inputActionsSystem.Player.Eat.started += PlayerEat;

    }

    void OnDisable()
    {
        inputActionsSystem.Disable(); // Input System�̃A�N�V�����𖳌���

        // �ړ��A�N�V�����̃R�[���o�b�N������
        inputActionsSystem.Player.Move.performed -= OnMovePerformed; // �ړ��A�N�V���������s���ꂽ�Ƃ��̏���������
        inputActionsSystem.Player.Move.canceled -= OnMoveCanceled; // �ړ��A�N�V�������L�����Z�����ꂽ�Ƃ��̏���������
    }

    void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        if (!inputActionsSystem.Player.Move.enabled) return; // �ړ��A�N�V�����������̏ꍇ�A�������X�L�b�v

        movementInput = ctx.ReadValue<Vector2>(); // ���̓x�N�g�����擾

        playerAnimCon.SetMove(true);
    }

    void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        if (!inputActionsSystem.Player.Move.enabled) return; // �ړ��A�N�V�����������̏ꍇ�A�������X�L�b�v

        movementInput = Vector2.zero; // ���̓x�N�g�����[���Ƀ��Z�b�g

        playerAnimCon.SetMove(false);
    }

    // Move�A�N�V�����̗L��/������ݒ肷�郁�\�b�h
    public void SetMoveActionDisable()
    {
        inputActionsSystem.Player.Move.Disable();
    }

    public void SetMoveActionEnable()
    {
        inputActionsSystem.Player.Move.Enable();
    }

    void FixedUpdate()
    {
        Vector2 movement = movementInput.normalized; // �ړ��x�N�g���𐳋K��

        rb.velocity = movement * speed; // �����G���W�����g�p���ăv���C���[���ړ�������

        // �v���C���[�̌�����ύX
        if (movement != Vector2.zero)
        {
            // �ړ����͂Ɋ�Â��ĉE����������
            if (movement.x > 0)
            {
                // �E������
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                // ��������
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


    private void PlayerEat(InputAction.CallbackContext ctx)
    {
        // UnityEvent���ݒ肳��Ă���΁A��������s
        onButtonClickEat?.Invoke();

        // �����ɔC�ӂ̏�����ǉ�
        Debug.Log("Button Clicked!");

        CancelInvoke("PlayerEatStop");
        Invoke("PlayerEatStop", 1);
    }

    public void PlayerEatStop()
    {
        onButtonClickEatStop?.Invoke();

    }

}
