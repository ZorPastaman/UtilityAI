﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	[AddComponentMenu("Utility AI/Tickers/Wait For Fixed Update Utility AI Agent Ticker")]
	public sealed class WaitForFixedUpdateUtilityAITicker : CoroutineUtilityAITicker
	{
		protected override YieldInstruction instruction => new WaitForFixedUpdate();
	}
}
