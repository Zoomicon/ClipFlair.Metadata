using ClipFlair.Metadata;

using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    public void TestStorage()
    {
      IActivityMetadata metadata = new ActivityMetadata();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testActivity.cxml"))
        metadata.Save(writer);
    }



  }
}
