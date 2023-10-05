// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	/// <summary>
	/// <see cref="UtilityAITicker"/> that calls a tick every Update.
	/// </summary>
	/// <seealso cref="LateUpdateUtilityAITicker"/>
	/// <seealso cref="FixedUpdateUtilityAITicker"/>
	[AddComponentMenu("Utility AI/Tickers/Update Utility AI Agent Ticker")]
	public sealed class UpdateUtilityAITicker : UtilityAITicker
	{
		private void Update()
		{
			Tick();
		}
	}
}
