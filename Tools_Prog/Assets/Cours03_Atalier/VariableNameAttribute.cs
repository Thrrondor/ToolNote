using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableNameAttribute : PropertyAttribute
{
    public string m_VarName;

    public VariableNameAttribute(string i_VarName)
    {
        m_VarName = i_VarName;
    }
}
