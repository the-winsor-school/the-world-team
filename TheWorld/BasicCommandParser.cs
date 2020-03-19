﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TheWorld
{
    // this allows me to use the static methods defined in TextFormatter without typing "TextFormatter." every time.
	using static TheWorld.TextFormatter;

    public partial class MainClass
    {

		/// <summary>
		/// The command words.
		/// These are all the words that the game will accept as commands.
		/// You will need to add more words to make the game more interesting!
		/// </summary>
		private static List<string> CommandWords = new List<string>()
		{
			"go", "look", "help", "quit", "examine", "fight"
		};

        /// <summary>
        /// TODO:  Easy Achievement
        /// Improve the readability of other code by completing this method.
        ///
        /// This should return True if and only if the CommandWords list contains
        /// the give cmdWord.
        ///
        /// Implement this method in appropriate places such as the ParseCommand method.
        /// 
        /// </summary>
        /// <param name="cmdWord"></param>
        /// <returns></returns>
		private static bool IsValidCommandWord(string cmdWord) => throw new NotImplementedException();

		/// <summary>
		/// Parses the command and do any required actions.
		/// </summary>
		/// <param name="command">Command as typed by the user.</param>
		private static void ParseCommand(string command)
		{
            // Break apart the command into individual words:
            // This is why command words and unique names for objects cannot contain spaces.
			string[] parts = command.Split(' ');
            // The first word is the command.
			string cmdWord = parts[0];


			if (!CommandWords.Contains(cmdWord))
			{
				PrintLineWarning("I don't understand...(type \"help\" to see a list of commands I know.)");
				return;
			}

			if (cmdWord.Equals("look"))
			{
				ProcessLookCommand(parts);
			}
			else if (cmdWord.Equals("go"))
			{
				ProcessGoCommand(parts);
			}
			else if (cmdWord.Equals("fight"))
			{
				ProcessFightCommand(parts);
			}
            else if (cmdWord.Equals("help"))
            {
                // TODO:  Implement this to show a new player how to use commands!
            }
		}

        private static void ProcessHelpCommand(string[] parts)
        {
            if(parts.Length == 1)
            {
                // TODO:  Easy Achievement (1):
                // the whole command is just "help".  Print a generic help message that
                // tells the player what valid command words are and how to formulate them
                //
                // TODO:  Easy Achievement (2):
                // Print a helpful example that shows the Player an example command that
                // will work in the current Area.  (e.g. "look [something]" where that
                // something is a valid thing to look at in the CurrentArea.
            }
            if(parts.Length == 2)
            {
                // TODO: Moderate Achievement (3):
                // In this case, the user is looking for help with a specific command, so
                // you should verify that the second word in the string is a valid command word
                // then for each possible valid command word, print a useful help message that
                // explains what the command does and an example of how to use it.
                // If the second word is not a valid command, make sure your message is clearly
                // an Error message (Use the PrintWarning() method to make it obvious).
            }
        }

		/// <summary>
		/// Enter Combat mode.
		/// </summary>
		/// <param name="parts">Command as typed by the user split into individual words.</param>
		private static void ProcessFightCommand(string[] parts)
		{
			Creature creature;
			try
			{
				creature = CurrentArea.GetCreature(parts[1]);
			}
			catch (WorldException e)
			{
				if (CurrentArea.HasItem(parts[1]))
					PrintLineWarning("You can't fight with that...");
				else
					PrintLineDanger(e.Message);
				return;
			}

			// This method is part of the MainClass but is defined in a different file.
			// Check out the Combat.cs file.
			CombatResult result = DoCombat(ref creature);

			switch (result)
			{
				case CombatResult.Win:
					PrintLinePositive("You win!");
					Player.Stats.Exp += creature.Stats.Exp;
					CurrentArea.RemoveCreature(parts[1]);
					break;
				case CombatResult.Lose:
					PrintLineDanger("You lose!");
					break;
				default: break;
			}
		}

		/// <summary>
		/// What happens when the user types "look" as the command word.
		/// </summary>
		/// <param name="parts">Command Parts.</param>
		private static void ProcessLookCommand(string[] parts)
		{
			// If you just type "look" then LookAround()
			if (parts.Length == 1)
				Console.WriteLine(CurrentArea.LookAround());
			else
			{
				// try to find the thing that the user is looking at.
				try
				{
					// if it is there, print the appropriate description.
					Console.WriteLine(CurrentArea.LookAt(parts[1]));
				}
				catch (WorldException e)
				{
					// otherwise, print an appropriate error message.
					PrintLineDanger(e.Message);
				}
			}
		}

		/// <summary>
		/// Processes the go command.
		/// </summary>
		/// <param name="parts">Parts.</param>
		private static void ProcessGoCommand(string[] parts)
		{
			// If the user has not indicated where to go...
			if (parts.Length == 1)
				PrintLineWarning("Go where?");
			else
			{
				// try to find the neigbor the user has indicated.
				try
				{
					// move to that area if the command is understood.
					CurrentArea = CurrentArea.GetNeighbor(parts[1]);
				}
				catch (WorldException e)
				{
					// if GetNeighbor throws and exception, print the explanation.
					PrintLineDanger(e.Message);
				}
			}
		}
	}
}