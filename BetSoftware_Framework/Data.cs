//  Data.cs
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
//  it under| the terms of the GNU General Public License as published by
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
/// Data.
/// </summary>
namespace BetSoftware_Framework
{
    // Directives
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Data class holds shared variables
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// The name space.
        /// </summary>
        private static string nameSpace = MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[0];

        /// <summary>
        /// The game.
        /// </summary>
        private static string game = /*string.Empty*/ "Roulette";

        /// <summary>
        /// Text for step one.
        /// </summary>
        private static string stepOne = "1) Click desired module(s) in tabs";

        /// <summary>
        /// Text for step two.
        /// </summary>
        private static string stepTwo = "2) Click 'Launch' button to start";

        /// <summary>
        /// Text for step three.
        /// </summary>
        private static string stepThree = "Thank you. Check for our updates frequently!";

        /// <summary>
        /// Text for step three (subscribers).
        /// </summary>
        private static string stepThreeSubscriber = "{1}, enjoy subscribers' auto-update!";

        /// <summary>
        /// The member.
        /// </summary>
        private static string member = string.Empty;

        /// <summary>
        /// Shared form icon.
        /// </summary>
        private static Icon icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("betsoftware.ico"));

        /// <summary>
        /// Xml file path.
        /// </summary>
        private static string xmlFile = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "BetSoftware_Framework.xml";

        /// <summary>
        /// Gets the name space.
        /// </summary>
        /// <value>The name space.</value>
        public static string NameSpace
        {
            get
            {
                return nameSpace;
            }
        }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>The game.</value>
        public static string Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
            }
        }

        /// <summary>
        /// Gets step one text.
        /// </summary>
        /// <value>The step one.</value>
        public static string StepOne
        {
            get
            {
                return stepOne;
            }
        }

        /// <summary>
        /// Gets step two text.
        /// </summary>
        /// <value>The step two.</value>
        public static string StepTwo
        {
            get
            {
                return stepTwo;
            }
        }

        /// <summary>
        /// Gets step three text.
        /// </summary>
        /// <value>The step three.</value>
        public static string StepThree
        {
            get
            {
                return stepThree;
            }
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public static Icon Icon
        {
            get
            {
                return icon;
            }
        }

        /// <summary>
        /// Gets the xml file.
        /// </summary>
        /// <value>The xml file.</value>
        public static string XmlFile
        {
            get
            {
                return xmlFile;
            }
        }
    }
}