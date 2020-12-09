using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class D : MonoBehaviour
{
    static List<string> m_DebugMessages;
    static GameObject debugText;
    static string lastLog;

    void Start()
    {
        m_DebugMessages = new List<string>();
        debugText = GameObject.Find("DebugText");

        D.Log("Logger is running...");
    }
    public static void Log(string debugMessage)
    {
        //normal Log output
        if (debugMessage.Split('\n').Length > 10)
        {
            debugMessage = "Error - Message to long (over 10 lines)";
        }
        m_DebugMessages.Add(debugMessage);

        string text = "";
        for (int i = m_DebugMessages.Count - 1; i >= 0; i--)
        {
            int numLine = m_DebugMessages[i].Split('\n').Length;
            
            if (text.Split('\n').Length + numLine <= 10)
            {
                text = m_DebugMessages[i] + "\n" + text;
            }
            else
            {
                m_DebugMessages.RemoveAt(i);
            }
        }
        debugText.GetComponent<TMP_Text>().text = text;
    }
    public static void LogNR(string debugMessage)
    {
        //doesn't repeat the same Message again until different message received
        if (!debugMessage.Equals(lastLog))
        {
            D.Log(debugMessage);
            lastLog = debugMessage;
        }
    }
    public static void LogStack(string debugMessage, bool pin)
    {
        //stacks specific Messages if
        //pin = true -> message stays on screen (for all other methods too)

        //todo
    }
}
