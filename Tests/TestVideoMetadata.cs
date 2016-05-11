using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestVideoMetadata
  {
    [TestMethod]
    public void TestConstructor()
    {
      IVideoMetadata metadata = new VideoMetadata();
    }

    [TestMethod]
    public void TestSave()
    {
      Save("test");
    }

    public static void Save(string key)
    {
      IVideoMetadata metadata = new VideoMetadata();
      metadata.Id = key;
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testVideoMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      Save("test");
      using (XmlReader reader = Helpers.CreateXmlReader(@"testVideoMetadata.cxml"))
        new VideoMetadata().Load("test", reader, null);
    }

  }
}
