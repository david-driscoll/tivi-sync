using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (language?)
/// </para>
/// </summary>
public partial class Subtitles : XTypedElement, IXMetaData
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

  public static Subtitles Load(string xmlFile)
  {
    return XTypedServices.Load<Subtitles>(xmlFile);
  }

  public static Subtitles Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Subtitles>(xmlFile);
  }

  public static Subtitles Parse(string xml)
  {
    return XTypedServices.Parse<Subtitles>(xml);
  }

  public static explicit operator Subtitles(XElement xe) { return XTypedServices.ToXTypedElement<Subtitles>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Subtitles>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (language?)
  /// </para>
  /// </summary>
  public Subtitles()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName LanguageXName = System.Xml.Linq.XName.Get("language", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (language?)
  /// </para>
  /// </summary>
  public virtual Language Language
  {
    get
    {
      XElement x = this.GetElement(LanguageXName);
      if ((x == null))
      {
        return null;
      }
      return ((Language)(x));
    }
    set
    {
      this.SetElement(LanguageXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName TypeXName = System.Xml.Linq.XName.Get("type", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Type
  {
    get
    {
      XAttribute x = this.Attribute(TypeXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
    set
    {
      this.SetAttribute(TypeXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Token).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("subtitles", "");

  static Subtitles()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(LanguageXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(LanguageXName, typeof(Language));
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