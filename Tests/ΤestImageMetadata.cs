//Project: ClipFlair.Metadata (https://github.com/Zoomicon/ClipFlair.Metadata)
//Filename: TestImageMetadata.cs
//Version: 20160514

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestImageMetadata
  {
    [TestMethod]
    public void CreateImageMetadata()
    {
      IImageMetadata metadata = new ImageMetadata();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveImageMetadata()
    {
      IImageMetadata metadata = new ImageMetadata();
      metadata.Clear();
      metadata.Id = "33";
      metadata.Filename = "testImage.jpg";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testImageMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadImageMetadata()
    {
      SaveImageMetadata();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testImageMetadata.cxml"))
      {
        IImageMetadata metadata = (IImageMetadata)new ImageMetadata().Load("testImage.jpg", reader, null);
        Assert.AreEqual("33", metadata.Id);
        Assert.AreEqual("testImage.jpg", metadata.Filename);
      }
    }

  }
}
