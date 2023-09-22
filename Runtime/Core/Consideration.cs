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

		[NotNull]
		public static TConsideration Create<TConsideration>() where TConsideration : Consideration, INotSetupable, new()
		{
			return new TConsideration();
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg>([CanBeNull] TArg arg) where TConsideration : Consideration, ISetupable<TArg>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1>([CanBeNull] TArg0 arg0,[CanBeNull]  TArg1 arg1)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			return consideration;
		}
	}
}
