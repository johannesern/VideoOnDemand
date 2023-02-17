namespace VOD.Common.DTOs;

public record ClickModel(string PageType, int Id);

public record ClickRefModel(string PageType, int FilmId, int GenreId);