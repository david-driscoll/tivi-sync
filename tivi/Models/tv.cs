using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (channel*, programme*)
/// </para>
/// </summary>
public partial class Tv : XTypedElement, IXMetaData
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

  public static Tv Load(string xmlFile)
  {
    return XTypedServices.Load<Tv>(xmlFile);
  }

  public static Tv Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Tv>(xmlFile);
  }

  public static Tv Parse(string xml)
  {
    return XTypedServices.Parse<Tv>(xml);
  }

  public static explicit operator Tv(XElement xe) { return XTypedServices.ToXTypedElement<Tv>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Tv>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (channel*, programme*)
  /// </para>
  /// </summary>
  public Tv()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ChannelXName = System.Xml.Linq.XName.Get("channel", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Channel> _channelField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (channel*, programme*)
  /// </para>
  /// </summary>
  public virtual IList<Channel> Channel
  {
    get
    {
      if ((this._channelField == null))
      {
        this._channelField = new XTypedList<Channel>(this, LinqToXsdTypeManager.Instance, ChannelXName);
      }
      return this._channelField;
    }
    set
    {
      if ((value == null))
      {
        this._channelField = null;
      }
      else
      {
        if ((this._channelField == null))
        {
          this._channelField = XTypedList<Channel>.Initialize(this, LinqToXsdTypeManager.Instance, value, ChannelXName);
        }
        else
        {
          XTypedServices.SetList<Channel>(this._channelField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ProgrammeXName = System.Xml.Linq.XName.Get("programme", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Programme> _programmeField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (channel*, programme*)
  /// </para>
  /// </summary>
  public virtual IList<Programme> Programme
  {
    get
    {
      if ((this._programmeField == null))
      {
        this._programmeField = new XTypedList<Programme>(this, LinqToXsdTypeManager.Instance, ProgrammeXName);
      }
      return this._programmeField;
    }
    set
    {
      if ((value == null))
      {
        this._programmeField = null;
      }
      else
      {
        if ((this._programmeField == null))
        {
          this._programmeField = XTypedList<Programme>.Initialize(this, LinqToXsdTypeManager.Instance, value, ProgrammeXName);
        }
        else
        {
          XTypedServices.SetList<Programme>(this._programmeField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName DateXName = System.Xml.Linq.XName.Get("date", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Date
  {
    get
    {
      XAttribute x = this.Attribute(DateXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(DateXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SourceinfourlXName = System.Xml.Linq.XName.Get("source-info-url", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Sourceinfourl
  {
    get
    {
      XAttribute x = this.Attribute(SourceinfourlXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SourceinfourlXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SourceinfonameXName = System.Xml.Linq.XName.Get("source-info-name", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Sourceinfoname
  {
    get
    {
      XAttribute x = this.Attribute(SourceinfonameXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SourceinfonameXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SourcedataurlXName = System.Xml.Linq.XName.Get("source-data-url", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Sourcedataurl
  {
    get
    {
      XAttribute x = this.Attribute(SourcedataurlXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(SourcedataurlXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName GeneratorinfonameXName = System.Xml.Linq.XName.Get("generator-info-name", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Generatorinfoname
  {
    get
    {
      XAttribute x = this.Attribute(GeneratorinfonameXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(GeneratorinfonameXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName GeneratorinfourlXName = System.Xml.Linq.XName.Get("generator-info-url", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Generatorinfourl
  {
    get
    {
      XAttribute x = this.Attribute(GeneratorinfourlXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(GeneratorinfourlXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("tv", "");

  static Tv()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(ChannelXName), new NamedContentModelEntity(ProgrammeXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(ChannelXName, typeof(Channel));
    _localElementDictionary.Add(ProgrammeXName, typeof(Programme));
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