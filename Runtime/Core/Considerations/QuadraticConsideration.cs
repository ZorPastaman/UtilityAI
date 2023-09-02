// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class QuadraticConsideration : Consideration, IEquatable<QuadraticConsideration>
	{
		private readonly float m_slope;
		private readonly float m_exponent;
		private readonly float m_verticalShift;
		private readonly float m_horizontalShift;
		private readonly BlackboardPropertyName m_valuePropertyName;

		public QuadraticConsideration(float slope, float exponent, float verticalShift, float horizontalShift,
			BlackboardPropertyName valuePropertyName)
		{
			m_slope = slope;
			m_exponent = exponent;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = valuePropertyName;
		}

		public float slope
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_slope;
		}

		public float exponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_exponent;
		}

		public float verticalShift
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_verticalShift;
		}

		public float horizontalShift
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_horizontalShift;
		}

		public BlackboardPropertyName valuePropertyName
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valuePropertyName;
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value)
				? m_slope * Mathf.Pow(value - m_verticalShift, m_exponent) + m_horizontalShift
				: 0f;
		}

		[Pure]
		public bool Equals(QuadraticConsideration other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return m_slope.Equals(other.m_slope) && m_exponent.Equals(other.m_exponent) &&
				m_verticalShift.Equals(other.m_verticalShift) && m_horizontalShift.Equals(other.m_horizontalShift) &&
				m_valuePropertyName.Equals(other.m_valuePropertyName);
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is QuadraticConsideration other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			return HashCode.Combine(m_slope, m_exponent, m_verticalShift, m_horizontalShift, m_valuePropertyName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(QuadraticConsideration left, QuadraticConsideration right)
		{
			return Equals(left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(QuadraticConsideration left, QuadraticConsideration right)
		{
			return !Equals(left, right);
		}
	}
}
