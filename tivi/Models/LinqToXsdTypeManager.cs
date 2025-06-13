using System.Diagnostics;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace Tivi.Models;

public class LinqToXsdTypeManager : ILinqToXsdTypeManager
{

  private LinqToXsdTypeManager()
  {
  }

  private static Dictionary<System.Xml.Linq.XName, System.Type> _elementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _elementDictionary.Add(System.Xml.Linq.XName.Get("tv", ""), typeof(global::Tivi.Models.Tv));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("channel", ""), typeof(global::Tivi.Models.Channel));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("display-name", ""), typeof(global::Tivi.Models.Displayname));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("icon", ""), typeof(global::Tivi.Models.Icon));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("url", ""), typeof(global::Tivi.Models.Url));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("programme", ""), typeof(global::Tivi.Models.Programme));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("title", ""), typeof(global::Tivi.Models.Title));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("sub-title", ""), typeof(global::Tivi.Models.Subtitle));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("desc", ""), typeof(global::Tivi.Models.Desc));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("credits", ""), typeof(global::Tivi.Models.Credits));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("director", ""), typeof(global::Tivi.Models.Director));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("actor", ""), typeof(global::Tivi.Models.Actor));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("writer", ""), typeof(global::Tivi.Models.Writer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("adapter", ""), typeof(global::Tivi.Models.Adapter));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("producer", ""), typeof(global::Tivi.Models.Producer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("composer", ""), typeof(global::Tivi.Models.Composer));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("editor", ""), typeof(global::Tivi.Models.Editor));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("presenter", ""), typeof(global::Tivi.Models.Presenter));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("commentator", ""), typeof(global::Tivi.Models.Commentator));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("guest", ""), typeof(global::Tivi.Models.Guest));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("category", ""), typeof(global::Tivi.Models.Category));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("keyword", ""), typeof(global::Tivi.Models.Keyword));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("language", ""), typeof(global::Tivi.Models.Language));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("orig-language", ""), typeof(global::Tivi.Models.Origlanguage));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("length", ""), typeof(global::Tivi.Models.Length));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("country", ""), typeof(global::Tivi.Models.Country));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("episode-num", ""), typeof(global::Tivi.Models.Episodenum));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("video", ""), typeof(global::Tivi.Models.Video));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("audio", ""), typeof(global::Tivi.Models.Audio));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("previously-shown", ""), typeof(global::Tivi.Models.Previouslyshown));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("premiere", ""), typeof(global::Tivi.Models.Premiere));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("last-chance", ""), typeof(global::Tivi.Models.Lastchance));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("new", ""), typeof(global::Tivi.Models.New));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("subtitles", ""), typeof(global::Tivi.Models.Subtitles));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("rating", ""), typeof(global::Tivi.Models.Rating));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("star-rating", ""), typeof(global::Tivi.Models.Starrating));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("review", ""), typeof(global::Tivi.Models.Review));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("image", ""), typeof(global::Tivi.Models.Image));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("date", ""), typeof(global::Tivi.Models.Date));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("present", ""), typeof(global::Tivi.Models.Present));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("colour", ""), typeof(global::Tivi.Models.Colour));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("aspect", ""), typeof(global::Tivi.Models.Aspect));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("quality", ""), typeof(global::Tivi.Models.Quality));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("stereo", ""), typeof(global::Tivi.Models.Stereo));
    _elementDictionary.Add(System.Xml.Linq.XName.Get("value", ""), typeof(global::Tivi.Models.Value));
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