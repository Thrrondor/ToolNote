using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosExample : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private MeshFilter m_meshFilter;
    [SerializeField]
    private Vector3 m_CuveSize;

    public float m_FOV = 60f;
    public float m_MinRange = 1f;
    public float m_Maxrange = 100f;
    public float m_Aspect = 0.75f;

    //private void OnDrawGizmos()
    private void OnDrawGizmosSelected()
    {
        Color gizmosColor = Color.white;
        gizmosColor.r = Random.value;
        gizmosColor.b = Random.value;
        gizmosColor.g = Random.value;

        gizmosColor.a = 0.15f;

        Gizmos.color = gizmosColor;

        Gizmos.DrawCube(transform.position, m_CuveSize);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position + Vector3.right * 5f, m_CuveSize); // tp romplece vector.right. par  transforme.taget.right

        if(m_Target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, m_Target.position);
        }

        if(m_meshFilter != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawMesh(m_meshFilter.sharedMesh, transform.position + Vector3.left * 5f, Quaternion.identity);
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + Vector3.forward *5f, 2f);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up*1000f);

        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawFrustum(Vector3.zero, m_FOV, m_Maxrange, m_MinRange, m_Aspect);

        Gizmos.DrawCube(Vector3.back * 5f, m_CuveSize);
    }

}
