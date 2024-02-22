using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HyparPickElement
{
	/// <summary>
	/// Override metadata for PickElementOverrideAddition
	/// </summary>
	public partial class PickElementOverrideAddition : IOverride
	{
        public static string Name = "Pick Element Addition";
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