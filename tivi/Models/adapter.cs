using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (image | url)*
/// </para>
/// </summary>
public partial class Adapter : XTypedElement, IXMetaData
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

  public static Adapter Load(string xmlFile)
  {
    return XTypedServices.Load<Adapter>(xmlFile);
  }

  public static Adapter Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Adapter>(xmlFile);
  }

  public static Adapter Parse(string xml)
  {
    return XTypedServices.Parse<Adapter>(xml);
  }

  public static explicit operator Adapter(XElement xe) { return XTypedServices.ToXTypedElement<Adapter>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Adapter>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (image | url)*
  /// </para>
  /// </summary>
  public Adapter()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ImageXName = System.Xml.Linq.XName.Get("image", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Image> _imageField;

  /// <summary>
  /// <para>
  /// Occurrence: required, choice
  /// </para>
  /// <para>
  /// Regular expression: (image | url)*
  /// </para>
  /// </summary>
  public virtual IList<Image> Image
  {
    get
    {
      if ((this._imageField == null))
      {
        this._imageField = new XTypedList<Image>(this, LinqToXsdTypeManager.Instance, ImageXName);
      }
      return this._imageField;
    }
    set
    {
      if ((value == null))
      {
        this._imageField = null;
      }
      else
      {
        if ((this._imageField == null))
        {
          this._imageField = XTypedList<Image>.Initialize(this, LinqToXsdTypeManager.Instance, value, ImageXName);
        }
        else
        {
          XTypedServices.SetList<Image>(this._imageField, value);
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
  /// Occurrence: required, choice
  /// </para>
  /// <para>
  /// Regular expression: (image | url)*
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

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("adapter", "");

  static Adapter()
  {
    BuildElementDictionary();
    _contentModel = new ChoiceContentModelEntity(new NamedContentModelEntity(ImageXName), new NamedContentModelEntity(UrlXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(ImageXName, typeof(Image));
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