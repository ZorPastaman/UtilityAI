// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	[AddComponentMenu("Utility AI/Tickers/Late Update Utility AI Agent Ticker")]
	public sealed class LateUpdateUtilityAITicker : UtilityAITicker
	{
		private void LateUpdate()
		{
			Tick();
		}
	}
}
