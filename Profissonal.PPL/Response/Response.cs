

namespace Profissonal.PPL.Response
{
    public record Response<T>(T Result, bool? Secsses, string? MessageError);
}
