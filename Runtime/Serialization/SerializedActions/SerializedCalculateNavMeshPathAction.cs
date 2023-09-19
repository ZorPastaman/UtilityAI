// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	[NameOverride("Source Property Name", 0), NameOverride("Target Property Name", 1),
	NameOverride("Filter Property Name", 2), NameOverride("Path Property Name", 3)]
	public sealed class SerializedCalculateNavMeshPathAction : SerializedAction<CalculateNavMeshPathAction, string, string, string, string>
	{
	}
}
