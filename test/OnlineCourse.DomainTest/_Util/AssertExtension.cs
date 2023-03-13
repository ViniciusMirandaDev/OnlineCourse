namespace OnlineCourse.DomainTest._Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException ex, string message)
        {
            if (ex.Message == message)
                Assert.True(true);
            else
                Assert.False(true, "Expected message:" + message);
        }
    }
}
