namespace VOD.Common.DTOs;

public record ClickModel(string PageType, int Id);

public record ClickRefModel<TDto>(string PageType, TDto dto);

