using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Startup : EditorWindow
{
    static Startup()
    {
      //  EditorApplication.delayCall += ShowWindow;
    }

    private static void ShowWindow()
    {
        // Show the window
        GetWindow(typeof(DeveloperInfoWindow));
    }
}

public class DeveloperInfoWindow : EditorWindow
{
    private Vector2 scrollPosition = Vector2.zero;

    // The developer name
    private string developerName = "DXCODER";

    // The developer email
    private string developerEmail = "Sellmyapp Dxcoder";

    // The developer website URL
    private string SplashScreen = "https://drive.google.com/drive/.....";

    private void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        // Load the logo texture
        Texture2D logoTexture = Resources.Load<Texture2D>("Dxcoder");

        // Show the logo
        if (logoTexture != null)
        {
            Rect logoRect = GUILayoutUtility.GetRect(position.width, 120, GUI.skin.box);
            GUI.DrawTexture(logoRect, logoTexture, ScaleMode.ScaleToFit);
        }

        EditorGUILayout.Space();

        GUILayout.Label("DxCoder Games", EditorStyles.boldLabel);

        EditorGUILayout.Space();
        GUILayout.Label("VERSION 1.0", EditorStyles.boldLabel);
        // Show the developer name
        GUILayout.Label("Developer Name: " + developerName);

        // Show the developer email
       // GUILayout.Label("Developer HomePage: " + developerEmail);
        if (GUILayout.Button("HomePage: " + "https://www.sellmyapp.com/author/dxcoder/", GUILayout.ExpandWidth(false)))
        {
            Application.OpenURL("https://www.sellmyapp.com/author/dxcoder/");
        }
        // Show the developer website URL as a clickable link
        if (GUILayout.Button("Documentation: " + SplashScreen, GUILayout.ExpandWidth(false)))
        {
            Application.OpenURL("https://drive.google.com/drive/folders/1VlbzIAReUd6UyEGqxHTblD3WgI69Ag99?usp=share_link/");
        }
        Texture2D customThumbnail = Resources.Load<Texture2D>("thumbnail1");
        Texture2D thumbnail_1 = Resources.Load<Texture2D>("thumbnail_1");
        Texture2D thumbnail_2 = Resources.Load<Texture2D>("thumbnail_2");
        Texture2D thumbnail_3 = Resources.Load<Texture2D>("thumbnail_3");
        Texture2D thumbnail_4 = Resources.Load<Texture2D>("thumbnail_4");
        Texture2D thumbnail_5 = Resources.Load<Texture2D>("thumbnail_5");
        Texture2D thumbnail_6 = Resources.Load<Texture2D>("thumbnail_6");
        Texture2D thumbnail_7 = Resources.Load<Texture2D>("thumbnail_7");
        Texture2D thumbnail_8 = Resources.Load<Texture2D>("thumbnail_8");

        Texture2D thumbnail_9 = Resources.Load<Texture2D>("thumbnail_9");
        Texture2D thumbnail_10 = Resources.Load<Texture2D>("thumbnail_10");

        Texture2D thumbnail_11 = Resources.Load<Texture2D>("thumbnail_11");
        Texture2D thumbnail_12 = Resources.Load<Texture2D>("thumbnail_12");
        Texture2D Banner = Resources.Load<Texture2D>("Banner");
        GUIContent customButtonContent = new GUIContent("", customThumbnail);

        GUILayout.Space(20);
      
        //------------------------------------------------------------------------------------------------------------------More Games---------------------------------
        GUILayout.Label("More Games", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button(thumbnail_1, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/stamp-it-trending-hypercasual-game/");
        }

        if (GUILayout.Button(thumbnail_2, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/fall-guy-hypercasual/");
        }


        if (GUILayout.Button(thumbnail_3, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/shaolin-soccer-puzzle-game/");
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(thumbnail_4, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/longboard-crasher/");
        }

       
        if (GUILayout.Button(thumbnail_5, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/city-heroes-super-casual-game/");
        }

        if (GUILayout.Button(thumbnail_6, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/monster-trap-halloween-special/");
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();


        if (GUILayout.Button(thumbnail_7, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/glass-bridge-challenge-trending-game/");
        }

        if (GUILayout.Button(thumbnail_8, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/candy-unblock-hypercasual-game/");
        }

   

        if (GUILayout.Button(thumbnail_9, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/mission-possible-action/");
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(thumbnail_10, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/deadflip-challenge-premium-game/");
        }


        if (GUILayout.Button(thumbnail_11, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/flip-lines-hypercasual-puzzle/");
        }

        if (GUILayout.Button(thumbnail_12, GUILayout.Width(200)))
        {
            Application.OpenURL("https://www.sellmyapp.com/downloads/hammer-crush-hyper-casual-game/");
        }

        GUILayout.EndHorizontal();
       
        EditorGUILayout.EndScrollView();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(Banner, GUILayout.Width(600)))
        {
            Application.OpenURL("https://www.youtube.com/channel/UCo-8PFU5x0KThGNEHffsLLw");
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("A9241504", EditorStyles.boldLabel);

    }



}
