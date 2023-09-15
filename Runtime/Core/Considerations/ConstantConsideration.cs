// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class ConstantConsideration : Consideration, ISetupable<float>
	{
		private float m_utility;

		void ISetupable<float>.Setup(float utility)
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
	}
}
