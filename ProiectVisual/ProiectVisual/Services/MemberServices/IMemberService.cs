using Microsoft.AspNetCore.JsonPatch;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;

namespace ProiectVisual.Services.MemberServices
{
    public interface IMemberService
    {
        Task<List<Member>> GetDataMappedByStatus(string status);
        Task<Member> UpdateMember(int id, JsonPatchDocument memberDocument);

    }
}
