// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Collections.Generic;
using NUnit.Framework;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.Core.Considerations;
using Zor.UtilityAI.Debugging;

namespace Zor.UtilityAI.Tests
{
	public static class BrainTests
	{
		[Test]
		public static void UpdateUtilitiesTest()
		{
			var utilities = new KeyValuePair<float, float[]>[]
			{
				new(0f, new[] {0f, 1f, 5f}),
				new(5f, new[] {1f, 1f, 5f}),
				new(10f, new[] {2f, 1f, 5f}),
				new (-10f, new[] {2f, -1f, 5f})
			};

			var builder = new BrainBuilder();

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[2]);

			Brain brain = builder.Build(new BrainSettings());
			brain.Initialize();

			var brainInfo = new BrainDebugInfo();
			brain.FillDebugInfo(brainInfo);

			List<BrainDebugInfo.ActionInfo> actionInfos = brainInfo.actionInfos;

			for (int actionIndex = 0, actionCount = actionInfos.Count; actionIndex < actionCount; ++actionIndex)
			{
				BrainDebugInfo.ActionInfo actionInfo = actionInfos[actionIndex];
				Assert.AreEqual(utilities[actionIndex].Key, actionInfo.utility, 0.001D);

				List<BrainDebugInfo.ConsiderationInfo> considerationInfos = actionInfo.considerationInfos;

				for (int considerationIndex = 0, considerationCount = considerationInfos.Count;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					BrainDebugInfo.ConsiderationInfo considerationInfo = considerationInfos[considerationIndex];
					Assert.AreEqual(utilities[actionIndex].Value[considerationIndex], considerationInfo.utility, 0.001D);
				}
			}

			brain.Dispose();
		}

