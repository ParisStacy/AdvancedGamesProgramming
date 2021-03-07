using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using SimpleJSON;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class Week5 : MonoBehaviour
{
    /*
     * Write a CSV parser - that takes in a CSV file of players and returns a list of those players as class objects.
     * To help you out, I've defined the player class below.  An example save file is in the folder "CSV Examples".
     *
     * NOTES:
     *     - the first row of the file has the column headings: don't include those!
     *     - location is tricky - because the location has a comma in it!!
     */

    private class Player
    {
        public enum Class : byte
        {
            Undefined = 0,
            Monk,
            Wizard,
            Druid,
            Thief,
            Sorcerer
        }
        
        public Class classType;
        public string name;
        public uint maxHealth;
        public int[] stats;
        public bool alive;
        public Vector2 location;
    }

    private List<Player> CSVParser(TextAsset toParse)
    {
        var toReturn = new List<Player>();

        string[] lines = toParse.text.Split('\n');

        for (int i=1; i < lines.Length; i++) {
            toReturn.Add(CSVPlayerToPlayerClass(lines[i]));
        }

        return toReturn;
    }

    private Player CSVPlayerToPlayerClass(string line) {

        Player _player = new Player();

        string[] elements = line.Split(',');

        //Name
        _player.name = elements[0];

        //Class
        switch (elements[1]) {
            case "Monk":
                _player.classType = Player.Class.Monk;
                break;
            case "Wizard":
                _player.classType = Player.Class.Wizard;
                break;
            case "Druid":
                _player.classType = Player.Class.Druid;
                break;
            case "Thief":
                _player.classType = Player.Class.Thief;
                break;
            case "Sorcerer":
                _player.classType = Player.Class.Sorcerer;
                break;
            case "0":
                _player.classType = Player.Class.Undefined;
                break;
        }

        //Health
        _player.maxHealth = uint.Parse(elements[2]);

        //Stats

        int[] stats = new int[5];
        stats[0] = int.Parse(elements[3]);
        stats[1] = int.Parse(elements[4]);
        stats[2] = int.Parse(elements[5]);
        stats[3] = int.Parse(elements[6]);
        stats[4] = int.Parse(elements[7]);
        _player.stats = stats;

        //Alive
        _player.alive = bool.Parse(elements[8]);

        //Location
        _player.location.x = float.Parse(elements[9]);
        _player.location.y = float.Parse(elements[10]);

        return _player;
    }


    /*
     * Provided is a high score list as a JSON file.  Create the functions that will find the highest scoring name, and
     * the number of people with a score above a score.
     *
     * I've included a library "SimpleJSON", which parses JSON into a dictionary of strings to strings or dictionaries
     * of strings.
     *
     * JSON.Parse(someJSONString)["someKey"] will return either a string value, or a Dictionary of strings to
     * JSON objects.
     */

    public int NumberAboveScore(TextAsset jsonFile, int score)
    {
        var toReturn = 0;
     
        return toReturn;
    }

    public string GetHighScoreName(TextAsset jsonFile)
    {
        return "";
    }
    
    // =========================== DON'T EDIT BELOW THIS LINE =========================== //

    public TextMeshProUGUI csvTest, networkTest;
    public TextAsset csvExample, jsonExample;
    private Coroutine checkingScores;
    
    private void Update()
    {
        csvTest.text = "CSV Parser\n<align=left>\n";

        var parsedPlayers1 = CSVParser(csvExample);

        if (parsedPlayers1.Count == 0)
        {
            csvTest.text += "Need to return some players.";
        }
        else
        {
            csvTest.text += Success(parsedPlayers1.Any(p => p.name == "Jeff") &&
                                    parsedPlayers1.Any(p => p.name == "Stonks")
                            ) + " read in player names correctly.\n";
            csvTest.text +=
                Success(parsedPlayers1.First(p => p.name == "Jeff").alive &&
                        !parsedPlayers1.First(p => p.name == "Stonks").alive) + " Correctly read 'alive'.\n";
            csvTest.text +=
                Success(parsedPlayers1.First(p => p.name == "Stonks").classType == Player.Class.Wizard &&
                        parsedPlayers1.First(p => p.name == "Twergle").classType == Player.Class.Thief) +
                " Correctly read player class.\n";
            csvTest.text +=
                Success(parsedPlayers1.First(p => p.name == "Fortune").location == new Vector2(12.322f, 42f)) +
                " Correctly read in location.\n";
            csvTest.text += Success(parsedPlayers1.First(p => p.name == "Jeff").maxHealth == 23) +
                            " Correctly read in max health.\n";
            csvTest.text +=
                Success(parsedPlayers1.First(p => p.name == "Fortune").location == new Vector2(12.322f, 42f)) +
                " Correctly read in location.\n";
        }
        
        networkTest.text = "JSON Data\n<align=left>\n";
        networkTest.text += Success(NumberAboveScore(jsonExample, 10) == 6) + " number above score worked correctly.\n";
        networkTest.text += Success(GetHighScoreName(jsonExample) == "GUW") + " get high score name worked correctly.\n";
    }
    
    private string Success(bool test)
    {
        return test ? "<color=\"green\">PASS</color>" : "<color=\"red\">FAIL</color>";
    }
}