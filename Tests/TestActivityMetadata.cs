//Project: ClipFlair.Metadata (https://github.com/Zoomicon/ClipFlair.Metadata)
//Filename: TestActivityMetadata.cs
//Version: 20160514

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ClipFlair.Metadata.Tests
{
  [TestClass]
  public class TestActivityMetadata
  {
    [TestMethod]
    public void CreateActivityMetadata()
    {
      IActivityMetadata metadata = new ActivityMetadata();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveActivityMetadata()
    {
      IActivityMetadata metadata = new ActivityMetadata();
      metadata.Clear();
      metadata.Id = "11";
      metadata.Filename = "testActivity.clipflair";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testActivityMetadata.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadActivityMetadata()
    {
      SaveActivityMetadata();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testActivityMetadata.cxml"))
      {
        IActivityMetadata metadata = (IActivityMetadata)new ActivityMetadata().Load("testActivity.clipflair", reader, null);
        Assert.AreEqual("11", metadata.Id);
        Assert.AreEqual("testActivity.clipflair", metadata.Filename);
      }

    }

  }
}
