using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (value, icon*)
/// </para>
/// </summary>
public partial class Rating : XTypedElement, IXMetaData
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

  public static Rating Load(string xmlFile)
  {
    return XTypedServices.Load<Rating>(xmlFile);
  }

  public static Rating Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Rating>(xmlFile);
  }

  public static Rating Parse(string xml)
  {
    return XTypedServices.Parse<Rating>(xml);
  }

  public static explicit operator Rating(XElement xe) { return XTypedServices.ToXTypedElement<Rating>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Rating>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (value, icon*)
  /// </para>
  /// </summary>
  public Rating()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ValueXName = global::System.Xml.Linq.XName.Get("value", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// <para>
  /// Regular expression: (value, icon*)
  /// </para>
  /// </summary>
  public virtual Value Value
  {
    get
    {
      XElement x = this.GetElement(ValueXName);
      return ((Value)(x));
    }
    set
    {
      this.SetElement(ValueXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName IconXName = global::System.Xml.Linq.XName.Get("icon", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Icon> _iconField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (value, icon*)
  /// </para>
  /// </summary>
  public virtual IList<Icon> Icon
  {
    get
    {
      if ((this._iconField == null))
      {
        this._iconField = new XTypedList<Icon>(this, LinqToXsdTypeManager.Instance, IconXName);
      }
      return this._iconField;
    }
    set
    {
      if ((value == null))
      {
        this._iconField = null;
      }
      else
      {
        if ((this._iconField == null))
        {
          this._iconField = XTypedList<Icon>.Initialize(this, LinqToXsdTypeManager.Instance, value, IconXName);
        }
        else
        {
          XTypedServices.SetList<Icon>(this._iconField, value);
        }
      }
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

  private static readonly System.Xml.Linq.XName XName = global::System.Xml.Linq.XName.Get("rating", "");

  static Rating()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(ValueXName), new NamedContentModelEntity(IconXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(ValueXName, typeof(Value));
    _localElementDictionary.Add(IconXName, typeof(Icon));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary
  {
    get
    {
      return _localElementDictionary;
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static ContentModelEntity _contentModel;

  ContentModelEntity IXMetaData.GetContentModel()
  {
    return _contentModel;
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