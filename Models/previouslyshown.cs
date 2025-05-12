using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class Previouslyshown : XTypedElement, IXMetaData
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

  public static Previouslyshown Load(string xmlFile)
  {
    return XTypedServices.Load<Previouslyshown>(xmlFile);
  }

  public static Previouslyshown Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Previouslyshown>(xmlFile);
  }

  public static Previouslyshown Parse(string xml)
  {
    return XTypedServices.Parse<Previouslyshown>(xml);
  }

  public static explicit operator Previouslyshown(XElement xe) { return XTypedServices.ToXTypedElement<Previouslyshown>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Previouslyshown>(this);
  }

  public Previouslyshown()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName StartXName = System.Xml.Linq.XName.Get("start", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Start
  {
    get
    {
      XAttribute x = this.Attribute(StartXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(StartXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ChannelXName = System.Xml.Linq.XName.Get("channel", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Channel
  {
    get
    {
      XAttribute x = this.Attribute(ChannelXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(ChannelXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("previously-shown", "");

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