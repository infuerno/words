using Presentation.Controllers;
using System;
using Xunit;

namespace Presentation.Tests
{
    public class WordsControllerTests
    {
        [Fact]
        public void ConstructorThrowsExceptionWithNullArgument()
        {
            new WordsController(null);
        }
    }
}
