using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HyparPickElement
{
	/// <summary>
	/// Override metadata for PossibleElementOverrideRemoval
	/// </summary>
	public partial class PossibleElementOverrideRemoval : IOverride
	{
        public static string Name = "Possible Element Removal";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.PossibleElement]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}