using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
/// </para>
/// </summary>
public partial class Credits : XTypedElement, IXMetaData
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

  public static Credits Load(string xmlFile)
  {
    return XTypedServices.Load<Credits>(xmlFile);
  }

  public static Credits Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Credits>(xmlFile);
  }

  public static Credits Parse(string xml)
  {
    return XTypedServices.Parse<Credits>(xml);
  }

  public static explicit operator Credits(XElement xe) { return XTypedServices.ToXTypedElement<Credits>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Credits>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public Credits()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName DirectorXName = System.Xml.Linq.XName.Get("director", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Director> _directorField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Director> Director
  {
    get
    {
      if ((this._directorField == null))
      {
        this._directorField = new XTypedList<Director>(this, LinqToXsdTypeManager.Instance, DirectorXName);
      }
      return this._directorField;
    }
    set
    {
      if ((value == null))
      {
        this._directorField = null;
      }
      else
      {
        if ((this._directorField == null))
        {
          this._directorField = XTypedList<Director>.Initialize(this, LinqToXsdTypeManager.Instance, value, DirectorXName);
        }
        else
        {
          XTypedServices.SetList<Director>(this._directorField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ActorXName = System.Xml.Linq.XName.Get("actor", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Actor> _actorField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Actor> Actor
  {
    get
    {
      if ((this._actorField == null))
      {
        this._actorField = new XTypedList<Actor>(this, LinqToXsdTypeManager.Instance, ActorXName);
      }
      return this._actorField;
    }
    set
    {
      if ((value == null))
      {
        this._actorField = null;
      }
      else
      {
        if ((this._actorField == null))
        {
          this._actorField = XTypedList<Actor>.Initialize(this, LinqToXsdTypeManager.Instance, value, ActorXName);
        }
        else
        {
          XTypedServices.SetList<Actor>(this._actorField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName WriterXName = System.Xml.Linq.XName.Get("writer", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Writer> _writerField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Writer> Writer
  {
    get
    {
      if ((this._writerField == null))
      {
        this._writerField = new XTypedList<Writer>(this, LinqToXsdTypeManager.Instance, WriterXName);
      }
      return this._writerField;
    }
    set
    {
      if ((value == null))
      {
        this._writerField = null;
      }
      else
      {
        if ((this._writerField == null))
        {
          this._writerField = XTypedList<Writer>.Initialize(this, LinqToXsdTypeManager.Instance, value, WriterXName);
        }
        else
        {
          XTypedServices.SetList<Writer>(this._writerField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName AdapterXName = System.Xml.Linq.XName.Get("adapter", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Adapter> _adapterField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Adapter> Adapter
  {
    get
    {
      if ((this._adapterField == null))
      {
        this._adapterField = new XTypedList<Adapter>(this, LinqToXsdTypeManager.Instance, AdapterXName);
      }
      return this._adapterField;
    }
    set
    {
      if ((value == null))
      {
        this._adapterField = null;
      }
      else
      {
        if ((this._adapterField == null))
        {
          this._adapterField = XTypedList<Adapter>.Initialize(this, LinqToXsdTypeManager.Instance, value, AdapterXName);
        }
        else
        {
          XTypedServices.SetList<Adapter>(this._adapterField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ProducerXName = System.Xml.Linq.XName.Get("producer", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Producer> _producerField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Producer> Producer
  {
    get
    {
      if ((this._producerField == null))
      {
        this._producerField = new XTypedList<Producer>(this, LinqToXsdTypeManager.Instance, ProducerXName);
      }
      return this._producerField;
    }
    set
    {
      if ((value == null))
      {
        this._producerField = null;
      }
      else
      {
        if ((this._producerField == null))
        {
          this._producerField = XTypedList<Producer>.Initialize(this, LinqToXsdTypeManager.Instance, value, ProducerXName);
        }
        else
        {
          XTypedServices.SetList<Producer>(this._producerField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ComposerXName = System.Xml.Linq.XName.Get("composer", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Composer> _composerField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Composer> Composer
  {
    get
    {
      if ((this._composerField == null))
      {
        this._composerField = new XTypedList<Composer>(this, LinqToXsdTypeManager.Instance, ComposerXName);
      }
      return this._composerField;
    }
    set
    {
      if ((value == null))
      {
        this._composerField = null;
      }
      else
      {
        if ((this._composerField == null))
        {
          this._composerField = XTypedList<Composer>.Initialize(this, LinqToXsdTypeManager.Instance, value, ComposerXName);
        }
        else
        {
          XTypedServices.SetList<Composer>(this._composerField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName EditorXName = System.Xml.Linq.XName.Get("editor", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Editor> _editorField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Editor> Editor
  {
    get
    {
      if ((this._editorField == null))
      {
        this._editorField = new XTypedList<Editor>(this, LinqToXsdTypeManager.Instance, EditorXName);
      }
      return this._editorField;
    }
    set
    {
      if ((value == null))
      {
        this._editorField = null;
      }
      else
      {
        if ((this._editorField == null))
        {
          this._editorField = XTypedList<Editor>.Initialize(this, LinqToXsdTypeManager.Instance, value, EditorXName);
        }
        else
        {
          XTypedServices.SetList<Editor>(this._editorField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName PresenterXName = System.Xml.Linq.XName.Get("presenter", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Presenter> _presenterField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Presenter> Presenter
  {
    get
    {
      if ((this._presenterField == null))
      {
        this._presenterField = new XTypedList<Presenter>(this, LinqToXsdTypeManager.Instance, PresenterXName);
      }
      return this._presenterField;
    }
    set
    {
      if ((value == null))
      {
        this._presenterField = null;
      }
      else
      {
        if ((this._presenterField == null))
        {
          this._presenterField = XTypedList<Presenter>.Initialize(this, LinqToXsdTypeManager.Instance, value, PresenterXName);
        }
        else
        {
          XTypedServices.SetList<Presenter>(this._presenterField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName CommentatorXName = System.Xml.Linq.XName.Get("commentator", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Commentator> _commentatorField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Commentator> Commentator
  {
    get
    {
      if ((this._commentatorField == null))
      {
        this._commentatorField = new XTypedList<Commentator>(this, LinqToXsdTypeManager.Instance, CommentatorXName);
      }
      return this._commentatorField;
    }
    set
    {
      if ((value == null))
      {
        this._commentatorField = null;
      }
      else
      {
        if ((this._commentatorField == null))
        {
          this._commentatorField = XTypedList<Commentator>.Initialize(this, LinqToXsdTypeManager.Instance, value, CommentatorXName);
        }
        else
        {
          XTypedServices.SetList<Commentator>(this._commentatorField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName GuestXName = System.Xml.Linq.XName.Get("guest", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Guest> _guestField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (director*, actor*, writer*, adapter*, producer*, composer*, editor*, presenter*, commentator*, guest*)
  /// </para>
  /// </summary>
  public virtual IList<Guest> Guest
  {
    get
    {
      if ((this._guestField == null))
      {
        this._guestField = new XTypedList<Guest>(this, LinqToXsdTypeManager.Instance, GuestXName);
      }
      return this._guestField;
    }
    set
    {
      if ((value == null))
      {
        this._guestField = null;
      }
      else
      {
        if ((this._guestField == null))
        {
          this._guestField = XTypedList<Guest>.Initialize(this, LinqToXsdTypeManager.Instance, value, GuestXName);
        }
        else
        {
          XTypedServices.SetList<Guest>(this._guestField, value);
        }
      }
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("credits", "");

  static Credits()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(DirectorXName), new NamedContentModelEntity(ActorXName), new NamedContentModelEntity(WriterXName), new NamedContentModelEntity(AdapterXName), new NamedContentModelEntity(ProducerXName), new NamedContentModelEntity(ComposerXName), new NamedContentModelEntity(EditorXName), new NamedContentModelEntity(PresenterXName), new NamedContentModelEntity(CommentatorXName), new NamedContentModelEntity(GuestXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(DirectorXName, typeof(Director));
    _localElementDictionary.Add(ActorXName, typeof(Actor));
    _localElementDictionary.Add(WriterXName, typeof(Writer));
    _localElementDictionary.Add(AdapterXName, typeof(Adapter));
    _localElementDictionary.Add(ProducerXName, typeof(Producer));
    _localElementDictionary.Add(ComposerXName, typeof(Composer));
    _localElementDictionary.Add(EditorXName, typeof(Editor));
    _localElementDictionary.Add(PresenterXName, typeof(Presenter));
    _localElementDictionary.Add(CommentatorXName, typeof(Commentator));
    _localElementDictionary.Add(GuestXName, typeof(Guest));
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