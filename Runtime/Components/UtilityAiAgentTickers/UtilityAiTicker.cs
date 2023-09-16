// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAiAgentTickers
{
	public abstract class UtilityAiTicker : MonoBehaviour
	{
		[SerializeField, Tooltip("Ticked utility AI agent.")]
		private UtilityAiAgent m_UtilityAiAgent;

		protected void Tick()
		{
			m_UtilityAiAgent.Tick();
		}
	}
}
