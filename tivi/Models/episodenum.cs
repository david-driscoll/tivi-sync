using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

public partial class Episodenum : XTypedElement, IXMetaData
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

  public static Episodenum Load(string xmlFile)
  {
    return XTypedServices.Load<Episodenum>(xmlFile);
  }

  public static Episodenum Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Episodenum>(xmlFile);
  }

  public static Episodenum Parse(string xml)
  {
    return XTypedServices.Parse<Episodenum>(xml);
  }

  public static explicit operator Episodenum(XElement xe) { return XTypedServices.ToXTypedElement<Episodenum>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Episodenum>(this);
  }

  public Episodenum()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SystemXName = global::System.Xml.Linq.XName.Get("system", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static string _systemDefaultValue = "onscreen";

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
        return _systemDefaultValue;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SystemXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = global::System.Xml.Linq.XName.Get("episode-num", "");

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