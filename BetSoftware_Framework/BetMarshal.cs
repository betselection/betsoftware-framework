//  BetMarshal.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Bet marshal.
/// </summary>
namespace BetSoftware_Framework
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    /// <summary>
    /// Bet marshal class.
    /// </summary>
    public class BetMarshal
    {
        /// <summary>
        /// History list.
        /// </summary>
        private List<string> history = new List<string>();

        /// <summary>
        /// Modules dictionary.
        /// </summary>
        private Dictionary<string, List<object>> modules = new Dictionary<string, List<object>>();

        /// <summary>
        /// Bets dictionary.
        /// </summary>
        private Dictionary<string, decimal> bets = new Dictionary<string, decimal>();

        /// <summary>
        /// Previous bets dictionary.
        /// </summary>
        private Dictionary<string, decimal> prevBets = new Dictionary<string, decimal>();

        /// <summary>
        /// The messages dictionary for inter-module communication.
        /// </summary>
        private Dictionary<string, object> messages = new Dictionary<string, object>();

        /// <summary>
        /// Default paths.
        /// </summary>
        private Dictionary<string, string> paths = new Dictionary<string, string>();

        /// <summary>
        /// Set initial balance amount.
        /// </summary>
        private decimal balance = 0M;

        /// <summary>
        /// Set base unit.
        /// </summary>
        private decimal baseUnit = 1M;

        /// <summary>
        /// Last input value.
        /// </summary>
        private string last;

        /// <summary>
        /// Current bet.
        /// </summary>
        private string bet = string.Empty;

        /// <summary>
        /// Previous bet.
        /// </summary>
        private string prevBet = string.Empty;

        /// <summary>
        /// Indicates if the previous bet is won.
        /// </summary>
        private bool won;

        /// <summary>
        /// Set the icon.
        /// </summary>
        private Icon icon = Data.Icon;

        /// <summary>
        /// The active game.
        /// </summary>
        private string game = Data.Game;

        /// <summary>
        /// Initializes a new instance of the <see cref="BetSoftware_Framework.BetMarshal"/> class.
        /// </summary>
        public BetMarshal()
        {
            /* Prepare modules dictionary */

            // Loop notification
            this.modules.Add("Loop", new List<object>());

            // Utilities
            this.modules.Add("Utilities", new List<object>());

            // Bet selection
            this.modules.Add("Input", new List<object>());

            // Bet selection
            this.modules.Add("BetSelection", new List<object>());

            // Money management
            this.modules.Add("MoneyManagement", new List<object>());

            // Display
            this.modules.Add("Display", new List<object>());

            // Output
            this.modules.Add("Output", new List<object>());

            /* Prepare paths dictionary */

            // Framework
            this.paths.Add("framework", AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Gets or sets the last.
        /// </summary>
        /// <value>The last.</value>
        public string Last
        {
            get
            {
                return this.last;
            }

            set
            {
                this.last = value;
            }
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Icon Icon
        {
            get
            {
                return this.icon;
            }
        }

        /// <summary>
        /// Gets or sets the bet.
        /// </summary>
        /// <value>The bet.</value>
        public string Bet
        {
            get
            {
                return this.bet;
            }

            set
            {
                this.bet = value;
            }
        }

        /// <summary>
        /// Gets the paths.
        /// </summary>
        /// <value>The paths.</value>
        public Dictionary<string, string> Paths
        {
            get
            {
                return paths;
            }
        }

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <value>The game.</value>
        public string Game
        {
            get
            {
                return game;
            }
        }

        /// <summary>
        /// Adds module to dictionary.
        /// </summary>
        /// <param name="moduleType">Module type.</param>
        /// <param name="module">Module object.</param>
        public void AddModule(string moduleType, object module)
        {
            // Add passed module
            this.modules[moduleType].Add(module);
        }

        /// <summary>
        /// Adds the bet.
        /// </summary>
        /// <param name="bet">Bet string.</param>
        public void AddBet(string bet)
        {
            /* Validate */

            // Check there's something to work with
            if (bet.Length < 3 || !bet.Contains("@"))
            {
                // Exit
                return;
            }

            /* Process */

            // Split bet parts
            string[] betP = bet.Split('@');

            // Old value
            decimal oldVal;

            // Add current bet to dictionary
            if (this.bets.TryGetValue(betP[1], out oldVal))
            {
                // Add sum
                this.bets[betP[1]] = oldVal + decimal.Parse(betP[0]);
            }
            else
            {
                // Add value
                this.bets.Add(betP[1], decimal.Parse(betP[0]));
            }

            /* Update bet line */

            // Intermediate list for bets
            List<string> betL = new List<string>();

            // Build it
            foreach (KeyValuePair<string, decimal> kvp in this.bets)
            {
                // Add to list
                betL.Add(kvp.Value.ToString() + "@" + kvp.Key);
            }

            // Join and set as bet line
            this.Bet = string.Join("|", betL.ToArray());
        }

        /// <summary>
        /// Processes the incoming input.
        /// </summary>
        /// <param name="input">Input string.</param>
        public void Input(string input)
        {
            // Set last
            this.last = input;

            /* Bet Selection */

            foreach (object module in this.modules["BetSelection"])
            {
                // Notify module
                module.GetType().GetMethod("Input").Invoke(module, null);
            }

            /* Money Management */

            foreach (object module in this.modules["MoneyManagement"])
            {
                // Notify module
                module.GetType().GetMethod("Input").Invoke(module, null);
            }

            // TODO Update balance

            /* Display */

            foreach (object module in this.modules["Display"])
            {
                // Notify module
                module.GetType().GetMethod("Input").Invoke(module, null);
            }

            /* Output */

            foreach (object module in this.modules["Output"])
            {
                // Notify module
                module.GetType().GetMethod("Input").Invoke(module, null);
            }

            // Populate previous bet
            this.prevBet = this.bet;

            // Populate previous bets dictionary
            this.prevBets = this.bets;

            // Clear bet string
            this.bet = string.Empty;

            // Clear bets dictionary
            this.bets.Clear();

            /* Loop (notify) */
        }
    }
}