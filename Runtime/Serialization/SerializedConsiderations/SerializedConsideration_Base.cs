// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using UnityEngine;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	/// <summary>
	/// Base class for a serialized <see cref="Consideration"/>.
	/// </summary>
	public abstract class SerializedConsideration_Base : ScriptableObject
	{
		/// <summary>
		/// Type of a serialized <see cref="Consideration"/>.
		/// </summary>
		public abstract Type considerationType { get; }

		/// <summary>
		/// Adds a <see cref="Consideration"/> to the <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">Brain builder target.</param>
		public abstract void AddConsideration(BrainBuilder builder);
	}
}
