using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestImageMetadata
  {
    [TestMethod]
    public void TestConstructor()
    {
      IImageMetadata metadata = new ImageMetadata();
    }

    [TestMethod]
    public void TestSave()
    {
      Save("test");
    }

    public static void Save(string key)
    {
      IImageMetadata metadata = new ImageMetadata();
      metadata.Id = key;
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testImageMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      Save("test");
      using (XmlReader reader = Helpers.CreateXmlReader(@"testImageMetadata.cxml"))
        new ImageMetadata().Load("test", reader, null);
    }

  }
}
