// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;

namespace Zor.UtilityAI.Core
{
	/// <summary>
	/// <see cref="Brain"/> settings.
	/// </summary>
	[Serializable]
	public struct BrainSettings
	{
		/// <summary>
		/// Utility difference between a new <see cref="Action"/> and current one
		/// required by <see cref="Brain"/> to switch to it.
		/// </summary>
		public float minimalUtilityDifference;
	}
}
