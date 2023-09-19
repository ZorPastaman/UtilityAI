// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Considerations;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedConsiderations
{
	[NameOverride("Slope", 0), NameOverride("Exponent", 1), NameOverride("Vertical Shift", 2),
	NameOverride("Horizontal Shift", 3), NameOverride("Value Property Name", 4)]
	public sealed class SerializedQuadraticConsideration : SerializedConsideration<QuadraticConsideration, float, float, float, float, string>
	{
	}
}
