namespace TestDll.Test
{
	public enum TestEnum
	{
		One,
		Two
	}

	public class TestObject
	{
		
	}
	
	public class TestInject
	{
		public TestEnum TestReturnEnum()
		{
			return TestEnum.One;
		}

		public TestObject TestReturnObject()
		{
			return new TestObject();
		}
	}
}