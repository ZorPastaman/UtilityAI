// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	public abstract class Consideration
	{
		private Blackboard m_blackboard;

		[NotNull]
		protected Blackboard blackboard
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_blackboard;
		}

		public abstract float ComputeUtility();

		protected virtual void OnInitialize() {}
		protected virtual void OnDispose() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize()
		{
			OnInitialize();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Dispose()
		{
			OnDispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SetBlackboard([NotNull] Blackboard blackboardToSet)
		{
			m_blackboard = blackboardToSet;
		}
	}
}
