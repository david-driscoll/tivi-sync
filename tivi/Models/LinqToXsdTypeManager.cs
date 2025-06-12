using System.Diagnostics;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

public class LinqToXsdTypeManager : ILinqToXsdTypeManager
{

  private LinqToXsdTypeManager()
  {
  }

  private static Dictionary<System.Xml.Linq.XName, System.Type> _elementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _elementDictionary.Add(System.Xml.Linq.XName.Get("tv", ""), typeof(global::tivi.Models.Tv));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("channel", ""), typeof(global::tivi.Models.Channel));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("display-name", ""), typeof(global::tivi.Models.Displayname));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("icon", ""), typeof(global::tivi.Models.Icon));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("url", ""), typeof(global::tivi.Models.Url));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("programme", ""), typeof(global::tivi.Models.Programme));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("title", ""), typeof(global::tivi.Models.Title));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("sub-title", ""), typeof(global::tivi.Models.Subtitle));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("desc", ""), typeof(global::tivi.Models.Desc));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("credits", ""), typeof(global::tivi.Models.Credits));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("director", ""), typeof(global::tivi.Models.Director));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("actor", ""), typeof(global::tivi.Models.Actor));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("writer", ""), typeof(global::tivi.Models.Writer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("adapter", ""), typeof(global::tivi.Models.Adapter));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("producer", ""), typeof(global::tivi.Models.Producer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("composer", ""), typeof(global::tivi.Models.Composer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("editor", ""), typeof(global::tivi.Models.Editor));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("presenter", ""), typeof(global::tivi.Models.Presenter));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("commentator", ""), typeof(global::tivi.Models.Commentator));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("guest", ""), typeof(global::tivi.Models.Guest));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("category", ""), typeof(global::tivi.Models.Category));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("keyword", ""), typeof(global::tivi.Models.Keyword));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("language", ""), typeof(global::tivi.Models.Language));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("orig-language", ""), typeof(global::tivi.Models.Origlanguage));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("length", ""), typeof(global::tivi.Models.Length));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("country", ""), typeof(global::tivi.Models.Country));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("episode-num", ""), typeof(global::tivi.Models.Episodenum));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("video", ""), typeof(global::tivi.Models.Video));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("audio", ""), typeof(global::tivi.Models.Audio));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("previously-shown", ""), typeof(global::tivi.Models.Previouslyshown));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("premiere", ""), typeof(global::tivi.Models.Premiere));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("last-chance", ""), typeof(global::tivi.Models.Lastchance));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("new", ""), typeof(global::tivi.Models.New));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("subtitles", ""), typeof(global::tivi.Models.Subtitles));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("rating", ""), typeof(global::tivi.Models.Rating));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("star-rating", ""), typeof(global::tivi.Models.Starrating));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("review", ""), typeof(global::tivi.Models.Review));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("image", ""), typeof(global::tivi.Models.Image));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("date", ""), typeof(global::tivi.Models.Date));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("present", ""), typeof(global::tivi.Models.Present));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("colour", ""), typeof(global::tivi.Models.Colour));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("aspect", ""), typeof(global::tivi.Models.Aspect));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("quality", ""), typeof(global::tivi.Models.Quality));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("stereo", ""), typeof(global::tivi.Models.Stereo));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("value", ""), typeof(global::tivi.Models.Value));
  }

  private static XmlSchemaSet _schemaSet;

  XmlSchemaSet ILinqToXsdTypeManager.Schemas
  {
    get
    {
      if ((_schemaSet == null))
      {
        XmlSchemaSet tempSet = new XmlSchemaSet();
        System.Threading.Interlocked.CompareExchange(ref _schemaSet, tempSet, null);
      }
      return _schemaSet;
    }
    set
    {
      _schemaSet = value;
    }
  }

  protected internal static void AddSchemas(XmlSchemaSet schemas)
  {
    schemas.Add(_schemaSet);
  }

  Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalTypeDictionary
  {
    get
    {
      return XTypedServices.EmptyDictionary;
    }
  }

  Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalElementDictionary
  {
    get
    {
      return _elementDictionary;
    }
  }

  Dictionary<System.Type, System.Type> ILinqToXsdTypeManager.RootContentTypeMapping
  {
    get
    {
      return XTypedServices.EmptyTypeMappingDictionary;
    }
  }

  static LinqToXsdTypeManager()
  {
    BuildElementDictionary();
  }

  public static System.Type GetRootType()
  {
    return _elementDictionary[System.Xml.Linq.XName.Get("tv", "")];
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static LinqToXsdTypeManager _typeManagerSingleton = new LinqToXsdTypeManager();

  public static LinqToXsdTypeManager Instance
  {
    get
    {
      return _typeManagerSingleton;
    }
  }
}