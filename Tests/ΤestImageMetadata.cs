using ClipFlair.Metadata;

using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    public void TestStorage()
    {
      IImageMetadata metadata = new ImageMetadata();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testImage.cxml"))
        metadata.Save(writer);
    }



  }
}
