using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumeAttribute : PropertyAttribute
{
    public string[] m_Items;

    public EnumeAttribute(System.Type i_Enumtype)
    {
        m_Items = System.Enum.GetNames(i_Enumtype);
    }
}
