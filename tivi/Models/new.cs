using System.Diagnostics;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class New : XTypedElement, IXMetaData
{

  public void Save(string xmlFile)
  {
    XTypedServices.Save(xmlFile, Untyped);
  }

  public void Save(System.IO.TextWriter tw)
  {
    XTypedServices.Save(tw, Untyped);
  }

  public void Save(System.Xml.XmlWriter xmlWriter)
  {
    XTypedServices.Save(xmlWriter, Untyped);
  }

  public static New Load(string xmlFile)
  {
    return XTypedServices.Load<New>(xmlFile);
  }

  public static New Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<New>(xmlFile);
  }

  public static New Parse(string xml)
  {
    return XTypedServices.Parse<New>(xml);
  }

  public static explicit operator New(XElement xe) { return XTypedServices.ToXTypedElement<New>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<New>(this);
  }

  public New()
  {
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("new", "");

  ContentModelEntity IXMetaData.GetContentModel()
  {
    return ContentModelEntity.Default;
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  System.Xml.Linq.XName IXMetaData.SchemaName
  {
    get
    {
      return XName;
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  SchemaOrigin IXMetaData.TypeOrigin
  {
    get
    {
      return SchemaOrigin.Element;
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  ILinqToXsdTypeManager IXMetaData.TypeManager
  {
    get
    {
      return LinqToXsdTypeManager.Instance;
    }
  }
}