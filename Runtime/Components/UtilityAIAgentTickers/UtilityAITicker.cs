// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	public abstract class UtilityAITicker : MonoBehaviour
	{
		[SerializeField, Tooltip("Ticked utility AI agent.")]
		private UtilityAIAgent m_UtilityAIAgent;

		protected void Tick()
		{
			m_UtilityAIAgent.Tick();
		}
	}
}
