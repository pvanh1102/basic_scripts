using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnconditional : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mybody;
    // Start is called before the first frame update
    void Start()
    {
        mybody.AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
        
    }
}
