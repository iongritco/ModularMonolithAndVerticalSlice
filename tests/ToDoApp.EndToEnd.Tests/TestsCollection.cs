using Xunit;

namespace ToDoApp.EndToEnd.Tests;

[CollectionDefinition("Tests collection")]
public class TestsCollection : ICollectionFixture<BaseTestsClass>
{
}
