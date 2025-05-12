using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class Stereo : XTypedElement, IXMetaData
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

  public static Stereo Load(string xmlFile)
  {
    return XTypedServices.Load<Stereo>(xmlFile);
  }

  public static Stereo Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Stereo>(xmlFile);
  }

  public static Stereo Parse(string xml)
  {
    return XTypedServices.Parse<Stereo>(xml);
  }

  public static explicit operator Stereo(XElement xe) { return XTypedServices.ToXTypedElement<Stereo>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Stereo>(this);
  }

  public Stereo()
  {
  }

  public Stereo(string content)
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

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("stereo", "");

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