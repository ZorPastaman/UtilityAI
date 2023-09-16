// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using UnityEngine;
using Zor.UtilityAI.Builder;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	public abstract class SerializedConsideration_Base : ScriptableObject
	{
		public abstract Type considerationType { get; }

		public abstract void AddConsideration(BrainBuilder builder);
	}
}
