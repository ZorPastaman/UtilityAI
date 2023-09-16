// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAiAgentTickers
{
	[AddComponentMenu("Utility AI/Tickers/Update Utility AI Agent Ticker")]
	public sealed class UpdateUtilityAiTicker : UtilityAiTicker
	{
		private void Update()
		{
			Tick();
		}
	}
}
