using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUIExample : MonoBehaviour
{
    private const float LINE_PIXELS = 20f;

    public Vector2 m_ScrollBarSize;
    public Rect m_ScrollView = new Rect(0f, 0f, 150f, 350f);

    [SerializeField]
    private Texture m_Texture;
    [Range(0f, 1f)]
    public float m_GroupX;
    [Range(0f, 1f)]
    public float m_GroupY;

    public Rect m_WindowRect1 = new Rect(20f, 20f, 120f, 50f);
    public Rect m_WindowRect2 = new Rect(100f, 100f, 120f, 50f);
    public Rect m_ScrollNavigation = new Rect(0f, 0f, 300f, 1000f);

    private bool m_MyToggle;
    private string m_MyText;
    private string m_MyPassWaordText = "";
    private float m_MySlider;
    private int m_SelectionInt;
    private int m_Toolbar;

    private Vector2 m_ScrollPos;

    private enum page
    {
        cheat = 0,
        stats = 1,
//        GUI =
    }

    private page m_CurrentPage = page.cheat;

   // private int m_CurrentPage = 0;

    private string[] m_SelectionText = new string[]
    {
        "Selection 1",
        "Banane",
        "Flambeau",
        "pikachu"
    };

    private void ShowCheats()
    {
        switch(m_CurrentPage)
        {
            case page.cheat:
            ShowCheats();
            break;
            case page.stats:
          //  showstats();
            break;
            
        }

    // int test = 1;
    // page testpage = (page)test;
    //     if(buttonleftispressed)
    //     {
    //         m_CurrentPage
    //     }

        
    }


    private void OnGUI()
    {
        m_Toolbar = GUI.Toolbar(new Rect(500f, 100f, 00f, 30f), m_Toolbar, m_SelectionText);

        m_ScrollPos = GUI.BeginScrollView(m_ScrollView, m_ScrollPos, m_ScrollNavigation);

        Rect rect = new Rect(0f, 0f, 100f, 20f);


        GUI.Label(rect, "This is SPARTA!");
        rect.y += LINE_PIXELS;
        GUI.Label(rect, "HA OU, HA OU, HA OU");
        rect.y += LINE_PIXELS;
        if(GUI.Button(rect, "SPARTA"))
        {
            Debug.Log("OCH ESTI! STOPPPP!!!!");
            Vector3 randomPos = transform.position;
            randomPos.x += Random.Range(-5f, 5f);
            transform.position = randomPos;
            m_MyText = "";
            GUI.FocusControl("MyText");
        }

        rect.y += LINE_PIXELS;

        if(GUI.RepeatButton(rect, "x_X"))
        {
            Debug.Log("LAHCE LE BOUTTON x_X");
        }

        rect.y += LINE_PIXELS;

        m_MyToggle = GUI.Toggle(rect, m_MyToggle, "KILL");

        rect.y += LINE_PIXELS;
        
        GUI.SetNextControlName("MyText");
        m_MyText = GUI.TextField(rect, m_MyText); // pour écrire du texte

        rect.y += LINE_PIXELS;

        m_MyPassWaordText = GUI.PasswordField(rect, m_MyPassWaordText,'*'); // remplace ce que tu écris pas ** dans le texte filed mias le texte rest le meme

        rect.y += LINE_PIXELS;

        float previousValur = m_MySlider;
        m_MySlider = CustomSlider(rect, m_MySlider, -5f, 5f);
        if(previousValur != m_MySlider)
        {
            transform.position = Vector3.right * m_MySlider;
        }

        rect.y += LINE_PIXELS;

        Rect SelectionRect = new Rect(rect);
        SelectionRect.width = 500f;
        SelectionRect.height = 150f;
        m_SelectionInt = GUI.SelectionGrid(SelectionRect, m_SelectionInt, m_SelectionText, 2);

        GUI.EndScrollView();

        rect.y += SelectionRect.height;
        
        GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
        boxStyle.normal.background = (Texture2D)m_Texture;

        GUI.Box(rect, "My box", boxStyle);
        //GUI.Box(rect, m_Texture);

        rect.y += LINE_PIXELS;

        //Rect textureRect = new Rect(rect);
        //textureRect.width = m_Texture.width;
        //textureRect.height = m_Texture.height;

       // GUI.DrawTexture(textureRect, m_Texture);

        Rect groupRect = new Rect(Screen.width * m_GroupX, Screen.height * m_GroupY, Screen.width, 50f); // grosseur de l'écrean
        GUI.BeginGroup(groupRect);
        GUI.Box(new Rect(0f,0f, groupRect.width, groupRect.height), "group");

        string text = "Center Label";
        Vector2 texteSize = GUI.skin.label.CalcSize(new GUIContent(text));

        GUI.Label(new Rect((groupRect.width * 0.5f) - (texteSize.x *0.5f), (groupRect.height * 0.5f) - (texteSize.y * 0.5f), groupRect.width, 20f), "Center Label");
        GUI.EndGroup();

        m_WindowRect1 = GUI.Window(0, m_WindowRect1, ShowWindow1, "first");
        m_WindowRect2 = GUI.Window(1, m_WindowRect2,ShowWindows2, "secound" );
    }

    private float CustomSlider(Rect aRect, float aCurrent, float aMin, float aMax)
    {
        aCurrent = GUI.HorizontalSlider(aRect, aCurrent, aMin, aMax);
        aRect.x += aRect.width;
        GUI.Label(aRect, aCurrent.ToString("f2"));
        return aCurrent;
    }

    private void ShowWindow1(int a_WindowID)
    {
        if(GUI.Button(new Rect(10f, 20f, 100f, 20f), "Put Back"))
        {
            GUI.BringWindowToBack(0);
        }
        if(GUI.Button(new Rect(10f, 40f, 100f, 20f), "Put Front"))
        {
            GUI.BringWindowToFront(0);
        }

        GUI.DragWindow(new Rect(0f, 0f, m_WindowRect1.width, m_WindowRect1.height));
    }

    private void ShowWindows2(int a_WindowID)
    {
        if(GUI.Button(new Rect(10f, 20f, 100f, 20f), "Put Back"))
        {
            GUI.BringWindowToBack(1);
        }
        if(GUI.Button(new Rect(10f, 40f, 100f, 20f), "Put Front"))
        {
            GUI.BringWindowToFront(1);
        }

        GUI.DragWindow(new Rect(0f, 0f, m_WindowRect2.width, m_WindowRect2.height));
    }
}
