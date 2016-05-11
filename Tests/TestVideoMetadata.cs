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
      IVideoMetadata metadata = new VideoMetadata();
      metadata.Clear();
      metadata.Id = "22";
      metadata.Filename = "testVideo.wmv";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testVideoMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      TestSave();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testVideoMetadata.cxml"))
      {
        IVideoMetadata metadata = (IVideoMetadata)new VideoMetadata().Load("testVideo.wmv", reader, null);
        Assert.AreEqual("22", metadata.Id);
        Assert.AreEqual("testVideo.wmv", metadata.Filename);
      }
    }

  }
}
