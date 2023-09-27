// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	public abstract class Action
	{
		private Blackboard m_blackboard;

		public string name { get; set; }

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
			Profiler.BeginSample(GetType().FullName);

			OnInitialize();

			Profiler.EndSample();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Begin()
		{
			Profiler.BeginSample("Action.Begin");
			Profiler.BeginSample(GetType().FullName);

			OnBegin();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Tick()
		{
			Profiler.BeginSample("Action.Tick");
			Profiler.BeginSample(GetType().FullName);

			OnTick();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void End()
		{
			Profiler.BeginSample("Action.End");
			Profiler.BeginSample(GetType().FullName);

			OnEnd();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Dispose()
		{
			Profiler.BeginSample(GetType().FullName);

			OnDispose();

			Profiler.EndSample();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SetBlackboard([NotNull] Blackboard blackboardToSet)
		{
			m_blackboard = blackboardToSet;
		}

		[NotNull]
		public static TAction Create<TAction>() where TAction : Action, INotSetupable, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg>([CanBeNull] TArg arg) where TAction : Action, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1)
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}
	}
}
