// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Core.Considerations;

namespace Zor.UtilityAI.Tests
{
	public static class ConsiderationTests
	{
		private static readonly MethodInfo s_setBlackboardMethod = typeof(Consideration).GetMethod("SetBlackboard", BindingFlags.Instance | BindingFlags.NonPublic);

		[Test]
		public static void AbsoluteConsiderationTest()
		{
			var blackboard = new Blackboard();
			float slope = 2f;
			float verticalShift = 5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			AbsoluteConsideration consideration =
				Consideration.Create<AbsoluteConsideration, float, float, float, BlackboardPropertyName>(slope,
					verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(7f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-1f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(9f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			slope = -3f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<AbsoluteConsideration, float, float, float, BlackboardPropertyName>(slope,
					verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(1f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-11f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(4f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void ConstantConsiderationTest()
		{
			float value = 0f;
			ConstantConsideration consideration = Consideration.Create<ConstantConsideration, float>(value);
			Assert.AreEqual(value, consideration.ComputeUtility(), 0.001D);

			value = 5f;
			consideration = Consideration.Create<ConstantConsideration, float>(value);
			Assert.AreEqual(value, consideration.ComputeUtility(), 0.001D);

			value = -10f;
			consideration = Consideration.Create<ConstantConsideration, float>(value);
			Assert.AreEqual(value, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void CurveConsiderationTest()
		{
			var blackboard = new Blackboard();
			AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			var valuePropertyName = new BlackboardPropertyName("value");
			CurveConsideration consideration =
				Consideration.Create<CurveConsideration, AnimationCurve, BlackboardPropertyName>(curve,
					valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 1f);
			Assert.AreEqual(1f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			curve = AnimationCurve.Linear(0f, 1f, 1f, 0f);
			consideration =
				Consideration.Create<CurveConsideration, AnimationCurve, BlackboardPropertyName>(curve,
					valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(1f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 1f);
			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void ExponentialConsiderationTest()
		{
			var blackboard = new Blackboard();
			float @base = 2f;
			float steepness = -3f;
			float verticalShift = 5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			ExponentialConsideration consideration =
				Consideration.Create<ExponentialConsideration, float, float, float, float, BlackboardPropertyName>(
					@base, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-3.09375f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-4.5f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(-3.046875f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			@base = -3f;
			steepness = 6f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<ExponentialConsideration, float, float, float, float, BlackboardPropertyName>(
					@base, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-14f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-1454f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(10f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void LinearConsiderationTest()
		{
			var blackboard = new Blackboard();
			float slope = 2f;
			float verticalShift = 5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			LinearConsideration consideration =
				Consideration.Create<LinearConsideration, float, float, float, BlackboardPropertyName>(slope,
					verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-13f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-5f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(-15f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			slope = -3f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<LinearConsideration, float, float, float, BlackboardPropertyName>(slope,
					verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(1f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-11f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(4f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void LogarithmicConsiderationTest()
		{
			var blackboard = new Blackboard();
			float @base = 2f;
			float steepness = -6f;
			float verticalShift = -5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			LogarithmicConsideration consideration =
				Consideration.Create<LogarithmicConsideration, float, float, float, float, BlackboardPropertyName>(
				@base, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-16.931568569f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-22.019550008f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(-15f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			@base = 3f;
			steepness = 7f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<LogarithmicConsideration, float, float, float, float, BlackboardPropertyName>(
					@base, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(4f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(14.2548146450f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 1f);
			Assert.AreEqual(8.41650827500f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void LogisticConsiderationTest()
		{
			var blackboard = new Blackboard();
			float supremum = 2f;
			float steepness = -3f;
			float verticalShift = 5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			LogisticConsideration consideration =
				Consideration.Create<LogisticConsideration, float, float, float, float, BlackboardPropertyName>(
					supremum, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-1.000000611f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-1.09485174f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(-1.0000000304f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			supremum = -3f;
			steepness = 6f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<LogisticConsideration, float, float, float, float, BlackboardPropertyName>(
					supremum, steepness, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(1.00741786946f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(1.00000000000f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(2.5f, consideration.ComputeUtility(), 0.001D);
		}

		[Test]
		public static void QuadraticConsiderationTest()
		{
			var blackboard = new Blackboard();
			float slope = 2f;
			float exponent = -3f;
			float verticalShift = 5f;
			float horizontalShift = -3f;
			var valuePropertyName = new BlackboardPropertyName("value");
			QuadraticConsideration consideration =
				Consideration.Create<QuadraticConsideration, float, float, float, float, BlackboardPropertyName>(
					slope, exponent, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(-3.016f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-5f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(-3.009259259f, consideration.ComputeUtility(), 0.001D);

			blackboard.Clear();
			slope = -3f;
			exponent = 6f;
			verticalShift = -1f;
			horizontalShift = 4f;
			consideration =
				Consideration.Create<QuadraticConsideration, float, float, float, float, BlackboardPropertyName>(
					slope, exponent, verticalShift, horizontalShift, valuePropertyName);
			s_setBlackboardMethod.Invoke(consideration, new object[] { blackboard });

			Assert.AreEqual(0f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 0f);
			Assert.AreEqual(1f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, 4f);
			Assert.AreEqual(-46871f, consideration.ComputeUtility(), 0.001D);

			blackboard.SetStructValue(valuePropertyName, -1f);
			Assert.AreEqual(4f, consideration.ComputeUtility(), 0.001D);
		}
	}
}
