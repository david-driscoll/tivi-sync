using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class Length : XTypedElement, IXMetaData
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

  public static Length Load(string xmlFile)
  {
    return XTypedServices.Load<Length>(xmlFile);
  }

  public static Length Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Length>(xmlFile);
  }

  public static Length Parse(string xml)
  {
    return XTypedServices.Parse<Length>(xml);
  }

  public static explicit operator Length(XElement xe) { return XTypedServices.ToXTypedElement<Length>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Length>(this);
  }

  public Length()
  {
  }

  public enum UnitsEnum
  {

    Seconds,

    Minutes,

    Hours,
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName UnitsXName = System.Xml.Linq.XName.Get("units", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// </summary>
  public virtual UnitsEnum Units
  {
    get
    {
      XAttribute x = this.Attribute(UnitsXName);
      return ((UnitsEnum)(Enum.Parse(typeof(UnitsEnum), XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype))));
    }
    set
    {
      this.SetAttribute(UnitsXName, value.ToString(), XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("length", "");

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