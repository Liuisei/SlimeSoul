using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    SlimeSoulInputSystem inputActions;
    Rigidbody2D rb;
    Vector2 movementInput;
    [SerializeField] private float speed = 5f;

    void Awake()
    {
        inputActions = new SlimeSoulInputSystem(); // Input System�̃A�N�V������������
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
    }

    void OnEnable()
    {
        inputActions.Enable(); // Input System�̃A�N�V������L����

        // �ړ��A�N�V�����̃R�[���o�b�N��ݒ�
        inputActions.Player.Move.performed += OnMovePerformed; // �ړ��A�N�V���������s���ꂽ�Ƃ��̏�����ݒ�
        inputActions.Player.Move.canceled += OnMoveCanceled; // �ړ��A�N�V�������L�����Z�����ꂽ�Ƃ��̏�����ݒ�
    }

    void OnDisable()
    {
        inputActions.Disable(); // Input System�̃A�N�V�����𖳌���

        // �ړ��A�N�V�����̃R�[���o�b�N������
        inputActions.Player.Move.performed -= OnMovePerformed; // �ړ��A�N�V���������s���ꂽ�Ƃ��̏���������
        inputActions.Player.Move.canceled -= OnMoveCanceled; // �ړ��A�N�V�������L�����Z�����ꂽ�Ƃ��̏���������
    }

    void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>(); // ���̓x�N�g�����擾
    }

    void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        movementInput = Vector2.zero; // ���̓x�N�g�����[���Ƀ��Z�b�g
    }

    void FixedUpdate()
    {
        Vector2 movement = movementInput.normalized; // �ړ��x�N�g���𐳋K��

        rb.velocity = movement * speed; // �����G���W�����g�p���ăv���C���[���ړ�������
    }
}
