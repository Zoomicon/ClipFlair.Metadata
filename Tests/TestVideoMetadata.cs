using ClipFlair.Metadata;

using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    public void TestStorage()
    {
      IVideoMetadata metadata = new VideoMetadata();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testVideo.cxml"))
        metadata.Save(writer);
    }



  }
}
