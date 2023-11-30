using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Data;


namespace WebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private IRepository<PersonalInfo> _personalInfoRepository;
        public PersonalInfoController(IRepository<PersonalInfo> personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<PersonalInfo>>> GetAll()
        {
            return Ok(await _personalInfoRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetBy/{id}")]
        public async Task<ActionResult<PersonalInfo>> GetBy(Int64 id)
        {
            var result = await _personalInfoRepository.GetByIdAsync(id);
            if (result == null)
            {
                return Ok("Not Found");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetByName/{PersonalInfoName}")]
        public async Task<ActionResult<PersonalInfo>> GetByName(string PersonalInfoName)
        {
            return Ok(await _personalInfoRepository.FindByConditionAsync(x => x.FirstName.Contains(PersonalInfoName)));
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] PersonalInfo PersonalInfo)
        {
            _personalInfoRepository.Add(PersonalInfo);
            return Ok(await _personalInfoRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PersonalInfo PersonalInfo)
        {
            _personalInfoRepository.Update(PersonalInfo);
            return Ok(await _personalInfoRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            await _personalInfoRepository.Delete(id);
            return Ok(await _personalInfoRepository.SaveChangesAsync());
        }
    }
}
