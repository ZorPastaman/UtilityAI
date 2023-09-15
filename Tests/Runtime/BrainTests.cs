// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using NUnit.Framework;
using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.Core.Considerations;

namespace Zor.UtilityAI.Tests
{
	public static class BrainTests
	{
		[Test]
		public static void BuildTest()
		{
			var colorValue = new BlackboardPropertyName("ColorValue");
			var value = new BlackboardPropertyName("Value");
			var blackboard = new Blackboard();

			var builder = new BrainBuilder();
			builder.AddAction<SetColorAction, Color, BlackboardPropertyName>(Color.green, colorValue);
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(1f, 0f, 0f, value);
			builder.AddAction<SetColorAction, Color, BlackboardPropertyName>(Color.red, colorValue);
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(-1f, 0f, 1f, value);
			Brain brain = builder.Build(blackboard);
			brain.Initialize();

			blackboard.SetStructValue(value, 1f);
			brain.Tick();
			Assert.IsTrue(blackboard.TryGetStructValue(colorValue, out Color color));
			Assert.AreEqual(color, Color.green);

			blackboard.SetStructValue(value, 0f);
			brain.Tick();
			Assert.IsTrue(blackboard.TryGetStructValue(colorValue, out color));
			Assert.AreEqual(color, Color.red);

			brain.Dispose();
		}
	}
}
