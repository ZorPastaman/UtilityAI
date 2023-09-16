// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Builder;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	public abstract class SerializedAction_Base : ScriptableObject
	{
		[SerializeField] private int[] m_ConsiderationIndices;

		[NotNull]
		public int[] considerationIndices
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_ConsiderationIndices;
		}

		[NotNull]
		public abstract Type actionType { get; }

		public abstract void AddAction(BrainBuilder builder);
	}
}
