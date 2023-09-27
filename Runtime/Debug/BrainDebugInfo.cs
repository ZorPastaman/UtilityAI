// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections.Generic;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Debugging
{
	public sealed class BrainDebugInfo
	{
		public readonly List<ActionInfo> actionInfos = new();
		public BrainSettings brainSettings;

		public sealed class ActionInfo
		{
			public string name = string.Empty;
			public readonly List<ConsiderationInfo> considerationInfos = new();
			public float utility;
			public bool isActive;
		}

		public sealed class ConsiderationInfo
		{
			public string name = string.Empty;
			public float utility;
		}
	}
}
