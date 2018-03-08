using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

[System.Serializable]

public class csParticleEditor : EditorWindow {

    private float Scale = 1;

    public GameObject Effect;
    public Color ShurikenSystemColor = Color.white;

    static csParticleEditor myWindow;

    static bool InitialButtonsPageOn; 
    static bool EffectChangePageOn; 
    static bool LegacyPageOn;
    static bool ShurikenPageOn;
    static bool LegacyShurikenPageOn;

	[MenuItem("Particle Effect Editor/Particle Effect Editor")]

	public static void Init()
	{
        myWindow = EditorWindow.GetWindowWithRect<csParticleEditor>(new Rect(100, 100, 300, 220)); //set Editor Position and Size
		myWindow.title = "Particle Effect Editor"; //set Editor name

        //initially, Display Legacy, Shuriken, Legacy&Shuriken Effect Change Section
        //so InitialButtonPageOn set true.
        InitialButtonsPageOn = true; 
        //Other Page Hide.
        EffectChangePageOn = false;
        LegacyPageOn = false;
        ShurikenPageOn = false;
        LegacyShurikenPageOn = false;
	}

	void OnGUI()
	{
        if (InitialButtonsPageOn)
        {
            //Display Legacy Section Button
            if (GUILayout.Button("Legacy Particle Effect Edit",  GUILayout.Height(70)))
            {
                InitialButtonsPageOn = false; //Hide Legacy, Shuriken, Legacy&Shuriken Effect Change Section

                //Display Legacy Effect Section.
                EffectChangePageOn = true; 
                LegacyPageOn = true; 
            }

            //Display Shuriken Section Button
            if (GUILayout.Button("Shuriken System Effect Edit",  GUILayout.Height(70)))
            {
                InitialButtonsPageOn = false; //Hide Legacy, Shuriken, Legacy&Shuriken Effect Change Section

                //Display Shuriken Effect Effect Section.
                EffectChangePageOn = true;
                ShurikenPageOn = true; 
            }

            //Display Legacy & Shuriken Section Button
            if (GUILayout.Button("Legacy & Shuriken Effect Edit",  GUILayout.Height(70)))
            {
                InitialButtonsPageOn = false; //Hide Legacy, Shuriken, Legacy&Shuriken Effect Change Section

                //Display Legacy Effect Section.
                EffectChangePageOn = true;
                LegacyShurikenPageOn = true;
            }
        }

        if (EffectChangePageOn == true)
        {
            if (LegacyPageOn)
            {
                GUILayout.Box("Legacy Effect Section", GUILayout.Width(295)); //Set Title Name
                EditorGUILayout.Space();

                Effect = (GameObject)EditorGUILayout.ObjectField("Legacy Effect", Effect, typeof(GameObject), true);  //For Change Object What you Want, Make ObjectField.
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                Scale = float.Parse(EditorGUILayout.TextField("Scale Change Value", Scale.ToString())); // Make Scale Change TextFild
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                if (GUILayout.Button("Scale Apply", GUILayout.Height(70))) // Make Scale Apply Button
                {
                    if (Effect.GetComponent<csParticleChanger>() != null) //Check Object has csParticleChanger Component
                        Effect.GetComponent<csParticleChanger>().LegacyEffectScaleChange(Scale); //if Object has csParticleChagner, Just Change Value
                    else
                    {
                        Effect.AddComponent<csParticleChanger>();//if Object hasn't csParticle Chagner, After Put in csParticleChanger, Change Value
                        Effect.GetComponent<csParticleChanger>().LegacyEffectScaleChange(Scale);
                    }
                    DestroyImmediate(Effect.GetComponent<csParticleChanger>()); //After all work done, Destroy csParticleChanger
                }
            }

            else if (ShurikenPageOn)
            {
                GUILayout.Box("Shuriken Effect Section", GUILayout.Width(295)); //Set Title Name
                EditorGUILayout.Space();

                Effect = (GameObject)EditorGUILayout.ObjectField("Shuriken Effect", Effect, typeof(GameObject), true); //For Change Object What you Want, Make ObjectField.
                EditorGUILayout.Space();

                ShurikenSystemColor = EditorGUILayout.ColorField("Shuriken Effect Color", ShurikenSystemColor); //For Change Effect's Color, Make ColorFiled 
                EditorGUILayout.Space();

                if (GUILayout.Button("Color Apply", GUILayout.Height(35))) //Make Color Apply Button
                {
                    if (Effect.GetComponent<csParticleChanger>() != null) //Check Object has csParticleChanger Component
                    {
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleColorChange(ShurikenSystemColor); //if Object has csParticleChagner, Just Change Color
                        Effect.GetComponent<csParticleChanger>().ObjectScaleChagne(Scale);
                    }
                    else
                    {
                        Effect.AddComponent<csParticleChanger>();//if Object hasn't csParticle Chagner, After Put in csParticleChanger, Change Color
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleColorChange(ShurikenSystemColor);
                    }
                    DestroyImmediate(Effect.GetComponent<csParticleChanger>()); //After all work done, Destroy csParticleChanger
                }
                EditorGUILayout.Space();

                Scale = float.Parse(EditorGUILayout.TextField("Scale Change Value", Scale.ToString()));  // Make Scale Change TextFild
                EditorGUILayout.Space();

                if (GUILayout.Button("Scale Apply", GUILayout.Height(35))) // Make Scale Apply Button
                {
                    if (Effect.GetComponent<csParticleChanger>() != null) //Check Object has csParticleChanger Component
                    {
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleScaleChange(Scale); // if Object has csParticleChagner, Just Change Value
                        Effect.GetComponent<csParticleChanger>().ObjectScaleChagne(Scale);
                    }
                    else
                    {
                        Effect.AddComponent<csParticleChanger>();//if Object hasn't csParticle Chagner, After Put in csParticleChanger, Change Value
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleScaleChange(Scale);
                    }
                    DestroyImmediate(Effect.GetComponent<csParticleChanger>()); //After all work done, Destroy csParticleChanger
                }
            }

            else if (LegacyShurikenPageOn)
            {
                GUILayout.Box("Legacy&Shuriken Effect Section", GUILayout.Width(295));// Set Title Name
                EditorGUILayout.Space();

                Effect = (GameObject)EditorGUILayout.ObjectField("Legacy&Shuriken Effect", Effect, typeof(GameObject), true); //For Change Object What you Want, Make ObjectField.
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                Scale = float.Parse(EditorGUILayout.TextField("Scale Change Value", Scale.ToString())); // Make Scale Change TextFild
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                if (GUILayout.Button("Scale Apply", GUILayout.Height(70))) // Make Scale Apply Button
                {
                    if (Effect.GetComponent<csParticleChanger>() != null)//Check Object has csParticleChanger Component
                    {
                        Effect.GetComponent<csParticleChanger>().LegacyEffectScaleChange(Scale); // if Object has csParticleChagner, Just Change Value
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleScaleChange(Scale);
                        Effect.GetComponent<csParticleChanger>().ObjectScaleChagne(Scale);
                    }
                    else
                    {
                        Effect.AddComponent<csParticleChanger>(); //if Object hasn't csParticle Chagner, After Put in csParticleChanger, Change Value
                        Effect.GetComponent<csParticleChanger>().LegacyEffectScaleChange(Scale);
                        Effect.GetComponent<csParticleChanger>().ShurikenParticleScaleChange(Scale);

                    }
                    DestroyImmediate(Effect.GetComponent<csParticleChanger>()); //After all work done, Destroy csParticleChanger
                }
            }
            if (GUILayout.Button("Back", GUILayout.Height(20),GUILayout.Width(40))) //Make Back Button
            {
                InitialButtonsPageOn = true;
                EffectChangePageOn = false;
                LegacyPageOn = false;
                ShurikenPageOn = false;
                LegacyShurikenPageOn = false;
            }
        }
	}
}
#endif