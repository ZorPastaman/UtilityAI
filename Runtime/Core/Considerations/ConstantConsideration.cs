// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.UtilityAI.Core.Considerations
{
	/// <summary>
	/// <para>
	/// <see cref="Consideration"/> using formula y = x.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Returned utility of type <see cref="float"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class ConstantConsideration : Consideration, ISetupable<float>
	{
		private float m_utility;

		void ISetupable<float>.Setup(float utility)
		{
			m_utility = utility;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public override float ComputeUtility()
		{
			return m_utility;
		}
	}
}
