// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections.Generic;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Debugging
{
	/// <summary>
	/// <see cref="Brain"/> debug info. It's usually used to show a state of a <see cref="Brain"/> in ui.
	/// </summary>
	/// <seealso cref="Brain.FillDebugInfo"/>
	public sealed class BrainDebugInfo
	{
		/// <summary>
		/// <see cref="Action"/> infos.
		/// </summary>
		public readonly List<ActionInfo> actionInfos = new();
		/// <summary>
		/// Brain settings.
		/// </summary>
		public BrainSettings brainSettings;

		/// <summary>
		/// <see cref="Action"/> info.
		/// </summary>
		public sealed class ActionInfo
		{
			/// <summary>
			/// <see cref="Action"/> name.
			/// </summary>
			public string name = string.Empty;
			/// <summary>
			/// <see cref="Consideration"/> infos.
			/// </summary>
			public readonly List<ConsiderationInfo> considerationInfos = new();
			/// <summary>
			/// <see cref="Action"/> utility.
			/// </summary>
			public float utility;
			/// <summary>
			/// Is this <see cref="Action"/> currently active in the <see cref="Brain"/>.
			/// </summary>
			public bool isActive;
		}

		/// <summary>
		/// <see cref="Consideration"/> info.
		/// </summary>
		public sealed class ConsiderationInfo
		{
			/// <summary>
			/// <see cref="Consideration"/> name.
			/// </summary>
			public string name = string.Empty;
			/// <summary>
			/// <see cref="Consideration"/> utility.
			/// </summary>
			public float utility;
		}
	}
}
