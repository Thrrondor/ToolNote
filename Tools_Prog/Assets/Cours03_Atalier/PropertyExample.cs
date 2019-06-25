using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider))]
public class PropertyExample : MonoBehaviour
{
    private enum State
    {
        Idle,
        Attack,
        Defend
    }

    [SerializeField]
    private string m_State;

    [Header("header Example")]
    public float m_HeaderExample;

    [SerializeField]
    [HideInInspector]
    private float m_SerializeFloat;

    [Multiline(5)]
    public string m_MultilineString;

    [Space(15f)]
    [Range(0, 100)]
    [Tooltip("This is a ok tooltip!")]
    public int m_RangeInt;

    [Clear]
    [VariableName("Bart Variable")]
    public string m_TestVariable;

    [Enume(typeof(State))]
    public string m_TestEnum;

    private void OnGUI()
    {
        GUI.Label(new Rect(0f, 0f, 100f, 50f), "This Is IN ExecuteInEditMode" );
    }
}
