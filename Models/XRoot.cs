using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using Xml.Schema.Linq;

namespace tivi.Models;

public partial class XRoot
{

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XDocument _doc;

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedElement _rootObject;

  private XRoot()
  {
  }

  public static XRoot Load(string xmlFile)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Load(xmlFile);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Load(string xmlFile, LoadOptions options)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Load(xmlFile, options);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Load(TextReader textReader)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Load(textReader);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Load(TextReader textReader, LoadOptions options)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Load(textReader, options);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Load(XmlReader xmlReader)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Load(xmlReader);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Parse(string text)
  {
    XRoot root = new XRoot();
    root._doc = XDocument.Parse(text);
    XTypedElement typedRoot = XTypedServices.ToXTypedElement(root._doc.Root, LinqToXsdTypeManager.Instance);
    if ((typedRoot == null))
    {
      throw new LinqToXsdException("Invalid root element in xml document.");
    }
    root._rootObject = typedRoot;
    return root;
  }

  public static XRoot Parse(string text, LoadOptions options)
  {
    XRoot root = new XRoot();
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

  public XRoot(Tv root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Tv Tv { get { return _rootObject as Tv; } }

  public XRoot(Channel root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Channel Channel { get { return _rootObject as Channel; } }

  public XRoot(Displayname root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Displayname Displayname { get { return _rootObject as Displayname; } }

  public XRoot(Icon root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Icon Icon { get { return _rootObject as Icon; } }

  public XRoot(Url root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Url Url { get { return _rootObject as Url; } }

  public XRoot(Programme root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Programme Programme { get { return _rootObject as Programme; } }

  public XRoot(Title root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Title Title { get { return _rootObject as Title; } }

  public XRoot(Subtitle root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Subtitle Subtitle { get { return _rootObject as Subtitle; } }

  public XRoot(Desc root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Desc Desc { get { return _rootObject as Desc; } }

  public XRoot(Credits root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Credits Credits { get { return _rootObject as Credits; } }

  public XRoot(Director root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Director Director { get { return _rootObject as Director; } }

  public XRoot(Actor root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Actor Actor { get { return _rootObject as Actor; } }

  public XRoot(Writer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Writer Writer { get { return _rootObject as Writer; } }

  public XRoot(Adapter root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Adapter Adapter { get { return _rootObject as Adapter; } }

  public XRoot(Producer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Producer Producer { get { return _rootObject as Producer; } }

  public XRoot(Composer root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Composer Composer { get { return _rootObject as Composer; } }

  public XRoot(Editor root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Editor Editor { get { return _rootObject as Editor; } }

  public XRoot(Presenter root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Presenter Presenter { get { return _rootObject as Presenter; } }

  public XRoot(Commentator root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Commentator Commentator { get { return _rootObject as Commentator; } }

  public XRoot(Guest root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Guest Guest { get { return _rootObject as Guest; } }

  public XRoot(Category root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Category Category { get { return _rootObject as Category; } }

  public XRoot(Keyword root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Keyword Keyword { get { return _rootObject as Keyword; } }

  public XRoot(Language root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Language Language { get { return _rootObject as Language; } }

  public XRoot(Origlanguage root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Origlanguage Origlanguage { get { return _rootObject as Origlanguage; } }

  public XRoot(Length root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Length Length { get { return _rootObject as Length; } }

  public XRoot(Country root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Country Country { get { return _rootObject as Country; } }

  public XRoot(Episodenum root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Episodenum Episodenum { get { return _rootObject as Episodenum; } }

  public XRoot(Video root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Video Video { get { return _rootObject as Video; } }

  public XRoot(Audio root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Audio Audio { get { return _rootObject as Audio; } }

  public XRoot(Previouslyshown root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Previouslyshown Previouslyshown { get { return _rootObject as Previouslyshown; } }

  public XRoot(Premiere root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Premiere Premiere { get { return _rootObject as Premiere; } }

  public XRoot(Lastchance root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Lastchance Lastchance { get { return _rootObject as Lastchance; } }

  public XRoot(New root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public New New { get { return _rootObject as New; } }

  public XRoot(Subtitles root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Subtitles Subtitles { get { return _rootObject as Subtitles; } }

  public XRoot(Rating root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Rating Rating { get { return _rootObject as Rating; } }

  public XRoot(Starrating root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Starrating Starrating { get { return _rootObject as Starrating; } }

  public XRoot(Review root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Review Review { get { return _rootObject as Review; } }

  public XRoot(Image root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Image Image { get { return _rootObject as Image; } }

  public XRoot(Date root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Date Date { get { return _rootObject as Date; } }

  public XRoot(Present root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Present Present { get { return _rootObject as Present; } }

  public XRoot(Colour root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Colour Colour { get { return _rootObject as Colour; } }

  public XRoot(Aspect root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Aspect Aspect { get { return _rootObject as Aspect; } }

  public XRoot(Quality root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Quality Quality { get { return _rootObject as Quality; } }

  public XRoot(Stereo root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Stereo Stereo { get { return _rootObject as Stereo; } }

  public XRoot(Value root)
  {
    this._doc = new XDocument(root.Untyped);
    this._rootObject = root;
  }


  public Value Value { get { return _rootObject as Value; } }
}