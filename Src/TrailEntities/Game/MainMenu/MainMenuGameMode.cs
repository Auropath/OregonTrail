﻿using System;
using System.Text;
using TrailEntities.Mode;
using TrailEntities.Simulation;

namespace TrailEntities.Game.MainMenu
{
    /// <summary>
    ///     Allows the user to completely configure the simulation before they start off on the trail path. It will offer up
    ///     ability to choose names, professions, buy initial items, and starting month. The final thing it offers is ability
    ///     to change any of these values before actually starting the game as a final confirmation.
    /// </summary>
    public sealed class MainMenuGameMode : ModeProduct
    {
        /// <summary>
        ///     Asked for the first party member.
        /// </summary>
        public const string LEADER_QUESTION = "What is the first name of the wagon leader?";

        /// <summary>
        ///     Asked for every other party member name we want to collect.
        /// </summary>
        public const string MEMBERS_QUESTION = "What are the first names of the \nthree other members in your party?";

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:TrailEntities.ModeProduct.MainMenuGameMode" /> class.
        /// </summary>
        public MainMenuGameMode() : base(false)
        {
            // Basic information to start a new simulation.
            MainMenuInfo = new MainMenuInfo();

            var headerText = new StringBuilder();
            headerText.Append($"{Environment.NewLine}The Oregon Trail{Environment.NewLine}{Environment.NewLine}");
            headerText.Append("You may:");
            MenuHeader = headerText.ToString();

            AddCommand(TravelTheTrail, MainMenuCommands.TravelTheTrail, "Travel the trail");
            AddCommand(LearnAboutTrail, MainMenuCommands.LearnAboutTheTrail, "Learn about the trail");
            AddCommand(SeeTopTen, MainMenuCommands.SeeTheOregonTopTen, "See the Oregon Top Ten");
            AddCommand(ChooseManagementOptions, MainMenuCommands.ChooseManagementOptions, "Choose Management Options");
            AddCommand(CloseSimulation, MainMenuCommands.CloseSimulation, "End");
        }

        /// <summary>
        ///     Defines the current game gameMode the inheriting class is going to take responsibility for when attached to the
        ///     simulation.
        /// </summary>
        public override GameMode ModeType
        {
            get { return GameMode.MainMenu; }
        }

        /// <summary>
        ///     Default values for new game.
        /// </summary>
        private MainMenuInfo MainMenuInfo { get; }

        /// <summary>
        ///     Does exactly what it says on the tin, closes the simulation and releases all memory.
        /// </summary>
        private static void CloseSimulation()
        {
            GameSimulationApp.Instance.Destroy();
        }

        /// <summary>
        ///     Glorified options menu, used to clear top ten, tombstone messages, and saved games.
        /// </summary>
        private static void ChooseManagementOptions()
        {
            GameSimulationApp.Instance.AttachMode(GameMode.Options);
        }

        /// <summary>
        ///     High score list, defaults to hard-coded values if no custom ones present.
        /// </summary>
        private void SeeTopTen()
        {
            AddState(typeof(CurrentTopTenState));
        }

        /// <summary>
        ///     Instruction manual that explains how the game works and what is expected of the player.
        /// </summary>
        private void LearnAboutTrail()
        {
            AddState(typeof(InstructionsState));
        }

        /// <summary>
        ///     Start with choosing profession in the new game gameMode, the others are chained together after this one.
        /// </summary>
        private void TravelTheTrail()
        {
            AddState(typeof(SelectProfessionState));
        }
    }
}