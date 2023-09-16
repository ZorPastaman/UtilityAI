// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class CurveConsideration : Consideration,
		ISetupable<AnimationCurve, BlackboardPropertyName>,
		ISetupable<AnimationCurve, string>
	{
		private AnimationCurve m_curve;
		private BlackboardPropertyName m_valuePropertyName;

		void ISetupable<AnimationCurve, BlackboardPropertyName>.Setup(AnimationCurve curve, BlackboardPropertyName valuePropertyName)
		{
			m_curve = curve;
			m_valuePropertyName = valuePropertyName;
		}

		void ISetupable<AnimationCurve, string>.Setup(AnimationCurve curve, string valuePropertyName)
		{
			m_curve = curve;
			m_valuePropertyName = new BlackboardPropertyName(valuePropertyName);
		}

		[NotNull]
		public AnimationCurve curve
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_curve;
		}

		public BlackboardPropertyName valuePropertyName
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valuePropertyName;
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value) ? m_curve.Evaluate(value) : 0f;
		}
	}
}
