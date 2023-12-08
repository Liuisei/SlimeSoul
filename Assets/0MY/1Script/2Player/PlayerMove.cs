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
        inputActionsSystem = new SlimeSoulInputSystem(); // Input Systemのアクションを初期化
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    void OnEnable()
    {
        inputActionsSystem.Enable(); // Input Systemのアクションを有効化

        // 移動アクションのコールバックを設定
        inputActionsSystem.Player.Move.performed += OnMovePerformed; // 移動アクションが実行されたときの処理を設定
        inputActionsSystem.Player.Move.canceled += OnMoveCanceled; // 移動アクションがキャンセルされたときの処理を設定
        inputActionsSystem.Player.Eat.started += PlayerEat;

    }

    void OnDisable()
    {
        inputActionsSystem.Disable(); // Input Systemのアクションを無効化

        // 移動アクションのコールバックを解除
        inputActionsSystem.Player.Move.performed -= OnMovePerformed; // 移動アクションが実行されたときの処理を解除
        inputActionsSystem.Player.Move.canceled -= OnMoveCanceled; // 移動アクションがキャンセルされたときの処理を解除
    }

    void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        if (!inputActionsSystem.Player.Move.enabled) return; // 移動アクションが無効の場合、処理をスキップ

        movementInput = ctx.ReadValue<Vector2>(); // 入力ベクトルを取得

        playerAnimCon.SetMove(true);
    }

    void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        if (!inputActionsSystem.Player.Move.enabled) return; // 移動アクションが無効の場合、処理をスキップ

        movementInput = Vector2.zero; // 入力ベクトルをゼロにリセット

        playerAnimCon.SetMove(false);
    }

    // Moveアクションの有効/無効を設定するメソッド
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
        Vector2 movement = movementInput.normalized; // 移動ベクトルを正規化

        rb.velocity = movement * speed; // 物理エンジンを使用してプレイヤーを移動させる

        // プレイヤーの向きを変更
        if (movement != Vector2.zero)
        {
            // 移動入力に基づいて右か左を向く
            if (movement.x > 0)
            {
                // 右を向く
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                // 左を向く
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


    private void PlayerEat(InputAction.CallbackContext ctx)
    {
        // UnityEventが設定されていれば、それを実行
        onButtonClickEat?.Invoke();

        // ここに任意の処理を追加
        Debug.Log("Button Clicked!");

        CancelInvoke("PlayerEatStop");
        Invoke("PlayerEatStop", 1);
    }

    public void PlayerEatStop()
    {
        onButtonClickEatStop?.Invoke();

    }

}
