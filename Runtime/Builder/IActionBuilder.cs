// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	/// <summary>
	/// Interface for <see cref="Action"/> builders.
	/// </summary>
	internal interface IActionBuilder
	{
		/// <summary>
		/// Built <see cref="Action"/> type.
		/// </summary>
		[NotNull]
		Type actionType { get; }

		/// <summary>
		/// Builds an <see cref="Action"/>.
		/// </summary>
		/// <returns>Built <see cref="Action"/>.</returns>
		[NotNull]
		Action Build();
	}
}
