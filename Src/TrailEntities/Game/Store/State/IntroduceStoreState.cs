﻿using System;
using System.Text;
using TrailEntities.Game.MainMenu;
using TrailEntities.Mode;
using TrailEntities.Simulation;

namespace TrailEntities.Game.Store
{
    /// <summary>
    ///     Introduces the player to the concept of a store as being run by a person by the name of Matt.
    /// </summary>
    public sealed class IntroduceStoreState : ModeStateProduct
    {
        /// <summary>
        ///     Determines if the player now knows who Matt is.
        /// </summary>
        private bool _knowsAboutMatt;

        /// <summary>
        ///     Builder for the string we will display to the user.
        /// </summary>
        private StringBuilder _storeHelp;

        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public IntroduceStoreState(ModeProduct gameMode, MainMenuInfo userData) : base(gameMode, userData)
        {
            _storeHelp = new StringBuilder();
            _storeHelp.Append($"{Environment.NewLine}You can buy whatever you need at{Environment.NewLine}");
            _storeHelp.Append($"Matt's General Store.{Environment.NewLine}{Environment.NewLine}");

            _storeHelp.Append(GameSimulationApp.PRESS_ENTER);
        }

        /// <summary>
        ///     Determines if user input is currently allowed to be typed and filled into the input buffer.
        /// </summary>
        /// <remarks>Default is FALSE. Setting to TRUE allows characters and input buffer to be read when submitted.</remarks>
        public override bool AcceptsInput
        {
            get { return false; }
        }

        /// <summary>
        ///     Returns a text only representation of the current game gameMode state. Could be a statement, information, question
        ///     waiting input, etc.
        /// </summary>
        public override string OnRenderState()
        {
            return _storeHelp.ToString();
        }

        /// <summary>
        ///     Fired when the game gameMode current state is not null and input buffer does not match any known command.
        /// </summary>
        /// <param name="input">Contents of the input buffer which didn't match any known command in parent game gameMode.</param>
        public override void OnInputBufferReturned(string input)
        {
            if (_knowsAboutMatt)
                return;

            _knowsAboutMatt = true;
            ParentMode.SetShouldRemoveMode();
            GameSimulationApp.Instance.AttachMode(GameMode.Store);
        }
    }
}