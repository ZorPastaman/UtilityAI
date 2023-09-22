// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	internal interface IActionBuilder
	{
		[NotNull]
		Type actionType { get; }

		[NotNull]
		Action Build();
	}
}
