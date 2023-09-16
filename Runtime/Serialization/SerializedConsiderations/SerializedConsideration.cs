// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	public abstract class SerializedConsideration<TConsideration> : SerializedConsideration_Base where TConsideration : Consideration, INotSetupable, new()
	{
		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration>();
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg>, new()
	{
		[SerializeField] private TArg m_Arg;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg>(m_Arg);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1>(m_Arg0, m_Arg1);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2>(m_Arg0, m_Arg1, m_Arg2);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;
		[SerializeField] private TArg3 m_Arg3;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3>(m_Arg0, m_Arg1, m_Arg2, m_Arg3);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;
		[SerializeField] private TArg3 m_Arg3;
		[SerializeField] private TArg4 m_Arg4;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;
		[SerializeField] private TArg3 m_Arg3;
		[SerializeField] private TArg4 m_Arg4;
		[SerializeField] private TArg5 m_Arg5;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;
		[SerializeField] private TArg3 m_Arg3;
		[SerializeField] private TArg4 m_Arg4;
		[SerializeField] private TArg5 m_Arg5;
		[SerializeField] private TArg6 m_Arg6;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5, m_Arg6);
		}
	}

	public abstract class SerializedConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : SerializedConsideration_Base
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		[SerializeField] private TArg0 m_Arg0;
		[SerializeField] private TArg1 m_Arg1;
		[SerializeField] private TArg2 m_Arg2;
		[SerializeField] private TArg3 m_Arg3;
		[SerializeField] private TArg4 m_Arg4;
		[SerializeField] private TArg5 m_Arg5;
		[SerializeField] private TArg6 m_Arg6;
		[SerializeField] private TArg7 m_Arg7;

		public sealed override Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public sealed override void AddConsideration(BrainBuilder builder)
		{
			builder.AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5, m_Arg6, m_Arg7);
		}
	}
}
