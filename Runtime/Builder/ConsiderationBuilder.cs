// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	internal sealed class ConsiderationBuilder<TConsideration> : IConsiderationBuilder
		where TConsideration : Consideration, INotSetupable, new()
	{
		public Consideration Build()
		{
			return Consideration.Create<TConsideration>();
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg>, new()
	{
		private readonly TArg m_arg;

		public ConsiderationBuilder(TArg arg)
		{
			m_arg = arg;
		}

		[CanBeNull]
		public TArg arg
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg>(m_arg);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1>(m_arg0, m_arg1);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2>(m_arg0, m_arg1, m_arg2);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3>(m_arg0, m_arg1, m_arg2, m_arg3);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(m_arg0, m_arg1, m_arg2,
				m_arg3, m_arg4);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_arg0, m_arg1,
				m_arg2, m_arg3, m_arg4, m_arg5);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;
		private readonly TArg6 m_arg6;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		[CanBeNull]
		public TArg6 arg6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg6;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_arg0, m_arg1,
				m_arg2, m_arg3, m_arg4, m_arg5, m_arg6);
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;
		private readonly TArg6 m_arg6;
		private readonly TArg7 m_arg7;

		public ConsiderationBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;
			m_arg7 = arg7;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		[CanBeNull]
		public TArg6 arg6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg6;
		}

		[CanBeNull]
		public TArg7 arg7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg7;
		}

		public Consideration Build()
		{
			return Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_arg0, m_arg1,
				m_arg2, m_arg3, m_arg4, m_arg5, m_arg6, m_arg7);
		}
	}
}
