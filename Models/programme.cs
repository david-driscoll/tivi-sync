using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using Xml.Schema.Linq;

namespace tivi.Models;

/// <summary>
/// <para>
/// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
/// </para>
/// </summary>
public partial class Programme : XTypedElement, IXMetaData
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

  public static Programme Load(string xmlFile)
  {
    return XTypedServices.Load<Programme>(xmlFile);
  }

  public static Programme Load(System.IO.TextReader xmlFile)
  {
    return XTypedServices.Load<Programme>(xmlFile);
  }

  public static Programme Parse(string xml)
  {
    return XTypedServices.Parse<Programme>(xml);
  }

  public static explicit operator Programme(XElement xe) { return XTypedServices.ToXTypedElement<Programme>(xe, LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }

  public override XTypedElement Clone()
  {
    return XTypedServices.CloneXTypedElement<Programme>(this);
  }

  /// <summary>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public Programme()
  {
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName TitleXName = System.Xml.Linq.XName.Get("title", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Title> _titleField;

  /// <summary>
  /// <para>
  /// Occurrence: required, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Title> Title
  {
    get
    {
      if ((this._titleField == null))
      {
        this._titleField = new XTypedList<Title>(this, LinqToXsdTypeManager.Instance, TitleXName);
      }
      return this._titleField;
    }
    set
    {
      if ((value == null))
      {
        this._titleField = null;
      }
      else
      {
        if ((this._titleField == null))
        {
          this._titleField = XTypedList<Title>.Initialize(this, LinqToXsdTypeManager.Instance, value, TitleXName);
        }
        else
        {
          XTypedServices.SetList<Title>(this._titleField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SubtitleXName = System.Xml.Linq.XName.Get("sub-title", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Subtitle> _subtitleField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Subtitle> Subtitle
  {
    get
    {
      if ((this._subtitleField == null))
      {
        this._subtitleField = new XTypedList<Subtitle>(this, LinqToXsdTypeManager.Instance, SubtitleXName);
      }
      return this._subtitleField;
    }
    set
    {
      if ((value == null))
      {
        this._subtitleField = null;
      }
      else
      {
        if ((this._subtitleField == null))
        {
          this._subtitleField = XTypedList<Subtitle>.Initialize(this, LinqToXsdTypeManager.Instance, value, SubtitleXName);
        }
        else
        {
          XTypedServices.SetList<Subtitle>(this._subtitleField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName DescXName = System.Xml.Linq.XName.Get("desc", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Desc> _descField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Desc> Desc
  {
    get
    {
      if ((this._descField == null))
      {
        this._descField = new XTypedList<Desc>(this, LinqToXsdTypeManager.Instance, DescXName);
      }
      return this._descField;
    }
    set
    {
      if ((value == null))
      {
        this._descField = null;
      }
      else
      {
        if ((this._descField == null))
        {
          this._descField = XTypedList<Desc>.Initialize(this, LinqToXsdTypeManager.Instance, value, DescXName);
        }
        else
        {
          XTypedServices.SetList<Desc>(this._descField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName CreditsXName = System.Xml.Linq.XName.Get("credits", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Credits Credits
  {
    get
    {
      XElement x = this.GetElement(CreditsXName);
      if ((x == null))
      {
        return null;
      }
      return ((Credits)(x));
    }
    set
    {
      this.SetElement(CreditsXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName DateXName = System.Xml.Linq.XName.Get("date", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Date Date
  {
    get
    {
      XElement x = this.GetElement(DateXName);
      if ((x == null))
      {
        return null;
      }
      return ((Date)(x));
    }
    set
    {
      this.SetElement(DateXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName CategoryXName = System.Xml.Linq.XName.Get("category", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Category> _categoryField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Category> Category
  {
    get
    {
      if ((this._categoryField == null))
      {
        this._categoryField = new XTypedList<Category>(this, LinqToXsdTypeManager.Instance, CategoryXName);
      }
      return this._categoryField;
    }
    set
    {
      if ((value == null))
      {
        this._categoryField = null;
      }
      else
      {
        if ((this._categoryField == null))
        {
          this._categoryField = XTypedList<Category>.Initialize(this, LinqToXsdTypeManager.Instance, value, CategoryXName);
        }
        else
        {
          XTypedServices.SetList<Category>(this._categoryField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName KeywordXName = System.Xml.Linq.XName.Get("keyword", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Keyword> _keywordField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Keyword> Keyword
  {
    get
    {
      if ((this._keywordField == null))
      {
        this._keywordField = new XTypedList<Keyword>(this, LinqToXsdTypeManager.Instance, KeywordXName);
      }
      return this._keywordField;
    }
    set
    {
      if ((value == null))
      {
        this._keywordField = null;
      }
      else
      {
        if ((this._keywordField == null))
        {
          this._keywordField = XTypedList<Keyword>.Initialize(this, LinqToXsdTypeManager.Instance, value, KeywordXName);
        }
        else
        {
          XTypedServices.SetList<Keyword>(this._keywordField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName LanguageXName = System.Xml.Linq.XName.Get("language", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Language Language
  {
    get
    {
      XElement x = this.GetElement(LanguageXName);
      if ((x == null))
      {
        return null;
      }
      return ((Language)(x));
    }
    set
    {
      this.SetElement(LanguageXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName OriglanguageXName = System.Xml.Linq.XName.Get("orig-language", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Origlanguage Origlanguage
  {
    get
    {
      XElement x = this.GetElement(OriglanguageXName);
      if ((x == null))
      {
        return null;
      }
      return ((Origlanguage)(x));
    }
    set
    {
      this.SetElement(OriglanguageXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName LengthXName = System.Xml.Linq.XName.Get("length", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Length Length
  {
    get
    {
      XElement x = this.GetElement(LengthXName);
      if ((x == null))
      {
        return null;
      }
      return ((Length)(x));
    }
    set
    {
      this.SetElement(LengthXName, value);
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
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
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
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
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
  protected internal static readonly System.Xml.Linq.XName CountryXName = System.Xml.Linq.XName.Get("country", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Country> _countryField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Country> Country
  {
    get
    {
      if ((this._countryField == null))
      {
        this._countryField = new XTypedList<Country>(this, LinqToXsdTypeManager.Instance, CountryXName);
      }
      return this._countryField;
    }
    set
    {
      if ((value == null))
      {
        this._countryField = null;
      }
      else
      {
        if ((this._countryField == null))
        {
          this._countryField = XTypedList<Country>.Initialize(this, LinqToXsdTypeManager.Instance, value, CountryXName);
        }
        else
        {
          XTypedServices.SetList<Country>(this._countryField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName EpisodenumXName = System.Xml.Linq.XName.Get("episode-num", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Episodenum> _episodenumField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Episodenum> Episodenum
  {
    get
    {
      if ((this._episodenumField == null))
      {
        this._episodenumField = new XTypedList<Episodenum>(this, LinqToXsdTypeManager.Instance, EpisodenumXName);
      }
      return this._episodenumField;
    }
    set
    {
      if ((value == null))
      {
        this._episodenumField = null;
      }
      else
      {
        if ((this._episodenumField == null))
        {
          this._episodenumField = XTypedList<Episodenum>.Initialize(this, LinqToXsdTypeManager.Instance, value, EpisodenumXName);
        }
        else
        {
          XTypedServices.SetList<Episodenum>(this._episodenumField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName VideoXName = System.Xml.Linq.XName.Get("video", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Video Video
  {
    get
    {
      XElement x = this.GetElement(VideoXName);
      if ((x == null))
      {
        return null;
      }
      return ((Video)(x));
    }
    set
    {
      this.SetElement(VideoXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName AudioXName = System.Xml.Linq.XName.Get("audio", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Audio Audio
  {
    get
    {
      XElement x = this.GetElement(AudioXName);
      if ((x == null))
      {
        return null;
      }
      return ((Audio)(x));
    }
    set
    {
      this.SetElement(AudioXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName PreviouslyshownXName = System.Xml.Linq.XName.Get("previously-shown", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Previouslyshown Previouslyshown
  {
    get
    {
      XElement x = this.GetElement(PreviouslyshownXName);
      if ((x == null))
      {
        return null;
      }
      return ((Previouslyshown)(x));
    }
    set
    {
      this.SetElement(PreviouslyshownXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName PremiereXName = System.Xml.Linq.XName.Get("premiere", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Premiere Premiere
  {
    get
    {
      XElement x = this.GetElement(PremiereXName);
      if ((x == null))
      {
        return null;
      }
      return ((Premiere)(x));
    }
    set
    {
      this.SetElement(PremiereXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName LastchanceXName = System.Xml.Linq.XName.Get("last-chance", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual Lastchance Lastchance
  {
    get
    {
      XElement x = this.GetElement(LastchanceXName);
      if ((x == null))
      {
        return null;
      }
      return ((Lastchance)(x));
    }
    set
    {
      this.SetElement(LastchanceXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName NewXName = System.Xml.Linq.XName.Get("new", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual New New
  {
    get
    {
      XElement x = this.GetElement(NewXName);
      if ((x == null))
      {
        return null;
      }
      return ((New)(x));
    }
    set
    {
      this.SetElement(NewXName, value);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName SubtitlesXName = System.Xml.Linq.XName.Get("subtitles", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Subtitles> _subtitlesField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Subtitles> Subtitles
  {
    get
    {
      if ((this._subtitlesField == null))
      {
        this._subtitlesField = new XTypedList<Subtitles>(this, LinqToXsdTypeManager.Instance, SubtitlesXName);
      }
      return this._subtitlesField;
    }
    set
    {
      if ((value == null))
      {
        this._subtitlesField = null;
      }
      else
      {
        if ((this._subtitlesField == null))
        {
          this._subtitlesField = XTypedList<Subtitles>.Initialize(this, LinqToXsdTypeManager.Instance, value, SubtitlesXName);
        }
        else
        {
          XTypedServices.SetList<Subtitles>(this._subtitlesField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName RatingXName = System.Xml.Linq.XName.Get("rating", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Rating> _ratingField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Rating> Rating
  {
    get
    {
      if ((this._ratingField == null))
      {
        this._ratingField = new XTypedList<Rating>(this, LinqToXsdTypeManager.Instance, RatingXName);
      }
      return this._ratingField;
    }
    set
    {
      if ((value == null))
      {
        this._ratingField = null;
      }
      else
      {
        if ((this._ratingField == null))
        {
          this._ratingField = XTypedList<Rating>.Initialize(this, LinqToXsdTypeManager.Instance, value, RatingXName);
        }
        else
        {
          XTypedServices.SetList<Rating>(this._ratingField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName StarratingXName = System.Xml.Linq.XName.Get("star-rating", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Starrating> _starratingField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Starrating> Starrating
  {
    get
    {
      if ((this._starratingField == null))
      {
        this._starratingField = new XTypedList<Starrating>(this, LinqToXsdTypeManager.Instance, StarratingXName);
      }
      return this._starratingField;
    }
    set
    {
      if ((value == null))
      {
        this._starratingField = null;
      }
      else
      {
        if ((this._starratingField == null))
        {
          this._starratingField = XTypedList<Starrating>.Initialize(this, LinqToXsdTypeManager.Instance, value, StarratingXName);
        }
        else
        {
          XTypedServices.SetList<Starrating>(this._starratingField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ReviewXName = System.Xml.Linq.XName.Get("review", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Review> _reviewField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
  /// </para>
  /// </summary>
  public virtual IList<Review> Review
  {
    get
    {
      if ((this._reviewField == null))
      {
        this._reviewField = new XTypedList<Review>(this, LinqToXsdTypeManager.Instance, ReviewXName);
      }
      return this._reviewField;
    }
    set
    {
      if ((value == null))
      {
        this._reviewField = null;
      }
      else
      {
        if ((this._reviewField == null))
        {
          this._reviewField = XTypedList<Review>.Initialize(this, LinqToXsdTypeManager.Instance, value, ReviewXName);
        }
        else
        {
          XTypedServices.SetList<Review>(this._reviewField, value);
        }
      }
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ImageXName = System.Xml.Linq.XName.Get("image", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private XTypedList<Image> _imageField;

  /// <summary>
  /// <para>
  /// Occurrence: optional, repeating
  /// </para>
  /// <para>
  /// Regular expression: (title+, subtitle*, desc*, credits?, date?, category*, keyword*, language?, origlanguage?, length?, icon*, url*, country*, episodenum*, video?, audio?, previouslyshown?, premiere?, lastchance?, @new?, subtitles*, rating*, starrating*, review*, image*)
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
  protected internal static readonly System.Xml.Linq.XName StartXName = System.Xml.Linq.XName.Get("start", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// </summary>
  public virtual string Start
  {
    get
    {
      XAttribute x = this.Attribute(StartXName);
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(StartXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName StopXName = System.Xml.Linq.XName.Get("stop", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Stop
  {
    get
    {
      XAttribute x = this.Attribute(StopXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(StopXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName PdcstartXName = System.Xml.Linq.XName.Get("pdc-start", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Pdcstart
  {
    get
    {
      XAttribute x = this.Attribute(PdcstartXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(PdcstartXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName VpsstartXName = System.Xml.Linq.XName.Get("vps-start", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Vpsstart
  {
    get
    {
      XAttribute x = this.Attribute(VpsstartXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(VpsstartXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ShowviewXName = System.Xml.Linq.XName.Get("showview", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Showview
  {
    get
    {
      XAttribute x = this.Attribute(ShowviewXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(ShowviewXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName VideoplusXName = System.Xml.Linq.XName.Get("videoplus", "");

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Videoplus
  {
    get
    {
      XAttribute x = this.Attribute(VideoplusXName);
      if ((x == null))
      {
        return null;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(VideoplusXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ChannelXName = System.Xml.Linq.XName.Get("channel", "");

  /// <summary>
  /// <para>
  /// Occurrence: required
  /// </para>
  /// </summary>
  public virtual string Channel
  {
    get
    {
      XAttribute x = this.Attribute(ChannelXName);
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(ChannelXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  protected internal static readonly System.Xml.Linq.XName ClumpidxXName = System.Xml.Linq.XName.Get("clumpidx", "");

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static string _clumpidxDefaultValue = "0/1";

  /// <summary>
  /// <para>
  /// Occurrence: optional
  /// </para>
  /// </summary>
  public virtual string Clumpidx
  {
    get
    {
      XAttribute x = this.Attribute(ClumpidxXName);
      if ((x == null))
      {
        return _clumpidxDefaultValue;
      }
      return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
    set
    {
      this.SetAttribute(ClumpidxXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyAtomicType).Datatype);
    }
  }

  private static readonly System.Xml.Linq.XName XName = System.Xml.Linq.XName.Get("programme", "");

  static Programme()
  {
    BuildElementDictionary();
    _contentModel = new SequenceContentModelEntity(new NamedContentModelEntity(TitleXName), new NamedContentModelEntity(SubtitleXName), new NamedContentModelEntity(DescXName), new NamedContentModelEntity(CreditsXName), new NamedContentModelEntity(DateXName), new NamedContentModelEntity(CategoryXName), new NamedContentModelEntity(KeywordXName), new NamedContentModelEntity(LanguageXName), new NamedContentModelEntity(OriglanguageXName), new NamedContentModelEntity(LengthXName), new NamedContentModelEntity(IconXName), new NamedContentModelEntity(UrlXName), new NamedContentModelEntity(CountryXName), new NamedContentModelEntity(EpisodenumXName), new NamedContentModelEntity(VideoXName), new NamedContentModelEntity(AudioXName), new NamedContentModelEntity(PreviouslyshownXName), new NamedContentModelEntity(PremiereXName), new NamedContentModelEntity(LastchanceXName), new NamedContentModelEntity(NewXName), new NamedContentModelEntity(SubtitlesXName), new NamedContentModelEntity(RatingXName), new NamedContentModelEntity(StarratingXName), new NamedContentModelEntity(ReviewXName), new NamedContentModelEntity(ImageXName));
  }

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private static Dictionary<System.Xml.Linq.XName, System.Type> _localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();

  private static void BuildElementDictionary()
  {
    _localElementDictionary.Add(TitleXName, typeof(Title));
    _localElementDictionary.Add(SubtitleXName, typeof(Subtitle));
    _localElementDictionary.Add(DescXName, typeof(Desc));
    _localElementDictionary.Add(CreditsXName, typeof(Credits));
    _localElementDictionary.Add(DateXName, typeof(Date));
    _localElementDictionary.Add(CategoryXName, typeof(Category));
    _localElementDictionary.Add(KeywordXName, typeof(Keyword));
    _localElementDictionary.Add(LanguageXName, typeof(Language));
    _localElementDictionary.Add(OriglanguageXName, typeof(Origlanguage));
    _localElementDictionary.Add(LengthXName, typeof(Length));
    _localElementDictionary.Add(IconXName, typeof(Icon));
    _localElementDictionary.Add(UrlXName, typeof(Url));
    _localElementDictionary.Add(CountryXName, typeof(Country));
    _localElementDictionary.Add(EpisodenumXName, typeof(Episodenum));
    _localElementDictionary.Add(VideoXName, typeof(Video));
    _localElementDictionary.Add(AudioXName, typeof(Audio));
    _localElementDictionary.Add(PreviouslyshownXName, typeof(Previouslyshown));
    _localElementDictionary.Add(PremiereXName, typeof(Premiere));
    _localElementDictionary.Add(LastchanceXName, typeof(Lastchance));
    _localElementDictionary.Add(NewXName, typeof(New));
    _localElementDictionary.Add(SubtitlesXName, typeof(Subtitles));
    _localElementDictionary.Add(RatingXName, typeof(Rating));
    _localElementDictionary.Add(StarratingXName, typeof(Starrating));
    _localElementDictionary.Add(ReviewXName, typeof(Review));
    _localElementDictionary.Add(ImageXName, typeof(Image));
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