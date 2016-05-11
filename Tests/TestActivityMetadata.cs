using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestActivityMetadata
  {
    [TestMethod]
    public void TestConstructor()
    {
      IActivityMetadata metadata = new ActivityMetadata();
    }

    [TestMethod]
    public void TestSave()
    {
      Save("test");
    }

    public static void Save(string key)
    {
      IActivityMetadata metadata = new ActivityMetadata();
      metadata.Id = key;
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testActivityMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      Save("test");
      using (XmlReader reader = Helpers.CreateXmlReader(@"testActivityMetadata.cxml"))
        new ActivityMetadata().Load("test", reader, null);
    }

  }
}
