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
      IImageMetadata metadata = new ImageMetadata();
      metadata.Clear();
      metadata.Id = "33";
      metadata.Filename = "testImage.jpg";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testImageMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      TestSave();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testImageMetadata.cxml"))
      {
        IImageMetadata metadata = (IImageMetadata)new ImageMetadata().Load("testImage.jpg", reader, null);
        Assert.AreEqual("33", metadata.Id);
        Assert.AreEqual("testImage.jpg", metadata.Filename);
      }
    }

  }
}
