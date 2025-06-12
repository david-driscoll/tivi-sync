using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (present?, colour?, aspect?, quality?)
/// </para>
/// </summary>
public partial class Video : XTypedElement, IXMetaData
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

  public static Video Load(string xmlFile)
  {
    return XTypedServices.Load<Video>(xmlFile);
  }

  public static Video Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Video>(xmlFile);
  }

  public static Video Parse(string xml)
  {
    return XTypedServices.Parse<Video>(xml);
  }

  public static explicit operator Video(XElement xe) { return XTypedServices.ToXTypedElement<Video>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Video>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (present?, colour?, aspect?, quality?)
  /// </para>
  /// </summary>
  public Video()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName PresentXName = System.Xml.Linq.XName.Get("present", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (present?, colour?, aspect?, quality?)
  /// </para>
  /// </summary>
  public virtual Present Present
  {
    get
    {
      XElement x = this.GetElement(PresentXName);
      if ((x == null))
      {
        return null;
      }
      return ((Present)(x));
    }
    set
    {
      this.SetElement(PresentXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ColourXName = System.Xml.Linq.XName.Get("colour", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (present?, colour?, aspect?, quality?)
  /// </para>
  /// </summary>
  public virtual Colour Colour
  {
    get
    {
      XElement x = this.GetElement(ColourXName);
      if ((x == null))
      {
        return null;
      }
      return ((Colour)(x));
    }
    set
    {
      this.SetElement(ColourXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName AspectXName = System.Xml.Linq.XName.Get("aspect", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (present?, colour?, aspect?, quality?)
  /// </para>
  /// </summary>
  public virtual Aspect Aspect
  {
    get
    {
      XElement x = this.GetElement(AspectXName);
      if ((x == null))
      {
        return null;
      }
      return ((Aspect)(x));
    }
    set
    {
      this.SetElement(AspectXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName QualityXName = System.Xml.Linq.XName.Get("quality", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (present?, colour?, aspect?, quality?)
  /// </para>
  /// </summary>
  public virtual Quality Quality
  {
    get
    {
      XElement x = this.GetElement(QualityXName);
      if ((x == null))
      {
        return null;
      }
      return ((Quality)(x));
    }
    set
    {
      this.SetElement(QualityXName, value);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("video", "");

  static Video()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(PresentXName), new NamedContentModelEntity(ColourXName), new NamedContentModelEntity(AspectXName), new NamedContentModelEntity(QualityXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(PresentXName, typeof(Present));
    _localElementDictionary.Add(ColourXName, typeof(Colour));
    _localElementDictionary.Add(AspectXName, typeof(Aspect));
    _localElementDictionary.Add(QualityXName, typeof(Quality));
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