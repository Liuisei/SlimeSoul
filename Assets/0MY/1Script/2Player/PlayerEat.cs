using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
    [SerializeField] PlayerType playerType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<StoneHP>(out _))
        {
            Debug.Log("StoneEat00000000000000000000");
            Destroy(collision.gameObject,1f);
            playerType.UpdateType(1);
        }
    }
}
