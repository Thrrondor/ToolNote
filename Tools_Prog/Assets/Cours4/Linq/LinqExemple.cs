using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExemple : MonoBehaviour
{
    public List<GameObject> m_Objects;

    private void OnGUI()
    {
        Rect rect = new Rect(10f, 10f, 100f, 20f);

        if(GUI.Button(rect, "Get Nearest"))
        {
            GameObject narestObject = GetNearestObject();
            Debug.Log(narestObject.name);

            GameObject nearestObjectLinqObject = m_Objects
            .OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position))
            .FirstOrDefault();

            Debug.Log("linq nearestP: " + nearestObjectLinqObject.name);
        }

        rect.y += 30f;

        if(GUI.Button(rect, "Get furthest"))
        {
            // method 1
            GameObject furthestobj1 = m_Objects
            .OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position))
            .LastOrDefault();

            // methode 2
            GameObject furthestobj2 = m_Objects
            .OrderByDescending(obj => Vector3.Distance(transform.position, obj.transform.position))
            .FirstOrDefault();

            Debug.Log(furthestobj1.name);
        }

        rect.y += 30f;

        if(GUI.Button(rect, "Get 2 nearest"))
        {
            GameObject[] nearest2 = m_Objects
            .OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position))
            .Take(2)
            .ToArray();
            for(int i = 0; i < nearest2.Length; i++)
            {
                Debug.Log(nearest2[i].name);            
            }
        }

        rect.y += 30f;

        if(GUI.Button(rect, "skip 2"))
        {
            List<GameObject> skip2 = m_Objects
            .OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position))
            .Skip(1)
            .ToList();

            for(int i = 0; i < skip2.Count; i++)
            {
                Debug.Log(skip2[i].name);
            }
        }

        rect.y += 30f;

        if(GUI.Button(rect , "ehrtr"))
        {
            GameObject[] objects = m_Objects
            .Where(obj => Vector3.Distance(transform.position, obj.transform.position) < 2f)
            .ToArray();

            for(int i = 0; i < objects.Length; i++)
            {
                Debug.Log(objects[i].name);
            }
        }

        rect.y += 30f;

        if(GUI.Button(rect, "Any"))
        {
            bool any = m_Objects
                .Any(obj => obj.name == "Cube2");
            Debug.Log(any);
        }  

        rect.y += 30f;

        if(GUI.Button(rect, "Distanct"))
        {
            List<int> ints = new List<int>() {1, 1, 1, 2, 2, 3, 3, 4, 4, 4, 4};
            ints = ints
            .Distinct()
            .ToList();

            for(int i = 0; i < ints.Count; i++)
            {
                Debug.Log(ints[i]);
            }
        }

    }

    private GameObject GetNearestObject()
    {
        float smallestDistance = Mathf.Infinity;
        GameObject narestObject = null;

        for(int i = 0; i < m_Objects.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, m_Objects[i].transform.position);
            if(distance < smallestDistance)
            {
                smallestDistance = distance;
                narestObject = m_Objects[i];
            }
        }

        

        return narestObject;
    }
}
