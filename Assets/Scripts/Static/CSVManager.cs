using System.IO;
using UnityEngine;

public static class CSVManager
{
    private static string reportFolderName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ";";
    private static string[] reportHeaders = new string[37]
    {
        "Subject ID",
        "Game Version",
        "Stage",
        "Score Lost in Stage",
        "Score",
        "HeadRotation",
        "Tutorial Time",
        "Time Stamp",
        " ",
        " ",
        "Button Presses",
        "Actions Executed",
        "Sucessfull Hits",
        "Hits Taken",
        "Precision Score",
        "Spam Index",
        "Centered Amount",
        " ",
        "Astronauts Spawned",
        "Astronauts Destroyed",
        "Astronauts Struck",
        "Astronauts Sucessrate",
        " ",
        "Aliens Spawned",
        "Aliens Destroyed",
        "Aliens Struck",
        "Alien Sucessrate",
        " ",
        "Lasers Spawned",
        "Lasers Destroyed",
        "Lasers Struck",
        "Laser Sucessrate",
        " ",
        "Asteroids Spawned",
        "Asteroids Destroyed",
        "Asteroids Struck",
        "Asteroid Sucessrate",
    };

    #region Interactions
    public static void AppendToReport(string[] strings) // Append adds lines to an existing string
    {
        VerifyDirectory(); // create if it doesnt exist
        VerifyFile(); // create if it doesnt exis
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }

            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport() // Gets called if file doesnt exist and then creates the file
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = ""; // create an empty string
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "") // If final string is not empty
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            } // Add Headers to File

            //finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    #endregion

    #region Operations
    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    #endregion

    #region Queries
    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportFolderName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    #endregion
}
