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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnInitialize() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnBegin() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnTick() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnEnd() {}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

				[NotNull]
		public static TAction Create<TAction>() where TAction : Action, INotSetupable, new()
		{
			return new TAction();
		}

		[NotNull]
		public static TAction Create<TAction, TArg>(TArg arg) where TAction : Action, ISetupable<TArg>, new()
		{
			var action = new TAction();
			action.Setup(arg);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1>(TArg0 arg0, TArg1 arg1)
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			return action;
		}
	}
}
