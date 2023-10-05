// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.Components.UtilityAIAgentTickers
{
	/// <summary>
	/// <see cref="CoroutineUtilityAITicker"/> that uses <see langword="null"/>.
	/// </summary>
	/// <seealso cref="WaitForSecondsUtilityAITicker"/>
	/// <seealso cref="WaitForFixedUpdateUtilityAITicker"/>
	[AddComponentMenu("Utility AI/Tickers/Wait For Null Utility AI Agent Ticker")]
	public sealed class WaitForNullUtilityAITicker : CoroutineUtilityAITicker
	{
		protected override YieldInstruction instruction => null;
	}
}
