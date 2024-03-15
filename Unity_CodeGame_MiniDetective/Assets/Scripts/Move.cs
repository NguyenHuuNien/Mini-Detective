using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private LayerMask _layerMask;
    // Start is called before the first frame update
    void Start()
    {
        _layerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,transform.position+Vector3.down*1,Color.cyan);
    }

    private bool checkGround()
    {
        var hit = Physics2D.Raycast(transform.position,Vector2.down,1f,_layerMask);
        return hit.collider != null;
    }
}
