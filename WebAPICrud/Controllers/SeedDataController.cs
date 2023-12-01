using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Data;
using Entity.Models;

namespace WebAPICrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeedDataController : ControllerBase
{
    private IRepository<PersonalInfo> _personalInfoRepository;
    public SeedDataController(IRepository<PersonalInfo> personalInfoRepository)
    {
        _personalInfoRepository = personalInfoRepository;
    }
    [HttpPost]
    [Route("AddSeedData")]
    public async Task<IActionResult> AddSeedData()
    {
        SeedData _SeedData = new();
        int totalPersonalInfoAdded = 0;

        var allBranch = await _personalInfoRepository.GetAllAsync();
        if (allBranch.Count() < 1)
        {
            var _GetBranchList = _SeedData.GetPersonalInfoList();
            foreach (PersonalInfo item in _GetBranchList)
            {
                _personalInfoRepository.Add(item);
                await _personalInfoRepository.SaveChangesAsync();
                totalPersonalInfoAdded = totalPersonalInfoAdded + 1;
            }
        }

        return Ok("Total Personal Info Added:" + totalPersonalInfoAdded);
    }
}