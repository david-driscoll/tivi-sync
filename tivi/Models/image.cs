using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

public partial class Image : XTypedElement, IXMetaData
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

  public static Image Load(string xmlFile)
  {
    return XTypedServices.Load<Image>(xmlFile);
  }

  public static Image Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Image>(xmlFile);
  }

  public static Image Parse(string xml)
  {
    return XTypedServices.Parse<Image>(xml);
  }

  public static explicit operator Image(XElement xe) { return XTypedServices.ToXTypedElement<Image>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Image>(this);
  }

  public Image()
  {
  }

  public enum TypeEnum
  {

    Poster,

    Backdrop,

    Still,

    Person,

    Character,
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName TypeXName = global::System.Xml.Linq.XName.Get("type", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual TypeEnum? Type
  {
    get
    {
      XAttribute x = this.Attribute(TypeXName);
      if ((x == null))
      {
        return null;
      }
      return ((TypeEnum)(Enum.Parse(typeof(TypeEnum), XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype))));
    }
    set
    {
      this.SetAttribute(TypeXName, value?.ToString(), XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SizeXName = global::System.Xml.Linq.XName.Get("size", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Size
  {
    get
    {
      XAttribute x = this.Attribute(SizeXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
    set
    {
      this.SetAttribute(SizeXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
  }

  public enum OrientEnum
  {

    P,

    L,
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName OrientXName = global::System.Xml.Linq.XName.Get("orient", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual OrientEnum? Orient
  {
    get
    {
      XAttribute x = this.Attribute(OrientXName);
      if ((x == null))
      {
        return null;
      }
      return ((OrientEnum)(Enum.Parse(typeof(OrientEnum), XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype))));
    }
    set
    {
      this.SetAttribute(OrientXName, value?.ToString(), XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SystemXName = global::System.Xml.Linq.XName.Get("system", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string System
  {
    get
    {
      XAttribute x = this.Attribute(SystemXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SystemXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = global::System.Xml.Linq.XName.Get("image", "");

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