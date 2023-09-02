// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class ConstantConsideration : Consideration, IEquatable<ConstantConsideration>
	{
		private readonly float m_utility;

		public ConstantConsideration(float utility)
		{
			m_utility = utility;
		}

		public float utility
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_utility;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public override float ComputeUtility()
		{
			return m_utility;
		}

		[Pure]
		public bool Equals(ConstantConsideration other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return m_utility.Equals(other.m_utility);
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is ConstantConsideration other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			return m_utility.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(ConstantConsideration left, ConstantConsideration right)
		{
			return Equals(left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(ConstantConsideration left, ConstantConsideration right)
		{
			return !Equals(left, right);
		}
	}
}
