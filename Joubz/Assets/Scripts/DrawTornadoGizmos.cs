using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTornadoGizmos : MonoBehaviour
{
    public BoxCollider col;

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(col.size.x, col.size.y, col.size.z));
    }
}
