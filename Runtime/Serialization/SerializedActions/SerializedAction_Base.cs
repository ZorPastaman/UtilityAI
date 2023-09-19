// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Builder;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	public abstract class SerializedAction_Base : ScriptableObject
	{
		[NotNull]
		public abstract Type actionType { get; }

		public abstract void AddAction(BrainBuilder builder);
	}
}
