using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace Tivi.Models;

public partial class XRootNamespace
{

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XDocument _doc;

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedElement _rootObject;

  private XRootNamespace()
  {
  }

  public static XRootNamespace Load(string xmlFile)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Load(xmlFile);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Load(string xmlFile, LoadOptions options)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Load(xmlFile, options);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Load(TextReader textReader)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Load(textReader);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Load(TextReader textReader, LoadOptions options)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Load(textReader, options);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Load(XmlReader xmlReader)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Load(xmlReader);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Parse(string text)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Parse(text);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRootNamespace Parse(string text, LoadOptions options)
  {
    XRootNamespace root = new XRootNamespace();
    root._doc = XDocument.Parse(text, options);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public virtual void Save(string fileName)
  {
    _doc.Save(fileName);
  }

  public virtual void Save(TextWriter textWriter)
  {
    _doc.Save(textWriter);
  }

  public virtual void Save(XmlWriter writer)
  {
    _doc.Save(writer);
  }

  public virtual void Save(TextWriter textWriter, SaveOptions options)
  {
    _doc.Save(textWriter, options);
  }

  public virtual void Save(string fileName, SaveOptions options)
  {
    _doc.Save(fileName, options);
  }

  public virtual XDocument XDocument
  {
    get
    {
      return _doc;
    }
  }

  public virtual XTypedElement Root
  {
    get
    {
      return _rootObject;
    }
  }

  public XRootNamespace(Tv root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Tv Tv { get { return _rootObject as Tv; } }

  public XRootNamespace(Channel root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Channel Channel { get { return _rootObject as Channel; } }

  public XRootNamespace(Displayname root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Displayname Displayname { get { return _rootObject as Displayname; } }

  public XRootNamespace(Icon root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Icon Icon { get { return _rootObject as Icon; } }

  public XRootNamespace(Url root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Url Url { get { return _rootObject as Url; } }

  public XRootNamespace(Programme root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Programme Programme { get { return _rootObject as Programme; } }

  public XRootNamespace(Title root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Title Title { get { return _rootObject as Title; } }

  public XRootNamespace(Subtitle root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Subtitle Subtitle { get { return _rootObject as Subtitle; } }

  public XRootNamespace(Desc root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Desc Desc { get { return _rootObject as Desc; } }

  public XRootNamespace(Credits root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Credits Credits { get { return _rootObject as Credits; } }

  public XRootNamespace(Director root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Director Director { get { return _rootObject as Director; } }

  public XRootNamespace(Actor root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Actor Actor { get { return _rootObject as Actor; } }

  public XRootNamespace(Writer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Writer Writer { get { return _rootObject as Writer; } }

  public XRootNamespace(Adapter root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Adapter Adapter { get { return _rootObject as Adapter; } }

  public XRootNamespace(Producer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Producer Producer { get { return _rootObject as Producer; } }

  public XRootNamespace(Composer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Composer Composer { get { return _rootObject as Composer; } }

  public XRootNamespace(Editor root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Editor Editor { get { return _rootObject as Editor; } }

  public XRootNamespace(Presenter root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Presenter Presenter { get { return _rootObject as Presenter; } }

  public XRootNamespace(Commentator root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Commentator Commentator { get { return _rootObject as Commentator; } }

  public XRootNamespace(Guest root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Guest Guest { get { return _rootObject as Guest; } }

  public XRootNamespace(Category root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Category Category { get { return _rootObject as Category; } }

  public XRootNamespace(Keyword root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Keyword Keyword { get { return _rootObject as Keyword; } }

  public XRootNamespace(Language root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Language Language { get { return _rootObject as Language; } }

  public XRootNamespace(Origlanguage root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Origlanguage Origlanguage { get { return _rootObject as Origlanguage; } }

  public XRootNamespace(Length root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Length Length { get { return _rootObject as Length; } }

  public XRootNamespace(Country root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Country Country { get { return _rootObject as Country; } }

  public XRootNamespace(Episodenum root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Episodenum Episodenum { get { return _rootObject as Episodenum; } }

  public XRootNamespace(Video root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Video Video { get { return _rootObject as Video; } }

  public XRootNamespace(Audio root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Audio Audio { get { return _rootObject as Audio; } }

  public XRootNamespace(Previouslyshown root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Previouslyshown Previouslyshown { get { return _rootObject as Previouslyshown; } }

  public XRootNamespace(Premiere root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Premiere Premiere { get { return _rootObject as Premiere; } }

  public XRootNamespace(Lastchance root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Lastchance Lastchance { get { return _rootObject as Lastchance; } }

  public XRootNamespace(New root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public New New { get { return _rootObject as New; } }

  public XRootNamespace(Subtitles root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Subtitles Subtitles { get { return _rootObject as Subtitles; } }

  public XRootNamespace(Rating root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Rating Rating { get { return _rootObject as Rating; } }

  public XRootNamespace(Starrating root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Starrating Starrating { get { return _rootObject as Starrating; } }

  public XRootNamespace(Review root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Review Review { get { return _rootObject as Review; } }

  public XRootNamespace(Image root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Image Image { get { return _rootObject as Image; } }

  public XRootNamespace(Date root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Date Date { get { return _rootObject as Date; } }

  public XRootNamespace(Present root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Present Present { get { return _rootObject as Present; } }

  public XRootNamespace(Colour root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Colour Colour { get { return _rootObject as Colour; } }

  public XRootNamespace(Aspect root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Aspect Aspect { get { return _rootObject as Aspect; } }

  public XRootNamespace(Quality root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Quality Quality { get { return _rootObject as Quality; } }

  public XRootNamespace(Stereo root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Stereo Stereo { get { return _rootObject as Stereo; } }

  public XRootNamespace(Value root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Value Value { get { return _rootObject as Value; } }
}