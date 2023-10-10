// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Builder;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	/// <summary>
	/// Base class for a serialized <see cref="Action"/>.
	/// </summary>
	public abstract class SerializedAction_Base : ScriptableObject
	{
		/// <summary>
		/// Type of a serialized <see cref="Action"/>.
		/// </summary>
		[NotNull]
		public abstract Type actionType { get; }

		/// <summary>
		/// Adds an <see cref="Action"/> to the <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">Brain builder target.</param>
		public abstract void AddAction(BrainBuilder builder);
	}
}
