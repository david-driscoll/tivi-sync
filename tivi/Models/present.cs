using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

public partial class Present : XTypedElement, IXMetaData
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

  public static Present Load(string xmlFile)
  {
    return XTypedServices.Load<Present>(xmlFile);
  }

  public static Present Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Present>(xmlFile);
  }

  public static Present Parse(string xml)
  {
    return XTypedServices.Parse<Present>(xml);
  }

  public static explicit operator Present(XElement xe) { return XTypedServices.ToXTypedElement<Present>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Present>(this);
  }

  public Present()
  {
  }

  public Present(string content)
  {
    this.TypedValue = content;
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName TypedValueXName = System.Xml.Linq.XName.Get("TypedValue", "");

  public virtual string TypedValue
  {
    get
    {
      XElement x = this.Untyped;
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
    }
    set
    {
      this.SetValue(value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("present", "");

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