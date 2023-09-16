// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class AbsoluteConsideration : Consideration,
		ISetupable<float, float, float, BlackboardPropertyName>,
		ISetupable<float, float, float, string>
	{
		private float m_slope;
		private float m_verticalShift;
		private float m_horizontalShift;
		private BlackboardPropertyName m_valuePropertyName;

		void ISetupable<float, float, float, BlackboardPropertyName>.Setup(float slope, float verticalShift,
			float horizontalShift, BlackboardPropertyName valuePropertyName)
		{
			m_slope = slope;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = valuePropertyName;
		}

		void ISetupable<float, float, float, string>.Setup(float slope, float verticalShift,
			float horizontalShift, string valuePropertyName)
		{
			m_slope = slope;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = new BlackboardPropertyName(valuePropertyName);
		}

		public float slope
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_slope;
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
				? m_slope * Mathf.Abs(value - m_verticalShift) + m_horizontalShift
				: 0f;
		}
	}
}
