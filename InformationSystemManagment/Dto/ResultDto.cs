namespace InformationSystemManagment.Dto;
public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}

public class ResultDto<TData> : ResultDto
{
    public TData? Data { get; set; }
}