		[Test]
		public static void UpdateUtilitiesWithTickTest()
		{
			var utilities = new KeyValuePair<float, float[]>[]
			{
				new(0f, new[] {0f, 1f, 5f}),
				new(5f, new[] {1f, 1f, 5f}),
				new(10f, new[] {2f, 1f, 5f}),
				new (-10f, new[] {2f, -1f, 5f})
			};

			var builder = new BrainBuilder();

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[0].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[1].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[2].Value[2]);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[0]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[1]);
			builder.AddConsideration<ConstantConsideration, float>(utilities[3].Value[2]);

			Brain brain = builder.Build(new BrainSettings());
			brain.Initialize();
			brain.Tick();

			var brainInfo = new BrainDebugInfo();
			brain.FillDebugInfo(brainInfo);

			List<BrainDebugInfo.ActionInfo> actionInfos = brainInfo.actionInfos;

			for (int actionIndex = 0, actionCount = actionInfos.Count; actionIndex < actionCount; ++actionIndex)
			{
				BrainDebugInfo.ActionInfo actionInfo = actionInfos[actionIndex];
				Assert.AreEqual(utilities[actionIndex].Key, actionInfo.utility, 0.001D);

				List<BrainDebugInfo.ConsiderationInfo> considerationInfos = actionInfo.considerationInfos;

				for (int considerationIndex = 0, considerationCount = considerationInfos.Count;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					BrainDebugInfo.ConsiderationInfo considerationInfo = considerationInfos[considerationIndex];
					Assert.AreEqual(utilities[actionIndex].Value[considerationIndex], considerationInfo.utility, 0.001D);
				}
			}

			brain.Dispose();
		}

		[Test]
		public static void CurrentActionIndexTest()
		{
			var blackboard = new Blackboard();
			var valuePropertyName = new BlackboardPropertyName("value");

			var builder = new BrainBuilder();

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(1f, 0f, 0f, valuePropertyName);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(-1f, 0f, 1f, valuePropertyName);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(0.7f);

			Brain brain = builder.Build(blackboard, new BrainSettings());
			brain.Initialize();

			brain.Tick();
			var brainInfo = new BrainDebugInfo();
			brain.FillDebugInfo(brainInfo);
			Assert.IsFalse(brainInfo.actionInfos[0].isActive);
			Assert.IsFalse(brainInfo.actionInfos[1].isActive);
			Assert.IsTrue(brainInfo.actionInfos[2].isActive);

			blackboard.SetStructValue(valuePropertyName, 0f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsFalse(brainInfo.actionInfos[0].isActive);
			Assert.IsTrue(brainInfo.actionInfos[1].isActive);
			Assert.IsFalse(brainInfo.actionInfos[2].isActive);

			blackboard.SetStructValue(valuePropertyName, 1f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[0].isActive);
			Assert.IsFalse(brainInfo.actionInfos[1].isActive);
			Assert.IsFalse(brainInfo.actionInfos[2].isActive);

			blackboard.SetStructValue(valuePropertyName, 0.5f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsFalse(brainInfo.actionInfos[0].isActive);
			Assert.IsFalse(brainInfo.actionInfos[1].isActive);
			Assert.IsTrue(brainInfo.actionInfos[2].isActive);

			brain.Dispose();
		}

		[Test]
		public static void ActionEventsTest()
		{
			var blackboard = new Blackboard();
			var valuePropertyName = new BlackboardPropertyName("value");

			var builder = new BrainBuilder();

			bool onInitialize = false;
			bool onBegin = false;
			bool onTick = false;
			bool onEnd = false;
			bool onDispose = false;

			builder.AddAction<TestAction, System.Action, System.Action, System.Action, System.Action, System.Action>(
				() => onInitialize = true, () => onBegin = true, () => onTick = true, () => onEnd = true, () => onDispose = true);
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(1f, 0f, 0f, valuePropertyName);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(0.7f);

			Brain brain = builder.Build(blackboard, new BrainSettings());
			brain.Initialize();
			Assert.IsTrue(onInitialize);
			Assert.IsFalse(onBegin);
			Assert.IsFalse(onTick);
			Assert.IsFalse(onEnd);
			Assert.IsFalse(onDispose);
			onInitialize = false;
			brain.Dispose();
			onDispose = false;

			blackboard.SetStructValue(valuePropertyName, 1f);
			brain = builder.Build(blackboard, new BrainSettings());
			brain.Initialize();
			Assert.IsTrue(onInitialize);
			Assert.IsTrue(onBegin);
			Assert.IsFalse(onTick);
			Assert.IsFalse(onEnd);
			Assert.IsFalse(onDispose);
			onInitialize = false;
			onBegin = false;

			brain.Tick();
			Assert.IsFalse(onInitialize);
			Assert.IsFalse(onBegin);
			Assert.IsTrue(onTick);
			Assert.IsFalse(onEnd);
			Assert.IsFalse(onDispose);
			onTick = false;

			blackboard.SetStructValue(valuePropertyName, 0f);
			brain.Tick();
			Assert.IsFalse(onInitialize);
			Assert.IsFalse(onBegin);
			Assert.IsFalse(onTick);
			Assert.IsTrue(onEnd);
			Assert.IsFalse(onDispose);
			onEnd = false;

			blackboard.SetStructValue(valuePropertyName, 1f);
			brain.Tick();
			Assert.IsFalse(onInitialize);
			Assert.IsTrue(onBegin);
			Assert.IsTrue(onTick);
			Assert.IsFalse(onEnd);
			Assert.IsFalse(onDispose);
			onBegin = false;
			onTick = false;

			brain.Dispose();

			Assert.IsFalse(onInitialize);
			Assert.IsFalse(onBegin);
			Assert.IsFalse(onTick);
			Assert.IsFalse(onEnd);
			Assert.IsTrue(onDispose);
		}

		[Test]
		public static void MinimalUtilityDifferenceTest()
		{
			var blackboard = new Blackboard();
			var valuePropertyName = new BlackboardPropertyName("value");

			var builder = new BrainBuilder();

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<LinearConsideration, float, float, float, BlackboardPropertyName>(1f, 0f, 0f, valuePropertyName);

			builder.AddAction<DoNothingAction>();
			builder.AddConsideration<ConstantConsideration, float>(1f);

			blackboard.SetStructValue(valuePropertyName, 1.1f);
			var brainInfo = new BrainDebugInfo();

			Brain brain = builder.Build(blackboard, new BrainSettings {minimalUtilityDifference = 1f});
			brain.Initialize();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[0].isActive);

			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[0].isActive);

			blackboard.SetStructValue(valuePropertyName, 0.5f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[0].isActive);

			blackboard.SetStructValue(valuePropertyName, -1f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[1].isActive);

			blackboard.SetStructValue(valuePropertyName, 0.5f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[1].isActive);

			blackboard.SetStructValue(valuePropertyName, 2f);
			brain.Tick();
			brain.FillDebugInfo(brainInfo);
			Assert.IsTrue(brainInfo.actionInfos[0].isActive);

			brain.Dispose();
		}

		private class TestAction : Action, ISetupable<System.Action, System.Action, System.Action, System.Action, System.Action>
		{
			private System.Action m_onInitialize;
			private System.Action m_onBegin;
			private System.Action m_onTick;
			private System.Action m_onEnd;
			private System.Action m_onDispose;

			public void Setup(System.Action arg0, System.Action arg1, System.Action arg2, System.Action arg3, System.Action arg4)
			{
				m_onInitialize = arg0;
				m_onBegin = arg1;
				m_onTick = arg2;
				m_onEnd = arg3;
				m_onDispose = arg4;
			}

			protected override void OnInitialize()
			{
				m_onInitialize?.Invoke();
			}

			protected override void OnBegin()
			{
				m_onBegin?.Invoke();
			}

			protected override void OnTick()
			{
				m_onTick?.Invoke();
			}

			protected override void OnEnd()
			{
				m_onEnd?.Invoke();
			}

			protected override void OnDispose()
			{
				m_onDispose?.Invoke();
			}
		}
	}
}
