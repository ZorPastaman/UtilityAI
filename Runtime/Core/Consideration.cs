﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	public abstract class Consideration
	{
		private Blackboard m_blackboard;

		public string name { get; set; }

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
			Profiler.BeginSample(GetType().FullName);

			OnInitialize();

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
		public static TConsideration Create<TConsideration>() where TConsideration : Consideration, INotSetupable, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg>([CanBeNull] TArg arg) where TConsideration : Consideration, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1>([CanBeNull] TArg0 arg0,[CanBeNull]  TArg1 arg1)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static TConsideration Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7)
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(typeof(TConsideration).FullName);

			var consideration = new TConsideration();
			consideration.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static Consideration Create([NotNull] Type type)
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(type.FullName);

			var consideration = (Consideration)Activator.CreateInstance(type);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}

		[NotNull]
		public static Consideration Create([NotNull] Type type, [NotNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("Consideration.Create");
			Profiler.BeginSample(type.FullName);

			var consideration = (Consideration)Activator.CreateInstance(type);
			SetupableHelper.CreateSetup(consideration, parameters);

			Profiler.EndSample();
			Profiler.EndSample();

			return consideration;
		}
	}
}
