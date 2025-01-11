namespace Application.Contract.Dto;

public record BookDto(int Id,string Title,int PublishYear);
public record BookCreateDto(string Title, int PublishYear);