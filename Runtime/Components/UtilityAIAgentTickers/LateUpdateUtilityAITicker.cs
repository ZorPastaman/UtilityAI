// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	/// <summary>
	/// <see cref="UtilityAITicker"/> that calls a tick every Late update.
	/// </summary>
	/// <seealso cref="UpdateUtilityAITicker"/>
	/// <seealso cref="FixedUpdateUtilityAITicker"/>
	[AddComponentMenu("Utility AI/Tickers/Late Update Utility AI Agent Ticker")]
	public sealed class LateUpdateUtilityAITicker : UtilityAITicker
	{
		private void LateUpdate()
		{
			Tick();
		}
	}
}
