using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace Tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (present?, stereo?)
/// </para>
/// </summary>
public partial class Audio : XTypedElement, IXMetaData
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

  public static Audio Load(string xmlFile)
  {
    return XTypedServices.Load<Audio>(xmlFile);
  }

  public static Audio Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Audio>(xmlFile);
  }

  public static Audio Parse(string xml)
  {
    return XTypedServices.Parse<Audio>(xml);
  }

  public static explicit operator Audio(XElement xe) { return XTypedServices.ToXTypedElement<Audio>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Audio>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (present?, stereo?)
  /// </para>
  /// </summary>
  public Audio()
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
  /// Regular expression: (present?, stereo?)
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
  protected internal static readonly System.Xml.Linq.XName StereoXName = System.Xml.Linq.XName.Get("stereo", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (present?, stereo?)
  /// </para>
  /// </summary>
  public virtual Stereo Stereo
  {
    get
    {
      XElement x = this.GetElement(StereoXName);
      if ((x == null))
      {
        return null;
      }
      return ((Stereo)(x));
    }
    set
    {
      this.SetElement(StereoXName, value);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("audio", "");

  static Audio()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(PresentXName), new NamedContentModelEntity(StereoXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(PresentXName, typeof(Present));
    _localElementDictionary.Add(StereoXName, typeof(Stereo));
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