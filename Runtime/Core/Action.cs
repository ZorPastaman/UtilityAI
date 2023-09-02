// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	public abstract class Action
	{
		private Blackboard m_blackboard;

		[NotNull]
		protected Blackboard blackboard
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_blackboard;
		}

		protected virtual void OnInitialize() {}
		protected virtual void OnBegin() {}
		protected virtual void OnTick() {}
		protected virtual void OnEnd() {}
		protected virtual void OnDispose() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize()
		{
			OnInitialize();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Begin()
		{
			OnBegin();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Tick()
		{
			OnTick();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void End()
		{
			OnEnd();
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
