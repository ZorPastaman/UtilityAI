// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	[NameOverride("Agent Property Name", 0), NameOverride("Corners Property Name", 1)]
	public sealed class SerializedNavMeshAgentPatrolAction : SerializedAction<NavMeshAgentPatrolAction, string, string>
	{
	}
}
