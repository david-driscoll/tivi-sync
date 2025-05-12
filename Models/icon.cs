using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class Icon : XTypedElement, IXMetaData
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

  public static Icon Load(string xmlFile)
  {
    return XTypedServices.Load<Icon>(xmlFile);
  }

  public static Icon Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Icon>(xmlFile);
  }

  public static Icon Parse(string xml)
  {
    return XTypedServices.Parse<Icon>(xml);
  }

  public static explicit operator Icon(XElement xe) { return XTypedServices.ToXTypedElement<Icon>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Icon>(this);
  }

  public Icon()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SrcXName = System.Xml.Linq.XName.Get("src", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// </summary>
  public virtual string Src
  {
    get
    {
      XAttribute x = this.Attribute(SrcXName);
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SrcXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName WidthXName = System.Xml.Linq.XName.Get("width", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Width
  {
    get
    {
      XAttribute x = this.Attribute(WidthXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(WidthXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName HeightXName = System.Xml.Linq.XName.Get("height", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Height
  {
    get
    {
      XAttribute x = this.Attribute(HeightXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(HeightXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("icon", "");

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