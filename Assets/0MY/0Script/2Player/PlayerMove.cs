using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ���L�[�܂���WASD�L�[����̓��͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ړ��x�N�g�����v�Z
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // �Ίp���ړ���h�����߂Ɉړ��x�N�g���𐳋K��
        movement.Normalize();

        // �����G���W�����g�p���ăv���C���[���ړ�������
        rb.velocity = movement * speed;
    }
}
