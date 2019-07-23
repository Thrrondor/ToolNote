using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float m_MouveSpeed;

    [SerializeField]
    private string m_AttackType;


    [SerializeField]
    [Tooltip("this is my health!")]
    private float m_Health;

    public List<int> m_Values;

    private string m_TestString;
}
