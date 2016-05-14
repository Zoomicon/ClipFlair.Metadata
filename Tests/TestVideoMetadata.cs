//Project: ClipFlair.Metadata (https://github.com/Zoomicon/ClipFlair.Metadata)
//Filename: TestVideoMetadata.cs
//Version: 20160514

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestVideoMetadata
  {
    [TestMethod]
    public void CreateVideoMetadata()
    {
      IVideoMetadata metadata = new VideoMetadata();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveVideoMetadata()
    {
      IVideoMetadata metadata = new VideoMetadata();
      metadata.Clear();
      metadata.Id = "22";
      metadata.Filename = "testVideo.wmv";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testVideoMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadVideoMetadata()
    {
      SaveVideoMetadata();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testVideoMetadata.cxml"))
      {
        IVideoMetadata metadata = (IVideoMetadata)new VideoMetadata().Load("testVideo.wmv", reader, null);
        Assert.AreEqual("22", metadata.Id);
        Assert.AreEqual("testVideo.wmv", metadata.Filename);
      }
    }

  }
}
