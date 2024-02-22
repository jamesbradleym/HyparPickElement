using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HyparPickElement
{
	/// <summary>
	/// Override metadata for PickElementOverrideRemoval
	/// </summary>
	public partial class PickElementOverrideRemoval : IOverride
	{
        public static string Name = "Pick Element Removal";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.PickableElement]";
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