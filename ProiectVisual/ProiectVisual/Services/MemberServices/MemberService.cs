using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;
using ProiectVisual.Repositories.MemberRepository;
using ProiectVisual.Services.MemberServices;

namespace ProiectVisual.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        private readonly Context _context;

        /*
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public MemberService(Context context)
        {
            _context = context;
        }
        */

        public MemberService(IMemberRepository memberRepository = null, Context context = null)
        {
            _memberRepository = memberRepository;
            _context = context;
        }
        public async Task<List<Member>> GetDataMappedByStatus(string status)
        {
            var result = _memberRepository.GetByStatus(status);
            return result;
        }

        public async Task<Member> UpdateMember(Guid id, JsonPatchDocument memberDocument)
        {
            Member memberToUpdate = _memberRepository.GetById(id);
            if (memberToUpdate == null)
            {
                return memberToUpdate;
            }
            memberDocument.ApplyTo(memberToUpdate);
            await _context.SaveChangesAsync();

            return memberToUpdate;
        }
    }
}
