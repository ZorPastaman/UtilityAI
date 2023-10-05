// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	/// <summary>
	/// <see cref="CoroutineUtilityAITicker"/> that uses <see cref="WaitForSeconds"/>.
	/// </summary>
	/// <seealso cref="WaitForNullUtilityAITicker"/>
	/// <seealso cref="WaitForFixedUpdateUtilityAITicker"/>
	[AddComponentMenu("Utility AI/Tickers/Wait For Seconds Utility AI Agent Ticker")]
	public sealed class WaitForSecondsUtilityAITicker : CoroutineUtilityAITicker
	{
		/// <summary>
		/// Tick period.
		/// </summary>
		[SerializeField] private float m_Seconds;

		/// <summary>
		/// Tick period.
		/// </summary>
		public float seconds
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Seconds;
			set
			{
				if (m_Seconds == value)
				{
					return;
				}

				m_Seconds = value;
				UpdateInstruction();
			}
		}

		protected override YieldInstruction instruction => new WaitForSeconds(m_Seconds);
	}
}
