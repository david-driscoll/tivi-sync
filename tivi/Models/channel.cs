using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (displayname+, icon*, url*)
/// </para>
/// </summary>
public partial class Channel : XTypedElement, IXMetaData
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

  public static Channel Load(string xmlFile)
  {
    return XTypedServices.Load<Channel>(xmlFile);
  }

  public static Channel Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Channel>(xmlFile);
  }

  public static Channel Parse(string xml)
  {
    return XTypedServices.Parse<Channel>(xml);
  }

  public static explicit operator Channel(XElement xe) { return XTypedServices.ToXTypedElement<Channel>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Channel>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (displayname+, icon*, url*)
  /// </para>
  /// </summary>
  public Channel()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName DisplaynameXName = System.Xml.Linq.XName.Get("display-name", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Displayname> _displaynameField;

  /// <summary>
  /// <para>
  /// Occurrence: required, repeating
  /// </para>
  /// <para>
  /// Regular expression: (displayname+, icon*, url*)
  /// </para>
  /// </summary>
  public virtual IList<Displayname> Displayname
  {
    get
    {
      if ((this._displaynameField == null))
      {
        this._displaynameField = new XTypedList<Displayname>(this, LinqToXsdTypeManager.Instance, DisplaynameXName);
      }
      return this._displaynameField;
    }
    set
    {
      if ((value == null))
      {
        this._displaynameField = null;
      }
      else
      {
        if ((this._displaynameField == null))
        {
          this._displaynameField = XTypedList<Displayname>.Initialize(this, LinqToXsdTypeManager.Instance, value, DisplaynameXName);
        }
        else
        {
          XTypedServices.SetList<Displayname>(this._displaynameField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName IconXName = System.Xml.Linq.XName.Get("icon", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Icon> _iconField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (displayname+, icon*, url*)
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
  protected internal static readonly System.Xml.Linq.XName UrlXName = System.Xml.Linq.XName.Get("url", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Url> _urlField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (displayname+, icon*, url*)
  /// </para>
  /// </summary>
  public virtual IList<Url> Url
  {
    get
    {
      if ((this._urlField == null))
      {
        this._urlField = new XTypedList<Url>(this, LinqToXsdTypeManager.Instance, UrlXName);
      }
      return this._urlField;
    }
    set
    {
      if ((value == null))
      {
        this._urlField = null;
      }
      else
      {
        if ((this._urlField == null))
        {
          this._urlField = XTypedList<Url>.Initialize(this, LinqToXsdTypeManager.Instance, value, UrlXName);
        }
        else
        {
          XTypedServices.SetList<Url>(this._urlField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName IdXName = System.Xml.Linq.XName.Get("id", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// </summary>
  public virtual string Id
  {
    get
    {
      XAttribute x = this.Attribute(IdXName);
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(IdXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("channel", "");

  static Channel()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(DisplaynameXName), new NamedContentModelEntity(IconXName), new NamedContentModelEntity(UrlXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(DisplaynameXName, typeof(Displayname));
    _localElementDictionary.Add(IconXName, typeof(Icon));
    _localElementDictionary.Add(UrlXName, typeof(Url));
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