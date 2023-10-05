// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Debugging;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	/// <summary>
	/// Base class for a <see cref="UtilityAIAgent"/> ticker.
	/// </summary>
	public abstract class UtilityAITicker : MonoBehaviour
	{
		[SerializeField, Tooltip("Ticked utility AI agent.")]
		private UtilityAIAgent m_UtilityAIAgent;

		/// <summary>
		/// Ticked <see cref="UtilityAIAgent"/>.
		/// </summary>
		[NotNull]
		public UtilityAIAgent utilityAIAgent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_UtilityAIAgent;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_UtilityAIAgent = value;
		}

		/// <summary>
		/// Ticks <see cref="UtilityAITicker"/>.
		/// </summary>
		protected void Tick()
		{
			m_UtilityAIAgent.Tick();
		}

		protected virtual void OnEnable()
		{
			if (m_UtilityAIAgent == null)
			{
				UtilityAIDebug.LogWarning(this, $"[BehaviorTreeAgentTicker] Null behavior tree agent at {gameObject.name}");
				enabled = false;
			}
		}

		protected virtual void OnValidate()
		{
		}
	}
}
